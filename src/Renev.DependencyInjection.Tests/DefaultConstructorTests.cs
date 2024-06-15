﻿using FluentAssertions;
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
    public void RegisterSingletonWithDefaultConstructor_CreatesTransientObject()
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
}
