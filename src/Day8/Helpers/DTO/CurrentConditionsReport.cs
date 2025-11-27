using System.Globalization;

namespace Day8.Helpers.DTO;

public class CurrentConditionsReport
{
    public float Temperature { get; set; }
    public float Humidity { get; set; }
    public float Pressure { get; set; }
    public DateTime LastModifiedWeatherTime { get; set; }

    public override string ToString()
    {
        var c = CultureInfo.InvariantCulture;
        return $"Current Condition ({LastModifiedWeatherTime:o}): " +
               $"T={Temperature.ToString("F2", c)}°C, " +
               $"H={Humidity.ToString("F2", c)}%, " +
               $"P={Pressure.ToString("F2", c)} hPa";
    }
}