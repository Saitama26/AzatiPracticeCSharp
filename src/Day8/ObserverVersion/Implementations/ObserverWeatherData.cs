using Day8.ObserverVersion.Interfaces;

namespace Day8.ObserverVersion.Implementations;

public class ObserverWeatherData : IObservable
{
    private readonly List<IObserver> _observers = new();
    private float _temperature;
    private float _humidity;
    private float _pressure;
    private bool _initializedTemperature;
    private bool _initializedHumidity;
    private bool _initializedPressure;

    public float Temperature
    {
        get => _temperature;
        set
        {
            if (value < -100 || value > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(Temperature));
            }

            _temperature = value;
            _initializedTemperature = true;
            NotifyObservers();
        }
    }

    public float Humidity
    {
        get => _humidity;
        set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(Humidity));
            }
            
            _humidity = value;
            _initializedHumidity = true;
            NotifyObservers();
        }
    }

    public float Pressure
    {
        get => _pressure;
        set
        {
            if (value < 800 || value > 1200)
            {
                throw new ArgumentOutOfRangeException(nameof(Pressure));
            }

            _pressure = value;
            _initializedPressure = true;
            NotifyObservers();
        }
    }

    public void AddObserver(IObserver observer) => _observers.Add(observer);
 
    public void RemoveObserver(IObserver observer) => _observers.Remove(observer);
    
    public void NotifyObservers()
    {
        if (_initializedTemperature && _initializedHumidity && _initializedPressure)
        {
            var info = new WeatherInfo(DateTime.UtcNow, _temperature, _humidity, _pressure);
            foreach (var observer in _observers)
                observer.Update(info);

            _initializedTemperature = _initializedHumidity = _initializedPressure = false;
        }
    }
}