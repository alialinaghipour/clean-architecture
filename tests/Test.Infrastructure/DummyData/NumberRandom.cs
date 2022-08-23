using System.Reflection;
using Xunit.Sdk;

namespace Test.Infrastructure.DummyData;

public class NumberRandom : DataAttribute
{
    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        var value = new Random().Next(10);
        return new[] {new object[] {value}};
    }
}