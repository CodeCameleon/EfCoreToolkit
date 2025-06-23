using CodeCameleon.EfCoreToolkit.EntityInterfaces;

namespace CodeCameleon.EfCoreToolkit.EntityMetadataInterfaces;

/// <summary>
/// Defines the internal metadata for an entity that supports creation.
/// </summary>
internal interface ICreationMetadata
    : ICreatable
{
    /// <summary>
    /// Sets the creation timestamp for the entity.
    /// </summary>
    new DateTime? CreatedAt { set; }

    /// <summary>
    /// Indicates whether the entity has not yet been assigned a creation timestamp.
    /// </summary>
    bool IsCreationPending { get; }

    /// <summary>
    /// Indicates whether the creation timestamp has been set for the entity.
    /// </summary>
    bool IsCreated { get; }
}
