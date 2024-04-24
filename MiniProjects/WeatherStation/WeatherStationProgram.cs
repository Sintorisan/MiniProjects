using MiniProjects.WeatherStation.Db;

namespace MiniProjects.WeatherStation;

public class WeatherStationProgram
{
    private readonly TempDb _db = new TempDb();
    bool runProgram = true;
    public void StartWeatherStation()
    {
        while (runProgram)
        {
            Console.Clear();
            int choice = 0;
            Console.WriteLine("Welcome to the Weather Station!\r\nChoose an option:\r\n1. Record a Temperature\r\n2. Display Temperature Statistics\r\n3. Exit");
            Console.Write("Enter your choice: ");
            choice = int.Parse(Console.ReadLine());
            Console.Clear();
            WeatherStationManagement(choice);
        }
    }

    public void WeatherStationManagement(int choice)
    {
        switch (choice)
        {
            case 1:
                RecordTemperature();
                break;
            case 2:
                do
                {
                    Console.Write("Type in C for Celsius and F for Fahrenheit: ");
                    string? unit = Console.ReadLine();
                    if (unit.ToLower() == "c" || unit.ToLower() == "f")
                    {
                        DisplayTemperature(unit.ToLower());
                        break;
                    }

                } while (true);
                break;
            default:
                runProgram = false;
                break;
        }
    }

    public void RecordTemperature()
    {
        string todayDate = DateTime.Now.ToShortDateString();

        Console.Write("Enter highest temperature: ");
        double highestTemp = double.Parse(Console.ReadLine());
        Console.Write("Enter lowest temperature: ");
        double lowestTemp = double.Parse(Console.ReadLine());

        Console.Write($"On {todayDate} the highest temperature was {highestTemp} and the lowest temperature was {lowestTemp}");
        Console.ReadKey();

        var temp = new Temperature() { DateStamp = todayDate, HighestTemp = highestTemp, LowestTemp = lowestTemp };
        _db.RecordTemp(temp);
    }

    public void DisplayTemperature(string unit)
    {
        var averageTemp = unit == "c" ? Math.Round(_db.GetRecordsAverageCelsius(), 2) : Math.Round(_db.GetRecordsAverageFahrenheit(), 2);
        var temps = unit == "c" ? _db.GetAllRecordsCelsius() : _db.GetAllRecordsFahrenheit();

        Console.WriteLine($"The average temp for these temperaturs total of {temps.Count} records \n");
        foreach (var temp in temps)
        {
            Console.WriteLine($"Date: {temp.DateStamp}");
            Console.WriteLine($"Highest: {temp.HighestTemp}");
            Console.WriteLine($"Lowest: {temp.LowestTemp}");
            Console.WriteLine($"Average: {temp.AverageTemp} \n");
        }
        Console.WriteLine($"Total average temp: {averageTemp}");
        Console.ReadKey();
    }
}
