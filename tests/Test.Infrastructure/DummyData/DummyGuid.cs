using System.Reflection;
using Xunit.Sdk;

namespace Test.Infrastructure.DummyData;

public class DummyGuid : DataAttribute
{
    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        return new[] {new object[] {"73d43fb6-84f4-49e2-810d-fb678bb6c5c5"}};
    }
}