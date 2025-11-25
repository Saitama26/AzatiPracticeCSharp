using Day8.Helpers;
using Day8.ObserverVersion.Interfaces;

namespace Day8.ObserverVersion.Implementations;

public class ObserverStatisticReport : IObserver
{
    private List<float> _temperatures = new();

    public void Update(WeatherInfoEventArgs e)
    {
        _temperatures.Add(e.Temperature);
        Console.WriteLine($"Observer Statistics: Average T={_temperatures.Average()}, Max={_temperatures.Max()}, Min={_temperatures.Min()}");
    }
}