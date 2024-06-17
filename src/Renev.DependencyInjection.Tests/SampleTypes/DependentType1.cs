namespace Renev.DependencyInjection.Tests.SampleTypes;

public class DependentType1 : IDependentType1
{
    public IDefaultConstructorType1 DefaultConstructorType1 { get; }

    public DependentType1(IDefaultConstructorType1 defaultConstructorType1)
    {
        DefaultConstructorType1 = defaultConstructorType1;
    }
}
