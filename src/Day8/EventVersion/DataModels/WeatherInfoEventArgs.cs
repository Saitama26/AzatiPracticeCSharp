using System.Globalization;

namespace Day8.EventVersion.DataModels;

public class WeatherInfoEventArgs
{
    public DateTime TimestampUtc { get; }
    public float Temperature { get; }
    public float Humidity { get; }
    public float Pressure { get; }

    public WeatherInfoEventArgs(DateTime timestampUtc, float temperature, float humidity, float pressure)
    {
        TimestampUtc = timestampUtc;
        Temperature = temperature;
        Humidity = humidity;
        Pressure = pressure;
    }

    public override string ToString()
    {
        var c = CultureInfo.InvariantCulture;
        return $"[{TimestampUtc:O}] T={Temperature.ToString("F2", c)}°C, H={Humidity.ToString("F2", c)}%, P={Pressure.ToString("F2", c)} hPa";
    }
}