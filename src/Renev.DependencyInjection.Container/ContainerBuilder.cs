using Renev.DependencyInjection.Container.Implementation;
using Renev.DependencyInjection.Container.Implementation.Registrations;

namespace Renev.DependencyInjection.Container;

public sealed class ContainerBuilder
{
    private readonly List<IRegistration> Registrations = new();
    
    public ContainerBuilder AddSingleton<T>()
    {
        Registrations.Add(new DefaultConstructorRegistration(Lifetime.Singleton, typeof(T)));
        return this;
    }
    
    public ContainerBuilder AddTransient<T>()
    {
        Registrations.Add(new DefaultConstructorRegistration(Lifetime.Transient, typeof(T)));
        return this;
    }
    
    public ContainerBuilder AddSingleton<TContract, TImplementation>()
    {
        Registrations.Add(new DefaultConstructorRegistration(Lifetime.Singleton, typeof(TContract), typeof(TImplementation)));
        return this;
    }
    
    public ContainerBuilder AddTransient<TContract, TImplementation>()
    {
        Registrations.Add(new DefaultConstructorRegistration(Lifetime.Transient, typeof(TContract), typeof(TImplementation)));
        return this;
    }
    
    public IServiceProvider Build()
    {
        return new ServiceProvider(Registrations);
    }
}
