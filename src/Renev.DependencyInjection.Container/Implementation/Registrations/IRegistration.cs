namespace Renev.DependencyInjection.Container.Implementation.Registrations;

internal interface IRegistration
{
    Lifetime Lifetime { get; }
    
    Type Type { get; }
    
    Func<IServiceProvider, object> Factory { get; }
}
