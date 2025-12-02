using Day8.EventVersion.DataModels;
using Day8.Helpers.DTO;
using Day8.Helpers.Services;

namespace Day8.EventVersion.BusinessLogic;

public class EventWeatherStation : IDisposable
{
    private readonly EventWeatherData _weatherData;
    private readonly StatisticReportService _statisticService;

    public CurrentConditionsReport WeatherReport { get; private set; }

    public EventWeatherStation(EventWeatherData weatherData)
    {
        _weatherData = weatherData;
        _statisticService = new StatisticReportService();
        WeatherReport = new CurrentConditionsReport();

        _weatherData.TemperatureChanged += OnTemperatureChanged;
        _weatherData.HumidityChanged += OnHumidityChanged;
        _weatherData.PressureChanged += OnPressureChanged;
    }

    public StatisticReport GetStatisticReport(DateTime from, DateTime to)
    {
        return _statisticService.GetStatisticReport(from, to);
    }

    public void Dispose()
    {
        _weatherData.TemperatureChanged -= OnTemperatureChanged;
        _weatherData.HumidityChanged -= OnHumidityChanged;
        _weatherData.PressureChanged -= OnPressureChanged;
    }

    private void OnPressureChanged(object? sender, WeatherInfoEventArgs e)
    {
        WeatherReport.Pressure = e.Pressure;
        WeatherReport.LastModifiedWeatherTime = DateTime.UtcNow;
        _statisticService.AddPressure(e.Pressure);
    }

    private void OnHumidityChanged(object? sender, WeatherInfoEventArgs e)
    {
        WeatherReport.Humidity = e.Humidity;
        WeatherReport.LastModifiedWeatherTime = DateTime.UtcNow;
        _statisticService.AddHumidity(e.Humidity);
    }

    private void OnTemperatureChanged(object? sender, WeatherInfoEventArgs e)
    {
        WeatherReport.Temperature = e.Temperature;
        WeatherReport.LastModifiedWeatherTime = DateTime.UtcNow;
        _statisticService.AddTemperature(e.Temperature);
    }
}