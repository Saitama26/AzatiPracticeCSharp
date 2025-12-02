namespace Day8.EventVersion.DataModels;

public class EventWeatherData
{
    private readonly object _lock = new();
    private float _temperature;
    private float _humidity;
    private float _pressure;

    public event EventHandler<WeatherInfoEventArgs>? TemperatureChanged;
    public event EventHandler<WeatherInfoEventArgs>? HumidityChanged;
    public event EventHandler<WeatherInfoEventArgs>? PressureChanged;
    
    public float Temperature
    {
        get { lock (_lock) { return _temperature; } }
        set
        {
            ValidateTemperature(value);
            WeatherInfoEventArgs args;
            lock (_lock)
            {
                _temperature = value;
                args = new WeatherInfoEventArgs(DateTime.UtcNow, _temperature, _humidity, _pressure);
            }
            TemperatureChanged?.Invoke(this, args);
        }
    }

    public float Humidity
    {
        get { lock (_lock) { return _humidity; } }
        set
        {
            ValidateHumidity(value);
            WeatherInfoEventArgs args;
            lock (_lock)
            {
                _humidity = value;
                args = new WeatherInfoEventArgs(DateTime.UtcNow, _temperature, _humidity, _pressure);
            }
            HumidityChanged?.Invoke(this, args);
        }
    }

    public float Pressure
    {
        get { lock (_lock) { return _pressure; } }
        set
        {
            ValidatePressure(value);
            WeatherInfoEventArgs args;
            lock (_lock)
            {
                _pressure = value;
                args = new WeatherInfoEventArgs(DateTime.UtcNow, _temperature, _humidity, _pressure);
            }
            PressureChanged?.Invoke(this, args);
        }
    }

    private static void ValidateTemperature(float value)
    {
        if (value < -273.15f)
            throw new ArgumentOutOfRangeException(nameof(Temperature), "Temperature cannot be below -273.15°C (absolute zero).");
        if (value > 1000f)
            throw new ArgumentOutOfRangeException(nameof(Temperature), "Temperature exceeds the reasonable upper limit.");
    }

    private static void ValidateHumidity(float value)
    {
        if (value < 0f || value > 100f)
            throw new ArgumentOutOfRangeException(nameof(Humidity), "Humidity must be in the range [0%, 100%].");
    }

    private static void ValidatePressure(float value)
    {
        if (value < 300f || value > 1200f)
            throw new ArgumentOutOfRangeException(nameof(Pressure), "Pressure must be in the range [300, 1100] hPa.");
    }
}