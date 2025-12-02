using Day8.ObserverVersion.Implementations;
using Day8.EventVersion.BusinessLogic;
using Day8.EventVersion.DataModels;

namespace Day8;

public class Program
{
    private static readonly Random _random = new();

    static async Task Main()
    {
        Console.WriteLine("=== Testing Thread Safety ===\n");

        await TestEventVersionThreadSafety();
        Console.WriteLine();
        await TestObserverVersionThreadSafety();
        
        Console.WriteLine("\n=== All tests completed successfully! ===");
    }

    static async Task TestEventVersionThreadSafety()
    {
        Console.WriteLine("--- Event Version Thread Safety Test ---");

        var eventWeatherData = new EventWeatherData();
        using var eventStation = new EventWeatherStation(eventWeatherData);

        var tasks = new List<Task>();
        var iterationsPerTask = 100;
        var taskCount = 10;

        for (int t = 0; t < taskCount; t++)
        {
            int taskId = t;
            tasks.Add(Task.Run(() =>
            {
                for (int i = 0; i < iterationsPerTask; i++)
                {
                    try
                    {
                        eventWeatherData.Temperature = _random.Next(-50, 100);
                        eventWeatherData.Humidity = _random.Next(0, 100);
                        eventWeatherData.Pressure = _random.Next(300, 1200);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[Event] Task {taskId} Error: {ex.Message}");
                    }
                }
            }));
        }

        for (int t = 0; t < 5; t++)
        {
            tasks.Add(Task.Run(() =>
            {
                for (int i = 0; i < iterationsPerTask; i++)
                {
                    var report = eventStation.GetStatisticReport(
                        DateTime.UtcNow.AddMinutes(-10), 
                        DateTime.UtcNow);
                }
            }));
        }

        await Task.WhenAll(tasks);

        Console.WriteLine($"[Event] Completed {taskCount * iterationsPerTask} writes from {taskCount} threads");
        Console.WriteLine($"[Event] Final report: {eventStation.WeatherReport}");
        Console.WriteLine($"[Event] Statistics: {eventStation.GetStatisticReport(DateTime.UtcNow.AddMinutes(-10), DateTime.UtcNow)}");
    }

    static async Task TestObserverVersionThreadSafety()
    {
        Console.WriteLine("--- Observer Version Thread Safety Test ---");

        var weatherData = new ObserverWeatherData();
        var stations = new List<ObserverWeatherStation>();

        // Создаём несколько станций-наблюдателей
        for (int i = 0; i < 5; i++)
        {
            stations.Add(new ObserverWeatherStation(weatherData));
        }

        var tasks = new List<Task>();
        var iterationsPerTask = 100;
        var taskCount = 10;

        // Запускаем несколько потоков для записи данных
        for (int t = 0; t < taskCount; t++)
        {
            int taskId = t;
            tasks.Add(Task.Run(() =>
            {
                for (int i = 0; i < iterationsPerTask; i++)
                {
                    try
                    {
                        weatherData.Temperature = _random.Next(-100, 100);
                        weatherData.Humidity = _random.Next(0, 100);
                        weatherData.Pressure = _random.Next(800, 1200);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[Observer] Task {taskId} Error: {ex.Message}");
                    }
                }
            }));
        }

        foreach (var station in stations)
        {
            tasks.Add(Task.Run(() =>
            {
                for (int i = 0; i < iterationsPerTask; i++)
                {
                    var report = station.GetStatisticReport(
                        DateTime.UtcNow.AddMinutes(-10), 
                        DateTime.UtcNow);
                }
            }));
        }

        tasks.Add(Task.Run(() =>
        {
            for (int i = 0; i < 20; i++)
            {
                var tempStation = new ObserverWeatherStation(weatherData);
                Thread.Sleep(10);
                tempStation.Dispose(); 
            }
        }));

        await Task.WhenAll(tasks);

        Console.WriteLine($"[Observer] Completed {taskCount * iterationsPerTask} writes from {taskCount} threads");
        Console.WriteLine($"[Observer] {stations.Count} stations received updates concurrently");

        foreach (var station in stations)
        {
            Console.WriteLine($"[Observer] Station report: {station.WeatherReport}");
            station.Dispose();
        }

        Console.WriteLine($"[Observer] Statistics: {stations[0].GetStatisticReport(DateTime.UtcNow.AddMinutes(-10), DateTime.UtcNow)}");
    }
}