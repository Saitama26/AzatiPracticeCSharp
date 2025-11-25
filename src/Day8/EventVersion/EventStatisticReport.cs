using Day8.EventVersion;
using Day8.Helpers;

public class EventStatisticReport
{
    private readonly List<float> _temperatures = new();

    public void Subscribe(EventWeatherData data)
    {
        data.WeatherChanged += Update;
    }

    private void Update(object? sender, WeatherInfoEventArgs e)
    {
        _temperatures.Add(e.Temperature);
        Console.WriteLine($"Event Statistics: Average T={_temperatures.Average()}, Max={_temperatures.Max()}, Min={_temperatures.Min()}");
    }
}