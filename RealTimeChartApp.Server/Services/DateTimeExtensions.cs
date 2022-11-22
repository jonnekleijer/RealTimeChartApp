namespace RealTimeChartApp.Server.Services;

public static class DateTimeExtentions
{
    public static DateTime RoundHour(this DateTime dateTime)
    {
        var updated = dateTime.AddMinutes(30);
        return new DateTime(updated.Year, updated.Month, updated.Day,
                             updated.Hour, 0, 0, dateTime.Kind);
    }
}