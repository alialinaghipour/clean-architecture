namespace Infrastructure.Cultures;

internal static class CultureManagement
{
    public static void Culture()
    {
        var culture = CultureInfo.GetCultureInfo("en-US");
        CultureInfo.CurrentCulture = culture;
        CultureInfo.CurrentUICulture = culture;
    }
}