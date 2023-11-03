using FluentAssertions;
using NetArchTest.Rules;
using Xunit;

namespace ArchitectureTests;

public class LayerTest : BaseTest
{
    [Fact]
    public void DomainShouldNotHaveDependencyOnApplication()
    {
        var result = Types.InAssembly(DomainAssembly)
            .Should()
            .NotHaveDependencyOn("Application")
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }
}
