namespace Day8.EventVersion.DataModels;

public class EventWeatherData
{
    private float _temperature;
    private float _humidity;
    private float _pressure;

    public event EventHandler<WeatherInfoEventArgs>? TemperatureChanged;
    public event EventHandler<WeatherInfoEventArgs>? HumidityChanged;
    public event EventHandler<WeatherInfoEventArgs>? PressureChanged;
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

            TemperatureChanged?.Invoke(this, new WeatherInfoEventArgs(_temperature, _humidity, _pressure));
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

            HumidityChanged?.Invoke(this, new WeatherInfoEventArgs(_temperature, _humidity, _pressure));
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

            PressureChanged?.Invoke(this, new WeatherInfoEventArgs(_temperature, _humidity, _pressure));
        }
    }
}