namespace MiniProjects.WeatherStation.Db;

public class TempDb
{

    private readonly List<Temperature> _temps = new List<Temperature>();
    private const string _filePath = "TemperatureData.csv";

    public TempDb()
    {
        LoadTemperaturesFromFile();
    }

    private void LoadTemperaturesFromFile()
    {
        if (File.Exists(_filePath))
        {
            var lines = File.ReadAllLines(_filePath);
            foreach (var line in lines)
            {
                var data = line.Split(',');
                var temperature = new Temperature
                {
                    DateStamp = data[0],
                    HighestTemp = double.Parse(data[1]),
                    LowestTemp = double.Parse(data[2])
                };
                _temps.Add(temperature);
            }
        }
    }

    public void RecordTemp(Temperature temp)
    {
        _temps.Add(temp);
        File.AppendAllText(_filePath, $"{temp.DateStamp},{temp.HighestTemp},{temp.LowestTemp}\n");
    }


    public List<Temperature> GetAllRecordsCelsius() => _temps;

    public double GetRecordsAverageCelsius()
    {
        return _temps.Average(t => t.AverageTemp);
    }




    public List<Temperature> GetAllRecordsFahrenheit() => _temps
        .Select(t => new Temperature
        {
            DateStamp = t.DateStamp,
            HighestTemp = (t.HighestTemp * 9 / 5) + 32,
            LowestTemp = (t.LowestTemp * 9 / 5) + 32
        }).ToList();

    public double GetRecordsAverageFahrenheit()
    {
        return GetAllRecordsFahrenheit().Average(t => t.AverageTemp);
    }


}
