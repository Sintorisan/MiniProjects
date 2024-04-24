namespace MiniProjects.WeatherStation.Db;

public class Temperature
{
    public string? DateStamp { get; set; }
    public double HighestTemp { get; set; }
    public double LowestTemp { get; set; }
    public double AverageTemp => (HighestTemp + LowestTemp) / 2;
}
