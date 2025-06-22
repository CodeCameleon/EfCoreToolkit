using CodeCameleon.EfCoreToolkit.EntityInterfaces;

namespace CodeCameleon.EfCoreToolkit.BaseEntities;

/// <summary>
/// Represents an entity that can be modified and soft deleted.
/// </summary>
public abstract class AuditableEntity
    : ICreatable, IModifiable, ISoftDeletable
{
    /// <inheritdoc />
    public DateTime? CreatedAt { get; internal set; }

    /// <inheritdoc />
    public DateTime? UpdatedAt { get; internal set; }

    /// <inheritdoc />
    public DateTime? DeletedAt { get; internal set; }
}
