namespace Renev.DependencyInjection.Container.Implementation.Registrations;

internal sealed class DefaultConstructorRegistration : IRegistration
{
    public DefaultConstructorRegistration(Lifetime lifetime, Type type)
    {
        Lifetime = lifetime;
        Type = type;
        Factory = () => Activator.CreateInstance(type);
    }

    public Lifetime Lifetime { get; }
    
    public Type Type { get; }
    
    public Func<Object> Factory { get; }
}
