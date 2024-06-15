namespace Renev.DependencyInjection.Container.Implementation.Registrations;

internal sealed class DefaultConstructorRegistration : IRegistration
{
    public DefaultConstructorRegistration(Lifetime lifetime, Type type)
    {
        Lifetime = lifetime;
        Type = type;
        Factory = _ => Activator.CreateInstance(type);
    }
    
    public DefaultConstructorRegistration(Lifetime lifetime, Type contract, Type implementation)
    {
        Lifetime = lifetime;
        Type = contract;
        Factory = _ => Activator.CreateInstance(implementation);
    }

    public Lifetime Lifetime { get; }
    
    public Type Type { get; }
    
    public Func<IServiceProvider, Object> Factory { get; }
}
