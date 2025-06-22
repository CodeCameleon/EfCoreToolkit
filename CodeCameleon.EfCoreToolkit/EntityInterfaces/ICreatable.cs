namespace CodeCameleon.EfCoreToolkit.EntityInterfaces;

/// <summary>
/// Defines an entity that supports creation.
/// </summary>
public interface ICreatable
{
    /// <summary>
    /// The UTC time and date when the entity was added to the database.
    /// </summary>
    DateTime? CreatedAt { get; }
}
