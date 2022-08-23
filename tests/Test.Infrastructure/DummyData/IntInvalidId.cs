using System.Reflection;
using Xunit.Sdk;

namespace Test.Infrastructure.DummyData;

public class IntInvalidId : DataAttribute
{
    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        return new[] {new object[] {-1}};
    }
}