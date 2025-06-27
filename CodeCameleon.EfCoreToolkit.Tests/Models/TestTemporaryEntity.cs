using CodeCameleon.EfCoreToolkit.BaseEntities;
using System.ComponentModel.DataAnnotations;

namespace CodeCameleon.EfCoreToolkit.Tests.Models;

/// <summary>
/// A test implementation of <see cref="TemporaryEntity" /> for unit testing purposes.
/// </summary>
internal class TestTemporaryEntity
    : TemporaryEntity
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
