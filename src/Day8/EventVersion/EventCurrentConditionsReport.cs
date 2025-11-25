using Day8.Helpers;

namespace Day8.EventVersion;

public class EventCurrentConditionsReport
{
    public void Subscribe(EventWeatherStation data)
    {
        data.WeatherChanged += Update;
    }

    private void Update(object? sender, WeatherInfoEventArgs e)
    {
        Console.WriteLine($"Event Current conditions: T={e.Temperature}, H={e.Humidity}, P={e.Pressure}");
    }
}