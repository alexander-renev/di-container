namespace Renev.DependencyInjection.Container;

public interface IServiceProvider
{
    T Resolve<T>();
}
