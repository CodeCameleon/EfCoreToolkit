using CodeCameleon.EfCoreToolkit.EntityInterfaces;

namespace CodeCameleon.EfCoreToolkit.EntityMetadataInterfaces;

/// <summary>
/// Defines the internal metadata for an entity that supports soft deletion.
/// </summary>
internal interface ISoftDeletionMetadata
    : ISoftDeletable
{
    /// <summary>
    /// Sets the deletion timestamp for the entity.
    /// </summary>
    new DateTime? DeletedAt { set; }

    /// <summary>
    /// Indicates whether the entity has not yet been assigned a deletion timestamp.
    /// </summary>
    bool IsDeletionPending { get; }

    /// <summary>
    /// Indicates whether the deletion timestamp has been set for the entity.
    /// </summary>
    bool IsDeleted { get; }
}
