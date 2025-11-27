using System.Globalization;

namespace Day8.Helpers.DTO;

public class StatisticReport
{
    public float AverageTemperature { get; set; }
    public float AverageHumidity { get; set; }
    public float AveragePressure { get; set; }
    public DateTime From { get; set; }
    public DateTime To { get; set; }

    public override string ToString()
    {
        var c = CultureInfo.InvariantCulture;
        return $"Statistic ({From:O} .. {To:O}): " +
               $"Avg T={AverageTemperature.ToString("F2", c)}°C, " +
               $"Avg H={AverageHumidity.ToString("F2", c)}%, " +
               $"Avg P={AveragePressure.ToString("F2", c)} hPa";
    }
}