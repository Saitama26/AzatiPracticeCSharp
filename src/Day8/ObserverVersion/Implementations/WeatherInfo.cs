namespace Day8.ObserverVersion.Implementations;

public class WeatherInfo
{
    public float Temperature { get; }
    public float Humidity { get; }
    public float Pressure { get; }
    public DateTime Timestamp { get; }

    public WeatherInfo(float temperature, float humidity, float pressure)
    {
        Temperature = temperature;
        Humidity = humidity;
        Pressure = pressure;
        Timestamp = DateTime.Now;
    }
}