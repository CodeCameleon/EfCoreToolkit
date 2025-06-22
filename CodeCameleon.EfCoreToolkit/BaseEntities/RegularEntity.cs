using CodeCameleon.EfCoreToolkit.EntityInterfaces;

namespace CodeCameleon.EfCoreToolkit.BaseEntities;

/// <summary>
/// Represents an entity that can be modified and hard deleted.
/// </summary>
public abstract class RegularEntity
    : ICreatable, IModifiable, IHardDeletable
{
    /// <inheritdoc />
    public DateTime? CreatedAt { get; internal set; }

    /// <inheritdoc />
    public DateTime? UpdatedAt { get; internal set; }
}
