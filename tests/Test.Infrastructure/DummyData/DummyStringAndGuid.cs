using System.Reflection;
using Xunit.Sdk;

namespace Test.Infrastructure.DummyData;

public class DummyStringAndGuid : DataAttribute
{
    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        var guid = "eef9414e-ea30-4ada-8c4f-ac19dea8da8d";
        return new[]
        {
            new object[] {"dummy_string", guid}
        };
    }
}