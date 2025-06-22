using CodeCameleon.EfCoreToolkit.EntityInterfaces;

namespace CodeCameleon.EfCoreToolkit.BaseEntities;

/// <summary>
/// Represents an entity that cannot be modified, but can be hard deleted.
/// </summary>
public abstract class TemporaryEntity
    : ICreatable, IHardDeletable
{
    /// <inheritdoc />
    public DateTime? CreatedAt { get; internal set; }
}
