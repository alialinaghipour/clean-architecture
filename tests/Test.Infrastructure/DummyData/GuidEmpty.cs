using System.Reflection;
using Xunit.Sdk;

namespace Test.Infrastructure.DummyData;

public class GuidEmpty : DataAttribute
{
    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        return new[] {new object[] {"00000000-0000-0000-0000-000000000000"}};
    }
}