using Day8.Helpers.DTO;
using Day8.Helpers.Services;
using Day8.ObserverVersion.Interfaces;

namespace Day8.ObserverVersion.Implementations;

public class ObserverWeatherStation : IObserver, IDisposable
{
    private readonly object _lock = new();
    private readonly ObserverWeatherData _weatherData;
    private readonly StatisticReportService _statisticService;
    private bool _disposed;

    public CurrentConditionsReport WeatherReport { get; private set; }

    public ObserverWeatherStation(ObserverWeatherData weatherData)
    {
        _weatherData = weatherData ?? throw new ArgumentNullException(nameof(weatherData));
        _statisticService = new StatisticReportService();
        WeatherReport = new CurrentConditionsReport();

        _weatherData.AddObserver(this);
    }

    public void Update(WeatherInfo info)
    {
        lock (_lock)
        {
            if (_disposed) return;

            WeatherReport.Temperature = info.Temperature;
            WeatherReport.Humidity = info.Humidity;
            WeatherReport.Pressure = info.Pressure;
            WeatherReport.LastModifiedWeatherTime = info.Timestamp;

            _statisticService.AddTemperature(info.Temperature);
            _statisticService.AddHumidity(info.Humidity);
            _statisticService.AddPressure(info.Pressure);
        }
    }

    public StatisticReport GetStatisticReport(DateTime from, DateTime to)
    {
        lock (_lock)
        {
            return _statisticService.GetStatisticReport(from, to);
        }
    }

    public void Dispose()
    {
        lock (_lock)
        {
            if (_disposed) return;
            _disposed = true;
        }

        _weatherData.RemoveObserver(this);
    }
}