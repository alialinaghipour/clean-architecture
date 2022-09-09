using System.Reflection;
using Test.Infrastructure.Factory.Dummies;
using Xunit.Sdk;

namespace Test.Infrastructure.DummyData;

public class DummyTowString : DataAttribute
{
    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        var first = DummyFactory.GenerateDummyString();
        var second = DummyFactory.GenerateDummyString();
        return new[]
            {new object[] {first, second}};
    }
}