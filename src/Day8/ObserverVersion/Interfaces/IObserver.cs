using Day8.Helpers;

namespace Day8.ObserverVersion.Interfaces;

public interface IObserver
{
    void Update(WeatherInfoEventArgs weatherInfo);
}
