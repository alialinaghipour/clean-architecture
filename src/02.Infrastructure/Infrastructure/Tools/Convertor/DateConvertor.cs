namespace Infrastructure.Tools.Convertor;

public static class DateConvertor
{
    public static string ToShamsi(this DateTime value)
    {
        var persianCalendar = new PersianCalendar();
        var slash = "/";
        var date = new StringBuilder()
            .Append(persianCalendar.GetYear(value))
            .Append(slash)
            .Append(persianCalendar.GetMonth(value).ToString("00"))
            .Append(slash)
            .Append(persianCalendar.GetDayOfMonth(value).ToString("00"));
        return date.ToString();
    }
}