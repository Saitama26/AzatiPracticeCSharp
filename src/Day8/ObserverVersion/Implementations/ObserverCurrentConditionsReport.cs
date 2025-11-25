using Day8.ObserverVersion.Interfaces;
using Day8.Helpers;

namespace Day8.ObserverVersion.Implementations;

public class ObserverCurrentConditionsReport : IObserver
{
    public void Update(WeatherInfoEventArgs data)
    {
        Console.WriteLine($"Observer Current conditions: T={data.Temperature}, H={data.Humidity}, P={data.Pressure}");
    }
}
