using RealTimeChartApp.Server.Models;

namespace RealTimeChartApp.Server.Services;

public class TimeSerieGenerator
{
    public static List<TimeSerie> GetNewData()
    {
        var r = new Random();
        return new List<TimeSerie>()
        {
            new TimeSerie{
                Data = new List<DataPoint> { new DataPoint { DateTime=DateTime.UtcNow, Value = r.NextDouble()} },
                Name = "TS1"
            }
        };
    }
}
