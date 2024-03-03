using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

class Program
{
    static async Task Main()
    {
        string apiKey = "23fc8d2219f9d6588a754f1eb875425b";

        Console.Write("Enter city name: ");
        string cityName = Console.ReadLine();

        string apiUrl = $"http://api.openweathermap.org/data/2.5/weather?q={cityName}&appid={apiKey}&units=metric";

        using (HttpClient client = new HttpClient())
        {
            try
            {
                string response = await client.GetStringAsync(apiUrl);

                dynamic weatherData = JObject.Parse(response);

                Console.WriteLine($"\nWeather in {weatherData.name}, {weatherData.sys.country}:");
                Console.WriteLine($"Description: {weatherData.weather[0].description}");
                Console.WriteLine($"Temperature: {weatherData.main.temp}°C");
                Console.WriteLine($"Humidity: {weatherData.main.humidity}%");
                Console.WriteLine($"Wind Speed: {weatherData.wind.speed} m/s");
            }
            catch (HttpRequestException)
            {
                Console.WriteLine("Error fetching weather data. Please check your input and try again.");
            }
        }
    }
}
