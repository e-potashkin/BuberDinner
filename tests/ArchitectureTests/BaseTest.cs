using System.Reflection;
using BuildingBlocks.Domain.Models;

namespace ArchitectureTests;

public abstract class BaseTest
{
    protected static readonly Assembly DomainAssembly = typeof(Entity<>).Assembly;
}
