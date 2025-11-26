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
        return $"Statistic ({From} - {To}): Average T={AverageTemperature}, H={AverageHumidity}, P={AveragePressure}";
    }
}
