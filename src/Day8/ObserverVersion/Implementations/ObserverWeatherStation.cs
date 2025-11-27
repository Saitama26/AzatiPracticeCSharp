using Day8.Helpers.DTO;
using Day8.Helpers.Services;
using Day8.ObserverVersion.Interfaces;

namespace Day8.ObserverVersion.Implementations;

public class ObserverWeatherStation : IObserver
{
    private ObserverWeatherData _WeatherData;
    private StatisticReportService _statisticService;

    public CurrentConditionsReport WeatherReport { get; private set; }

    public ObserverWeatherStation(ObserverWeatherData weatherData)
    {
        _WeatherData = weatherData;
        _statisticService = new StatisticReportService();
        WeatherReport = new CurrentConditionsReport();

        weatherData.AddObserver(this);
    }

    public void Update(WeatherInfo info)
    {
        WeatherReport.Temperature = info.Temperature;
        WeatherReport.Humidity = info.Humidity;
        WeatherReport.Pressure = info.Pressure;
        WeatherReport.LastModifiedWeatherTime = info.Timestamp;


        _statisticService.AddTemperature(info.Temperature);
        _statisticService.AddHumidity(info.Humidity);
        _statisticService.AddPressure(info.Pressure);
    }

    public StatisticReport GetStatisticReport(DateTime from, DateTime to)
    {
        return _statisticService.GetStatisticReport(from, to);
    }
}