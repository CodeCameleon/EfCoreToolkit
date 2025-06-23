using CodeCameleon.EfCoreToolkit.EntityInterfaces;

namespace CodeCameleon.EfCoreToolkit.EntityMetadataInterfaces;

/// <summary>
/// Defines the internal metadata for an entity that supports modification.
/// </summary>
internal interface IModificationMetadata
    : IModifiable
{
    /// <summary>
    /// Sets the last modification timestamp for the entity.
    /// </summary>
    new DateTime? UpdatedAt { set; }
}
