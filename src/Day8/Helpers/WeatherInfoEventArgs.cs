namespace Day8.Helpers;

public class WeatherInfoEventArgs
{
    public float Temperature { get; }
    public float Humidity { get; }
    public float Pressure { get; }

    public WeatherInfoEventArgs(float temperature, float humidity, float pressure)
    {
        Temperature = temperature;
        Humidity = humidity;
        Pressure = pressure;
    }
}