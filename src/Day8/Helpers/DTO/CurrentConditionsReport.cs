namespace Day8.Helpers.DTO;

public class CurrentConditionsReport
{
    public float Temperature { get; set; }
    public float Humidity { get; set; }
    public float Pressure { get; set; }
    public DateTime LastModifiedWeatherTime { get; set; }

    public override string ToString()
    {
        return $"Current conditions: T={Temperature} H={Humidity} P={Pressure}, updated {LastModifiedWeatherTime}";
    }
}