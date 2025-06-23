using CodeCameleon.EfCoreToolkit.EntityMetadataInterfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeCameleon.EfCoreToolkit.BaseEntities;

/// <summary>
/// Represents an entity that cannot be modified, but can be soft deleted.
/// </summary>
public abstract class DisposableEntity
    : ICreationMetadata, ISoftDeletionMetadata
{
    /// <summary>
    /// The field containing the creation timestamp of the entity.
    /// </summary>
    private DateTime? _createdAt;

    /// <summary>
    /// The field containing the deletion timestamp of the entity.
    /// </summary>
    private DateTime? _deletedAt;

    /// <inheritdoc />
    public DateTime? CreatedAt => _createdAt;

    /// <inheritdoc />
    DateTime? ICreationMetadata.CreatedAt
    {
        set => _createdAt = value;
    }

    /// <inheritdoc />
    public DateTime? DeletedAt => _deletedAt;

    /// <inheritdoc />
    DateTime? ISoftDeletionMetadata.DeletedAt
    {
        set => _deletedAt = value;
    }

    /// <inheritdoc />
    [NotMapped]
    bool ICreationMetadata.IsCreationPending => !CreatedAt.HasValue;

    /// <inheritdoc />
    [NotMapped]
    bool ICreationMetadata.IsCreated => CreatedAt.HasValue;

    /// <inheritdoc />
    [NotMapped]
    bool ISoftDeletionMetadata.IsDeletionPending => !DeletedAt.HasValue;

    /// <inheritdoc />
    [NotMapped]
    bool ISoftDeletionMetadata.IsDeleted => DeletedAt.HasValue;
}
