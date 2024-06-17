namespace Renev.DependencyInjection.Tests.SampleTypes;

public interface IDependentType2
{
    IDependentType1 DependentType1 { get; }
    IDefaultConstructorType1 DefaultConstructorType1 { get; }
}
