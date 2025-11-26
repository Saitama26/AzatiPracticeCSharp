using Day8.ObserverVersion.Implementations;

namespace Day8.ObserverVersion.Interfaces;

public interface IObserver
{
    void Update(WeatherInfo weatherInfo);
}