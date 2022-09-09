namespace Test.Infrastructure.Factory.Dummies;

public static class DummyFactory
{
    public static int GenerateDummyInt()
    {
        var result = new Random(20).Next(15);
        return result;
    }

    public static string GenerateDummyString()
    {
        return Guid.NewGuid().ToString("N");
    }
}