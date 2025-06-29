using CodeCameleon.EfCoreToolkit.BaseEntities;
using CodeCameleon.EfCoreToolkit.EntityInterfaces;
using CodeCameleon.EfCoreToolkit.Tests.BaseFixtures;
using CodeCameleon.EfCoreToolkit.Tests.Models;
using NUnit.Framework;

namespace CodeCameleon.EfCoreToolkit.Tests.Entities;

/// <summary>
/// The test fixture for all <see cref="TemporaryEntity" /> related tests.
/// </summary>
internal class TemporaryEntityTests
    : BaseEntityTestFixture<TemporaryEntity, TestTemporaryEntity>
{
    /// <summary>
    /// Verifies whether <see cref="TemporaryEntity" /> correctly implements
    /// or does not implement the specified interface.
    /// </summary>
    /// <param name="interfaceType">The interface type to check.</param>
    /// <param name="shouldImplement">The value indicating whether the interface is expected to be implemented.</param>
    [TestCase(typeof(ICreatable), true, TestName = "Should Implement ICreatable")]
    [TestCase(typeof(IModifiable), false, TestName = "Should Not Implement IModifiable")]
    [TestCase(typeof(IHardDeletable), true, TestName = "Should Implement IHardDeletable")]
    [TestCase(typeof(ISoftDeletable), false, TestName = "Should Not Implement ISoftDeletable")]
    public void InterfaceImplementationTests(Type interfaceType, bool shouldImplement)
    {
        AssertInterfaceImplementation(interfaceType, shouldImplement);
    }
}
