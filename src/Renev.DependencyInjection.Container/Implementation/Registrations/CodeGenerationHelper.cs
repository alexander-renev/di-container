using System.Reflection;
using System.Reflection.Emit;

namespace Renev.DependencyInjection.Container.Implementation.Registrations;

internal static class CodeGenerationHelper
{
    internal static Func<IServiceProvider, object> CreateDefaultConstructorFactory(Type implementation)
    {
        var name = "ProxyAssembly." + implementation.Assembly.GetName().Name + "." + Guid.NewGuid().ToString("N");
        var assembly = AssemblyBuilder.DefineDynamicAssembly(
            new AssemblyName(name),
            AssemblyBuilderAccess.Run);
        var module = assembly.DefineDynamicModule(name);
        var type = module.DefineType(name + "." + implementation.FullName + ".Factory");
        type.DefineDefaultConstructor(MethodAttributes.Public | MethodAttributes.HideBySig);
        var delegateMethod = type.DefineMethod("DelegateMethod",
            MethodAttributes.Private, CallingConventions.Standard, typeof(object),
            new[] { typeof(IServiceProvider) });
        var delegateMethodIl = delegateMethod.GetILGenerator();
        delegateMethodIl.Emit(OpCodes.Newobj, implementation.GetConstructors()[0]);
        delegateMethodIl.Emit(OpCodes.Ret);

        var factoryMethod = type.DefineMethod("FactoryMethod", MethodAttributes.Public,
            CallingConventions.Standard, typeof(Func<IServiceProvider, object>), []);
        var factoryMethodIl = factoryMethod.GetILGenerator();
        factoryMethodIl.Emit(OpCodes.Ldarg_0);
        factoryMethodIl.Emit(OpCodes.Ldftn, delegateMethod);
        factoryMethodIl.Emit(
            OpCodes.Newobj,
            typeof(Func<IServiceProvider, object>).GetConstructors()[0]);
        factoryMethodIl.Emit(OpCodes.Ret);

        var compiledType = type.CreateType();
        var instance = Activator.CreateInstance(compiledType);
        return (Func<IServiceProvider, Object>?)compiledType.GetMethod("FactoryMethod").Invoke(instance, []);
    }
}
