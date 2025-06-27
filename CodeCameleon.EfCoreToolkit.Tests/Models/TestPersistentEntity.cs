using CodeCameleon.EfCoreToolkit.BaseEntities;
using System.ComponentModel.DataAnnotations;

namespace CodeCameleon.EfCoreToolkit.Tests.Models;

/// <summary>
/// A test implementation of <see cref="PersistentEntity" /> for unit testing purposes.
/// </summary>
internal class TestPersistentEntity
    : PersistentEntity
{
    /// <summary>
    /// The unique identifier for the entity.
    /// </summary>
    [Key]
    public Guid Id { get; set; }

    /// <summary>
    /// The name of the entity.
    /// </summary>
    public string? Name { get; set; }
}
