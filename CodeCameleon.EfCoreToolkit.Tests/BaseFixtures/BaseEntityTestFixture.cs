using NUnit.Framework;

namespace CodeCameleon.EfCoreToolkit.Tests.BaseFixtures;

/// <summary>
/// A base test fixture for all entity-related tests.
/// </summary>
/// <typeparam name="TBaseEntity">The base entity type.</typeparam>
/// <typeparam name="TImplementation">The concrete implementation type.</typeparam>
[TestFixture]
internal abstract class BaseEntityTestFixture<TBaseEntity, TImplementation>
    where TBaseEntity : class
    where TImplementation : TBaseEntity, new()
{
    /// <summary>
    /// Verifies that the specified interface is implemented by the base entity type.
    /// </summary>
    /// <param name="interfaceType">The interface type to check.</param>
    /// <param name="shouldImplement">Whether the base entity should implement the interface.</param>
    protected static void AssertInterfaceImplementation(Type interfaceType, bool shouldImplement)
    {
        if (!interfaceType.IsInterface)
        {
            throw new ArgumentException("The provided type must be an interface.", nameof(interfaceType));
        }

        TBaseEntity entity = new TImplementation();
        bool implements = interfaceType.IsInstanceOfType(entity);

        string message = $"{typeof(TBaseEntity).Name} {(shouldImplement ? "should" : "should not")} implement the {interfaceType.Name} interface.";

        Assert.That(implements, Is.EqualTo(shouldImplement), message);
    }
}
