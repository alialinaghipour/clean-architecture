namespace Infrastructure;

public static class StringTools
{
    public static string FixedText(this string text)
    {
        return text.Trim().ToLower();
    }
}