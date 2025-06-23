using CodeCameleon.EfCoreToolkit.EntityMetadataInterfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeCameleon.EfCoreToolkit.BaseEntities;

/// <summary>
/// Represents an entity that cannot be modified or deleted.
/// </summary>
public abstract class ArchiveEntity
    : ICreationMetadata
{
    /// <summary>
    /// The field containing the creation timestamp of the entity.
    /// </summary>
    private DateTime? _createdAt;

    /// <inheritdoc />
    public DateTime? CreatedAt => _createdAt;

    /// <inheritdoc />
    DateTime? ICreationMetadata.CreatedAt
    {
        set => _createdAt = value;
    }

    /// <inheritdoc />
    [NotMapped]
    bool ICreationMetadata.IsCreationPending => !CreatedAt.HasValue;

    /// <inheritdoc />
    [NotMapped]
    bool ICreationMetadata.IsCreated => CreatedAt.HasValue;
}
