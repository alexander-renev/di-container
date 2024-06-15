using System.Collections.Frozen;
using Renev.DependencyInjection.Container.Implementation.Registrations;

namespace Renev.DependencyInjection.Container.Implementation;

internal sealed class ServiceProvider : IServiceProvider
{
    private readonly FrozenDictionary<Type, Func<object>> registrations;
    public ServiceProvider(List<IRegistration> registrations)
    {
        var factory = new Dictionary<Type, Func<object>>();
        foreach (var registration in registrations)
        {
            if (registration.Lifetime == Lifetime.Singleton)
            {
                var container = new Lazy<object>(registration.Factory, LazyThreadSafetyMode.ExecutionAndPublication);
                factory[registration.Type] = () => container.Value;
            }
            else if (registration.Lifetime == Lifetime.Transient)
            {
                factory[registration.Type] = registration.Factory;
            }
            else
            {
                throw new InvalidOperationException($"Unsupported lifetime {registration.Lifetime}");
            }
        }

        this.registrations = factory.ToFrozenDictionary();
    }

    public T Resolve<T>()
    {
        if (registrations.TryGetValue(typeof(T), out var factory))
        {
            return (T)factory();
        }

        throw new InvalidOperationException($"No registration for {typeof(T).FullName}");
    }
}
