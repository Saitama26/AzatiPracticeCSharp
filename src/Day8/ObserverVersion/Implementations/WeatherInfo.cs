namespace Day8.ObserverVersion.Implementations;

public class WeatherInfo
{
    public float Temperature { get; }
    public float Humidity { get; }
    public float Pressure { get; }
    public DateTime Timestamp { get; }

    public WeatherInfo(DateTime dateTime, float temperature, float humidity, float pressure)
    {
        Timestamp = dateTime;
        Temperature = temperature;
        Humidity = humidity;
        Pressure = pressure;
    }
}