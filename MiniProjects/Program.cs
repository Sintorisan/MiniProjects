using MiniProjects.Library;
using MiniProjects.WeatherStation;

LibraryProgram libraryProgram = new LibraryProgram();
WeatherStationProgram weatherStationProgram = new WeatherStationProgram();

List<string> projects = new List<string> { "Library Management System", "Weather Station" };

while (true)
{
    int projectNumber = 0;

    for (int i = 0; i < projects.Count; i++)
    {
        Console.WriteLine($"{i + 1}) {projects[i]}");
    }

    Console.Write("Choose the project you want to open: ");

    projectNumber = int.Parse(Console.ReadLine());

    switch (projectNumber)
    {
        case 1:
            libraryProgram.StartLibrary();
            break;
        case 2:
            weatherStationProgram.StartWeatherStation();
            break;
        default:
            Console.WriteLine("Invalid Choice");
            break;
    }
}

