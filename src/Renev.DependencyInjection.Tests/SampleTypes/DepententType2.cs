namespace Renev.DependencyInjection.Tests.SampleTypes;

public class DependentType2 : IDependentType2
{
    public IDependentType1 DependentType1 { get; }
    public IDefaultConstructorType1 DefaultConstructorType1 { get; }

    public DependentType2(IDependentType1 dependentType1, IDefaultConstructorType1 defaultConstructorType1)
    {
        DependentType1 = dependentType1;
        DefaultConstructorType1 = defaultConstructorType1;
    }
}
