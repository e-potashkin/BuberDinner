using System.Reflection;
using BuildingBlocks.Domain.Models;
using FluentAssertions;
using NetArchTest.Rules;
using Xunit;

namespace ArchitectureTests.Domain;

/// <summary>
/// Just for example purposes, not a real test
/// </summary>
public class DomainTests : BaseTest
{
    [Fact]
    public void DomainEventsShouldBeSealed()
    {
        var result = Types.InAssembly(DomainAssembly)
            .That()
            .Inherit(typeof(DomainEvent))
            .Should()
            .BeSealed()
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void DomainEventsShouldHaveDomainEventPostfix()
    {
        var result = Types.InAssembly(DomainAssembly)
            .That()
            .Inherit(typeof(DomainEvent))
            .Should()
            .HaveNameEndingWith("DomainEvent")
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void EntitiesShouldHavePrivateParameterlessConstructor()
    {
        var entityTypes = Types.InAssembly(DomainAssembly)
            .That()
            .Inherit(typeof(Entity<>))
            .GetTypes();

        var failingTypes = new List<Type>();
        foreach (var entityType in entityTypes)
        {
            var constructors = entityType.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance);

#pragma warning disable S6605
            if (!constructors.Any(c => c.IsPrivate && c.GetParameters().Length == 0))
#pragma warning restore S6605
            {
                failingTypes.Add(entityType);
            }
        }

        failingTypes.Should().BeEmpty();
    }
}

