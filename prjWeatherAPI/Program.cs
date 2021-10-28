using Newtonsoft.Json.Linq;
using System;
using System.IO;

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
                    Console.WriteLine("\nCheck again? (Enter 'Y' to check again. Any other key to finish program.)");

                    if (Console.ReadLine().ToLower() == "y")
                    {
                        success = false;
                        Console.Clear();
                    }
                    else
                    {
                        success = true;
                    }
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

            City c = new City(CityName);

            Console.WriteLine($"\nCity Name: {c.Name}\n" +
                $"Current Temp: {c.Temp}\n" +
                $"Feels Like: {c.RealFeel}\n" +
                $"Min/Max Temps: {c.Min}/{c.Max}\n" +
                $"Current Humidity: {c.Humidity}\n" +
                $"Current Wind Speed: {c.Wind}\n" +
                $"Description: {c.Description}");
        }
    }
}
