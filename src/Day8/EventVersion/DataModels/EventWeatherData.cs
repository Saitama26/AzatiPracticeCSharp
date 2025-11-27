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
            ValidateTemperature(value);
            _temperature = value;

            TemperatureChanged?.Invoke(this, new WeatherInfoEventArgs(DateTime.UtcNow, _temperature, _humidity, _pressure));
        }
    }

    public float Humidity
    {
        get => _humidity;
        set
        {
            ValidateHumidity(value);
            _humidity = value;

            HumidityChanged?.Invoke(this, new WeatherInfoEventArgs(DateTime.UtcNow, _temperature, _humidity, _pressure));
        }
    }

    public float Pressure
    {
        get => _pressure;
        set
        {
            ValidatePressure(value);
            _pressure = value;

            PressureChanged?.Invoke(this, new WeatherInfoEventArgs(DateTime.UtcNow, _temperature, _humidity, _pressure));
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