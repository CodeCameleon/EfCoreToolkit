namespace CodeCameleon.EfCoreToolkit.EntityInterfaces;

/// <summary>
/// Defines an entity that supports modification.
/// </summary>
public interface IModifiable
{
    /// <summary>
    /// The UTC time and date when the entity was last modified in the database.
    /// </summary>
    DateTime? UpdatedAt { get; }
}
