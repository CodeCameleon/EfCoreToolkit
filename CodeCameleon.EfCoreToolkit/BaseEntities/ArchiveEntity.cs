using CodeCameleon.EfCoreToolkit.EntityInterfaces;

namespace CodeCameleon.EfCoreToolkit.BaseEntities;

/// <summary>
/// Represents an entity that cannot be modified or deleted.
/// </summary>
public abstract class ArchiveEntity
    : ICreatable
{
    /// <inheritdoc />
    public DateTime? CreatedAt { get; internal set; }
}
