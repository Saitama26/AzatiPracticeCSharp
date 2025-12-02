using Day8.ObserverVersion.Interfaces;

namespace Day8.ObserverVersion.Implementations;

public class ObserverWeatherData : IObservable
{
    private readonly object _lock = new();
    private readonly List<IObserver> _observers = new();
    private float _temperature;
    private float _humidity;
    private float _pressure;

    public float Temperature
    {
        get { lock (_lock) { return _temperature; } }
        set
        {
            if (value < -100 || value > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(Temperature));
            }

            lock (_lock)
            {
                _temperature = value;
            }
            NotifyObservers();
        }
    }

    public float Humidity
    {
        get { lock (_lock) { return _humidity; } }
        set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(Humidity));
            }

            lock (_lock)
            {
                _humidity = value;
            }
            NotifyObservers();
        }
    }

    public float Pressure
    {
        get { lock (_lock) { return _pressure; } }
        set
        {
            if (value < 800 || value > 1200)
            {
                throw new ArgumentOutOfRangeException(nameof(Pressure));
            }

            lock (_lock)
            {
                _pressure = value;
            }
            NotifyObservers();
        }
    }

    public void AddObserver(IObserver observer)
    {
        lock (_lock)
        {
            _observers.Add(observer);
        }
    }

    public void RemoveObserver(IObserver observer)
    {
        lock (_lock)
        {
            _observers.Remove(observer);
        }
    }

    public void NotifyObservers()
    {
        WeatherInfo? info = null;
        IObserver[] observersCopy;

        lock (_lock)
        {
            info = new WeatherInfo(DateTime.UtcNow, _temperature, _humidity, _pressure);
            observersCopy = _observers.ToArray();
        }

        if (info != null)
        {
            foreach (var observer in observersCopy)
                observer.Update(info);
        }
    }
}