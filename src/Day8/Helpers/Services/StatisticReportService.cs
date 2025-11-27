using Day8.Helpers.DTO;

namespace Day8.Helpers.Services;

public class StatisticReportService
{
    private readonly List<(DateTime Time, float Value)> _temperatures = new();
    private readonly List<(DateTime Time, float Value)> _humidities = new();
    private readonly List<(DateTime Time, float Value)> _pressures = new();

    public void AddTemperature(float value) => _temperatures.Add((DateTime.Now, value));
    public void AddHumidity(float value) => _humidities.Add((DateTime.Now, value));
    public void AddPressure(float value) => _pressures.Add((DateTime.Now, value));

    public StatisticReport GetStatisticReport(DateTime from, DateTime to)
    {
        var temps = Filter(_temperatures, from, to);
        var hums = Filter(_humidities, from, to);
        var press = Filter(_pressures, from, to);

        return new StatisticReport
        {
            From = from,
            To = to,
            AverageTemperature = temps.Any() ? temps.Average() : 0,
            AverageHumidity = hums.Any() ? hums.Average() : 0,
            AveragePressure = press.Any() ? press.Average() : 0
        };
    }

    private IEnumerable<float> Filter(List<(DateTime Time, float Value)> list, DateTime from, DateTime to)
    {
        return list.Where(x => x.Time >= from && x.Time <= to).Select(x => x.Value);
    }
}