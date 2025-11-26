using Day8.ObserverVersion.Implementations;
using Day8.EventVersion.BusinessLogic;
using Day8.EventVersion.DataModels;

namespace Day8;

public class Program
{
    static void Main()
    {
        // Event version
        var eventWeatherData = new EventWeatherData();
        var eventStation = new EventWeatherStation(eventWeatherData);

        // simulating data entry
        eventWeatherData.Temperature = 10;
        eventWeatherData.Humidity = 35;
        eventWeatherData.Pressure = 1100;

        Console.WriteLine(eventStation.WeatherReport.ToString());

        eventWeatherData.Temperature = 35;
        eventWeatherData.Humidity = 70;
        eventWeatherData.Pressure = 1199;

        Console.WriteLine(eventStation.WeatherReport.ToString());

        var eventReport = eventStation.GetStatisticReport(DateTime.Now.AddMinutes(-10), DateTime.Now);
        Console.WriteLine(eventReport.ToString());

        // Obverver pattern
        var weatherData = new ObserverWeatherData();
        var station = new ObserverWeatherStation(weatherData);

        // simulating data entry
        weatherData.Temperature = 20;
        weatherData.Humidity = 65;
        weatherData.Pressure = 1012;

        Console.WriteLine(station.WeatherReport.ToString());

        weatherData.Temperature = 22;
        weatherData.Humidity = 70;
        weatherData.Pressure = 1010;

        Console.WriteLine(station.WeatherReport.ToString());

        var report = station.GetStatisticReport(DateTime.Now.AddMinutes(-10), DateTime.Now);
        Console.WriteLine(report.ToString());
    }
}