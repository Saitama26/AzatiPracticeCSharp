using Day8.Helpers;
using Day8.ObserverVersion.Interfaces;

namespace Day8.ObserverVersion.Implementations;

public class ObservableWeatherStation : IObservable
{
    private readonly List<IObserver> _observers;
    private WeatherInfoEventArgs _weatherData;

    public ObservableWeatherStation()
    {
        _observers = new();
    }

    public void NotifyObservers()
    {
        foreach (var observer in _observers)
            observer.Update(_weatherData);
    }
    
    public void AddObserver(IObserver observer) => _observers.Add(observer);

    public void RemoveObserver(IObserver observer) => _observers.Remove(observer);

    public void UpdateData(float temperature, float humidity, float pressure)
    {
        if(float.IsNaN(temperature) || float.IsNaN(humidity) || float.IsNaN(pressure) ||
            float.IsInfinity(temperature) || float.IsInfinity(humidity) || float.IsInfinity(pressure))
        {
            throw new NotFiniteNumberException("Entered data is incorrect. Data can't be NaN or Infinity.");
        }

        _weatherData = new WeatherInfoEventArgs(temperature, humidity, pressure);
        NotifyObservers();
    }
}