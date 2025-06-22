using CodeCameleon.EfCoreToolkit.EntityInterfaces;

namespace CodeCameleon.EfCoreToolkit.BaseEntities;

/// <summary>
/// Represents an entity that can be modified, but cannot be deleted.
/// </summary>
public abstract class PersistentEntity
    : ICreatable, IModifiable
{
    /// <inheritdoc />
    public DateTime? CreatedAt { get; internal set; }

    /// <inheritdoc />
    public DateTime? UpdatedAt { get; internal set; }
}
