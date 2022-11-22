using RealTimeChartApp.Server.Models;

namespace RealTimeChartApp.Server.Services;

public class TimeSerieGenerator
{
    private const int noOfDataPoints = 1000;
    readonly List<TimeSpan> times = Enumerable.Range(1, noOfDataPoints).Select(x => new TimeSpan(x, 0, 0)).ToList();

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
