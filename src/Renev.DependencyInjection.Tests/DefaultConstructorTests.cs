using FluentAssertions;
using Renev.DependencyInjection.Container;
using Renev.DependencyInjection.Tests.SampleTypes;

namespace Renev.DependencyInjection.Tests;

public class DefaultConstructorTests
{
    [Fact]
    public void RegisterSingletonWithDefaultConstructor_CreatesSingletonObject()
    {
        var builder = new ContainerBuilder();
        builder.AddSingleton<DefaultConstructorType1>();
        builder.AddSingleton<DefaultConstructorType2>();
        var provider = builder.Build();

        var obj1 = provider.Resolve<DefaultConstructorType1>();
        var obj2 = provider.Resolve<DefaultConstructorType2>();

        obj1.Should().NotBeNull();
        obj2.Should().NotBeNull();

        provider.Resolve<DefaultConstructorType1>().Should().BeSameAs(obj1);
        provider.Resolve<DefaultConstructorType2>().Should().BeSameAs(obj2);
    }
}
