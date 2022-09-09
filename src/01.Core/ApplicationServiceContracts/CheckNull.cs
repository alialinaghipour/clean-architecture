namespace ApplicationContracts;

public static class CheckNull
{
    public static bool IsBlank(this object? value)
    {
        return value == null;
    }
}