namespace Test.Infrastructure.Factory.Dummies;

public static class DummyFactory
{
    public static int GenerateInt()
    {
        var result = new Random(20).Next(15);
        return result;
    }
}