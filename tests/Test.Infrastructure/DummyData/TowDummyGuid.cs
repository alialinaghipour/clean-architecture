using System.Reflection;
using Xunit.Sdk;

namespace Test.Infrastructure.DummyData;

public class TowDummyGuid : DataAttribute
{
    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        var firstGuid = "eef9414e-ea30-4ada-8c4f-ac19dea8da8d";
        var secondGuid = "73d43fb6-84f4-49e2-810d-fb678bb6c5c5";
        return new[]
        {
            new object[] {firstGuid, secondGuid}
        };
    }
}