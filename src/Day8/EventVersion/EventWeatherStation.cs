using Day8.Helpers;

namespace Day8.EventVersion;

public class EventWeatherStation
{
    public event EventHandler<WeatherInfoEventArgs>? WeatherChanged;

    public void UpdateData(float temperature, float humidity, float pressure)
    {
        if (float.IsNaN(temperature) || float.IsNaN(humidity) || float.IsNaN(pressure) ||
            float.IsInfinity(temperature) || float.IsInfinity(humidity) || float.IsInfinity(pressure))
        {
            throw new NotFiniteNumberException("Entered data is incorrect. Data can't be NaN or Infinity.");
        }

        WeatherChanged?.Invoke(this, new WeatherInfoEventArgs(temperature, humidity, pressure));
    }
}