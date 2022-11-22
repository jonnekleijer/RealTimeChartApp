namespace RealTimeChartApp.Server.Models;

public class TimeSerie
{
    public ICollection<DataPoint> Data { get; set; }
    public string Name { get; set; }
}
