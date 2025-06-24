using CodeCameleon.EfCoreToolkit.EntityInterfaces;
using CodeCameleon.EfCoreToolkit.EntityMetadataInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CodeCameleon.EfCoreToolkit.Contexts;

/// <summary>
/// Represents the base <see cref="DbContext" /> that enforces all entity rules defined by this toolkit.
/// </summary>
/// <remarks>All <see cref="DbContext" /> implementations should inherit from this class.</remarks>
public abstract class ToolkitDbContext
    : DbContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ToolkitDbContext" /> class.
    /// </summary>
    public ToolkitDbContext() : base() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ToolkitDbContext" /> class using the specified options.
    /// </summary>
    /// <param name="options">The options to be used by the context.</param>
    public ToolkitDbContext(DbContextOptions options) : base(options) { }

    /// <inheritdoc />
    public override int SaveChanges()
    {
        ApplyEntityRules();
        return base.SaveChanges();
    }

    /// <inheritdoc />
    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        ApplyEntityRules();
        return base.SaveChanges(acceptAllChangesOnSuccess);
    }

    /// <inheritdoc />
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        ApplyEntityRules();
        return base.SaveChangesAsync(cancellationToken);
    }

    /// <inheritdoc />
    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        ApplyEntityRules();
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    /// <summary>
    /// Applies all entity rules that are defined by this toolkit.
    /// </summary>
    private void ApplyEntityRules()
    {
        DateTime currentDateTime = DateTime.UtcNow;

        Dictionary<EntityState, List<EntityEntry>> entityEntries = ChangeTracker.Entries()
            .GroupBy(e => e.State)
            .ToDictionary(g => g.Key, g => g.ToList());

        if (entityEntries.TryGetValue(EntityState.Added, out var addedEntities))
        {
            List<EntityEntry> unrecognized = addedEntities
                .Where(e => e.Entity is not ICreationMetadata)
                .ToList();
            unrecognized.ForEach(e => e.State = EntityState.Detached);

            List<ICreationMetadata> creations = addedEntities
                .Select(e => e.Entity)
                .OfType<ICreationMetadata>()
                .Where(c => c.IsCreationPending)
                .ToList();
            creations.ForEach(c => c.CreatedAt = currentDateTime);

            List<EntityEntry> alreadyCreated = addedEntities
                .Where(e =>
                    e.Entity is ICreationMetadata c &&
                    c.IsCreated
                )
                .ToList();
            alreadyCreated.ForEach(e => e.State = EntityState.Unchanged);
        }

        if (entityEntries.TryGetValue(EntityState.Modified, out var modifiedEntities))
        {
            List<EntityEntry> falselyModified = modifiedEntities
                .Where(e => e.Entity is not IModificationMetadata)
                .ToList();
            falselyModified.ForEach(e => e.State = EntityState.Unchanged);

            List<IModificationMetadata> modifications = modifiedEntities
                .Select(e => e.Entity)
                .OfType<IModificationMetadata>()
                .ToList();
            modifications.ForEach(m => m.UpdatedAt = currentDateTime);
        }

        if (entityEntries.TryGetValue(EntityState.Deleted, out var deletedEntities))
        {
            List<EntityEntry> falselyDeleted = deletedEntities
                .Where(e =>
                    e.Entity is not ISoftDeletionMetadata &&
                    e.Entity is not IHardDeletable
                )
                .ToList();
            falselyDeleted.ForEach(e => e.State = EntityState.Unchanged);

            List<ISoftDeletionMetadata> deletions = deletedEntities
                .Select(e => e.Entity)
                .OfType<ISoftDeletionMetadata>()
                .Where(d => d.IsDeletionPending)
                .ToList();
            deletions.ForEach(d => d.DeletedAt = currentDateTime);

            List<EntityEntry> alreadyDeleted = deletedEntities
                .Where(e =>
                    e.Entity is ISoftDeletionMetadata d &&
                    d.IsDeleted
                )
                .ToList();
            alreadyDeleted.ForEach(e => e.State = EntityState.Unchanged);
        }
    }
}
