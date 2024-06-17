using System.CodeDom.Compiler;
using System.Reflection;
using System.Reflection.Emit;
using Microsoft.CSharp;

namespace Renev.DependencyInjection.Container.Implementation.Registrations;

internal sealed class ConstructorRegistration : IRegistration
{
    public ConstructorRegistration(Lifetime lifetime, Type type)
    {
        Lifetime = lifetime;
        Type = type;
        Factory = CodeGenerationHelper.CreateConstructorFactory(type);
    }
    
    public ConstructorRegistration(Lifetime lifetime, Type contract, Type implementation)
    {
        Lifetime = lifetime;
        Type = contract;
        Factory = CodeGenerationHelper.CreateConstructorFactory(implementation);
    }

    public Lifetime Lifetime { get; }
    
    public Type Type { get; }
    
    public Func<IServiceProvider, object> Factory { get; }
}
