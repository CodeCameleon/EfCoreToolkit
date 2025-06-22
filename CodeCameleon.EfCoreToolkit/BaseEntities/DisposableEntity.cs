using CodeCameleon.EfCoreToolkit.EntityInterfaces;

namespace CodeCameleon.EfCoreToolkit.BaseEntities;

/// <summary>
/// Represents an entity that cannot be modified, but can be soft deleted.
/// </summary>
public abstract class DisposableEntity
    : ICreatable, ISoftDeletable
{
    /// <inheritdoc />
    public DateTime? CreatedAt { get; internal set; }

    /// <inheritdoc />
    public DateTime? DeletedAt { get; internal set; }
}
