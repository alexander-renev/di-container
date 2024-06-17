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
        
        provider.Resolve<DefaultConstructorType1>().Should().BeSameAs(obj1);
        provider.Resolve<DefaultConstructorType2>().Should().BeSameAs(obj2);
    }
    
    [Fact]
    public void RegisterTransientWithDefaultConstructor_CreatesTransientObject()
    {
        var builder = new ContainerBuilder();
        builder.AddTransient<DefaultConstructorType1>();
        builder.AddTransient<DefaultConstructorType2>();
        var provider = builder.Build();

        var obj1 = provider.Resolve<DefaultConstructorType1>();
        var obj2 = provider.Resolve<DefaultConstructorType2>();

        obj1.Should().NotBeNull();
        obj2.Should().NotBeNull();

        provider.Resolve<DefaultConstructorType1>().Should().NotBeSameAs(obj1);
        provider.Resolve<DefaultConstructorType2>().Should().NotBeSameAs(obj2);
        
        provider.Resolve<DefaultConstructorType1>().Should().NotBeSameAs(obj1);
        provider.Resolve<DefaultConstructorType2>().Should().NotBeSameAs(obj2);
    }
    
    [Fact]
    public void RegisterSingletonByInterfaceWithDefaultConstructor_CreatesSingletonObject()
    {
        var builder = new ContainerBuilder();
        builder.AddSingleton<IDefaultConstructorType1, DefaultConstructorType1>();
        builder.AddSingleton<IDefaultConstructorType2, DefaultConstructorType2>();
        var provider = builder.Build();

        var obj1 = provider.Resolve<IDefaultConstructorType1>();
        var obj2 = provider.Resolve<IDefaultConstructorType2>();

        obj1.Should().NotBeNull();
        obj2.Should().NotBeNull();

        provider.Resolve<IDefaultConstructorType1>().Should().BeSameAs(obj1);
        provider.Resolve<IDefaultConstructorType2>().Should().BeSameAs(obj2);
        
        provider.Resolve<IDefaultConstructorType1>().Should().BeSameAs(obj1);
        provider.Resolve<IDefaultConstructorType2>().Should().BeSameAs(obj2);
    }
    
    [Fact]
    public void RegisterSingletonByInterfaceWithDefaultConstructor_CreatesTransientObject()
    {
        var builder = new ContainerBuilder();
        builder.AddTransient<IDefaultConstructorType1, DefaultConstructorType1>();
        builder.AddTransient<IDefaultConstructorType2, DefaultConstructorType2>();
        var provider = builder.Build();

        var obj1 = provider.Resolve<IDefaultConstructorType1>();
        var obj2 = provider.Resolve<IDefaultConstructorType2>();

        obj1.Should().NotBeNull();
        obj2.Should().NotBeNull();

        provider.Resolve<IDefaultConstructorType1>().Should().NotBeSameAs(obj1);
        provider.Resolve<IDefaultConstructorType2>().Should().NotBeSameAs(obj2);
        
        provider.Resolve<IDefaultConstructorType1>().Should().NotBeSameAs(obj1);
        provider.Resolve<IDefaultConstructorType2>().Should().NotBeSameAs(obj2);
    }
    
    [Fact]
    public void RegisterDependentObjects_CreatesDependencies()
    {
        var builder = new ContainerBuilder();
        builder.AddTransient<IDefaultConstructorType1, DefaultConstructorType1>();
        builder.AddTransient<IDefaultConstructorType2, DefaultConstructorType2>();
        builder.AddTransient<IDependentType1, DependentType1>();
        builder.AddTransient<IDependentType2, DependentType2>();
        var provider = builder.Build();

        var obj1 = provider.Resolve<IDependentType1>();
        var obj2 = provider.Resolve<IDependentType2>();

        obj1.Should().NotBeNull();
        obj2.Should().NotBeNull();

        provider.Resolve<IDependentType1>().Should().NotBeSameAs(obj1);
        provider.Resolve<IDependentType2>().Should().NotBeSameAs(obj2);
        
        provider.Resolve<IDependentType1>().Should().NotBeSameAs(obj1);
        provider.Resolve<IDependentType2>().Should().NotBeSameAs(obj2);
    }
    
    [Fact]
    public void RegisterDependentSingletonObjects_CreatesDependencies()
    {
        var builder = new ContainerBuilder();
        builder.AddSingleton<IDefaultConstructorType1, DefaultConstructorType1>();
        builder.AddSingleton<IDefaultConstructorType2, DefaultConstructorType2>();
        builder.AddSingleton<IDependentType1, DependentType1>();
        builder.AddSingleton<IDependentType2, DependentType2>();
        var provider = builder.Build();

        var obj1 = provider.Resolve<IDependentType1>();
        var obj2 = provider.Resolve<IDependentType2>();

        obj1.Should().NotBeNull();
        obj2.Should().NotBeNull();

        provider.Resolve<IDependentType1>().DefaultConstructorType1.Should().BeSameAs(provider.Resolve<IDefaultConstructorType1>());
        provider.Resolve<IDependentType2>().DependentType1.DefaultConstructorType1.Should().BeSameAs(provider.Resolve<IDefaultConstructorType1>());
    }
}
