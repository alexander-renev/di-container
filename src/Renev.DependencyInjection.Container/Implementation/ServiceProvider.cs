using System.Collections.Frozen;
using Renev.DependencyInjection.Container.Implementation.Registrations;

namespace Renev.DependencyInjection.Container.Implementation;

internal sealed class ServiceProvider : IServiceProvider
{
    private readonly FrozenDictionary<Type, Func<object>> _registrations;
    public ServiceProvider(List<IRegistration> registrations)
    {
        var factory = new Dictionary<Type, Func<object>>();
        foreach (var registration in registrations)
        {
            switch (registration)
            {
                case DefaultConstructorRegistration def:
                    var container = new Lazy<object>(() => Activator.CreateInstance(def.Type),
                        LazyThreadSafetyMode.ExecutionAndPublication);
                    factory[def.Type] = () => container.Value;
                    break;
                default:
                    throw new InvalidOperationException($"Unsupported registration {registration.GetType().FullName}");
            }
        }

        _registrations = factory.ToFrozenDictionary();
    }

    public T Resolve<T>()
    {
        if (_registrations.TryGetValue(typeof(T), out var factory))
        {
            return (T)factory();
        }

        throw new InvalidOperationException($"No registration for {typeof(T).FullName}");
    }
}
