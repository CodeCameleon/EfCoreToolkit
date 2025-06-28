using CodeCameleon.EfCoreToolkit.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CodeCameleon.EfCoreToolkit.Tests.Models;

/// <summary>
/// A test implementation of <see cref="ToolkitDbContext" /> for unit testing purposes.
/// </summary>
internal class TestDbContext
    : ToolkitDbContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TestDbContext" /> class.
    /// </summary>
    public TestDbContext() : base() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="TestDbContext" /> class using the specified options.
    /// </summary>
    /// <param name="options">The options to be used by the context.</param>
    public TestDbContext(DbContextOptions<TestDbContext> options) : base(options) { }

    /// <summary>
    /// Configures the context to use an in-memory database, if it has not been configured yet.
    /// </summary>
    /// <param name="optionsBuilder">The builder used to configure the context options.</param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseInMemoryDatabase(GetUniqueDatabaseName());
        }

        base.OnConfiguring(optionsBuilder);
    }

    /// <summary>
    /// Generates a unique name for the database based on the current UTC date and time.
    /// </summary>
    /// <returns>The unique database name.</returns>
    private static string GetUniqueDatabaseName()
    {
        return $"TestDb_{DateTime.UtcNow:yyyyMMddTHHmmssfffZ}";
    }
}
