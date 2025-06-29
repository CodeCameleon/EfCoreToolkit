using CodeCameleon.EfCoreToolkit.BaseEntities;
using CodeCameleon.EfCoreToolkit.EntityInterfaces;
using CodeCameleon.EfCoreToolkit.Tests.BaseFixtures;
using CodeCameleon.EfCoreToolkit.Tests.Models;
using NUnit.Framework;

namespace CodeCameleon.EfCoreToolkit.Tests.Entities;

/// <summary>
/// The test fixture for all <see cref="DisposableEntity" /> related tests.
/// </summary>
internal class DisposableEntityTests
    : BaseEntityTestFixture<DisposableEntity, TestDisposableEntity>
{
    /// <summary>
    /// Verifies whether <see cref="DisposableEntity" /> correctly implements
    /// or does not implement the specified interface.
    /// </summary>
    /// <param name="interfaceType">The interface type to check.</param>
    /// <param name="shouldImplement">The value indicating whether the interface is expected to be implemented.</param>
    [TestCase(typeof(ICreatable), true, TestName = "Should Implement ICreatable")]
    [TestCase(typeof(IModifiable), false, TestName = "Should Not Implement IModifiable")]
    [TestCase(typeof(IHardDeletable), false, TestName = "Should Not Implement IHardDeletable")]
    [TestCase(typeof(ISoftDeletable), true, TestName = "Should Implement ISoftDeletable")]
    public void InterfaceImplementationTests(Type interfaceType, bool shouldImplement)
    {
        AssertInterfaceImplementation(interfaceType, shouldImplement);
    }
}
