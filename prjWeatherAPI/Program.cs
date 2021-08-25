using Newtonsoft.Json.Linq;
using System;

namespace prjWeatherAPI
{
    class Program
    {
        static bool success = false;

        static void Main(string[] args)
        {
            while (!success)
            {
                try
                {
                    MainLoop();
                    success = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("An Error has occurred! Please try again!");
                    success = false;
                }
            }
        }

        public static void MainLoop()
        {
            Console.WriteLine("Enter City Name: ");
            string CityName = Console.ReadLine();

            Console.WriteLine("\n\n");

            City jCity = new City(CityName);

            Console.WriteLine($"City Name: {jCity.Name}\n" +
                $"Current Temp: {jCity.Temp}\n" +
                $"Feels Like: {jCity.RealFeel}\n" +
                $"Min/Max Temps: {jCity.Min}/{jCity.Max}\n" +
                $"Current Humidity: {jCity.Humidity}\n" +
                $"Current Wind Speed: {jCity.Wind}\n" +
                $"City Description: {jCity.Description}");
        }
    }
}
