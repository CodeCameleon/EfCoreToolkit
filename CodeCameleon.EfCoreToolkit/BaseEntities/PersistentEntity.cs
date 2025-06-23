using CodeCameleon.EfCoreToolkit.EntityMetadataInterfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeCameleon.EfCoreToolkit.BaseEntities;

/// <summary>
/// Represents an entity that can be modified, but cannot be deleted.
/// </summary>
public abstract class PersistentEntity
    : ICreationMetadata, IModificationMetadata
{
    /// <summary>
    /// The field containing the creation timestamp of the entity.
    /// </summary>
    private DateTime? _createdAt;

    /// <summary>
    /// The field containing the last modification timestamp of the entity.
    /// </summary>
    private DateTime? _updatedAt;

    /// <inheritdoc />
    public DateTime? CreatedAt => _createdAt;

    /// <inheritdoc />
    DateTime? ICreationMetadata.CreatedAt
    {
        set => _createdAt = value;
    }

    /// <inheritdoc />
    public DateTime? UpdatedAt => _updatedAt;

    /// <inheritdoc />
    DateTime? IModificationMetadata.UpdatedAt
    {
        set => _updatedAt = value;
    }

    /// <inheritdoc />
    [NotMapped]
    bool ICreationMetadata.IsCreationPending => !CreatedAt.HasValue;

    /// <inheritdoc />
    [NotMapped]
    bool ICreationMetadata.IsCreated => CreatedAt.HasValue;
}
