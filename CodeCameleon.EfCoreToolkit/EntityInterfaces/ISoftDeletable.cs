namespace CodeCameleon.EfCoreToolkit.EntityInterfaces;

/// <summary>
/// Defines an entity that supports soft deletion.
/// </summary>
public interface ISoftDeletable
{
    /// <summary>
    /// The UTC time and date when the entity was marked as removed from the database.
    /// </summary>
    DateTime? DeletedAt { get; }
}
