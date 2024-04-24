using MiniProjects.Library;
using MiniProjects.ProductPricingCalculator;
using MiniProjects.WeatherStation;

LibraryProgram libraryProgram = new LibraryProgram();
WeatherStationProgram weatherStationProgram = new WeatherStationProgram();
ProductPricingProgram productPricingProgram = new ProductPricingProgram();

List<string> projects = new List<string> { "Library Management System", "Weather Station", "Product Pricing Calculator" };

while (true)
{
    int projectNumber = 0;

    for (int i = 0; i < projects.Count; i++)
    {
        Console.WriteLine($"{i + 1}) {projects[i]} \n");
    }

    Console.Write("Choose the project you want to open: ");

    projectNumber = int.Parse(Console.ReadLine());

    switch (projectNumber)
    {
        case 1:
            libraryProgram.StartLibraryProgram();
            break;
        case 2:
            weatherStationProgram.StartWeatherStationProgram();
            break;
        case 3:
            productPricingProgram.StartProductPricingProgram();
            break;
        default:
            Console.WriteLine("Invalid Choice");
            break;
    }
}

