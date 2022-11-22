using RealTimeChartApp.Server.Models;

namespace RealTimeChartApp.Server.Services;

public class TimeSerieGenerator
{
    readonly List<TimeSpan> times = Enumerable.Range(1, 8).Select(x => new TimeSpan(x, 0, 0)).ToList();

    public List<TimeSerie> GetNewData()
    {
        return new List<TimeSerie>()
        {
            new TimeSerie{
                Data = GetTimeSeries(),
                Name = "TimeSeries"
            }
        };
    }

    private ICollection<DataPoint> GetTimeSeries()
    {
        var now = DateTime.UtcNow.RoundHour();
        var r = new Random();

        return times
            .Select(t => new DataPoint { X = now - t, Y = r.NextDouble() })
            .OrderBy(t => t.X)
            .ToList();
    }
}
