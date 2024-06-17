using Renev.DependencyInjection.Container.Implementation;
using Renev.DependencyInjection.Container.Implementation.Registrations;

namespace Renev.DependencyInjection.Container;

public sealed class ContainerBuilder
{
    private readonly List<IRegistration> Registrations = new();
    
    public ContainerBuilder AddSingleton<T>()
        where T : class
    {
        Registrations.Add(new ConstructorRegistration(Lifetime.Singleton, typeof(T)));
        return this;
    }
    
    public ContainerBuilder AddTransient<T>()
        where T : class
    {
        Registrations.Add(new ConstructorRegistration(Lifetime.Transient, typeof(T)));
        return this;
    }
    
    public ContainerBuilder AddSingleton<TContract, TImplementation>()
        where TContract : class
        where TImplementation: class, TContract
    {
        Registrations.Add(new ConstructorRegistration(Lifetime.Singleton, typeof(TContract), typeof(TImplementation)));
        return this;
    }
    
    public ContainerBuilder AddTransient<TContract, TImplementation>()
        where TContract : class
        where TImplementation: class, TContract
    {
        Registrations.Add(new ConstructorRegistration(Lifetime.Transient, typeof(TContract), typeof(TImplementation)));
        return this;
    }
    
    public IServiceProvider Build()
    {
        return new ServiceProvider(Registrations);
    }
}
