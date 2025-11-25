using Day8.EventVersion;
using Day8.ObserverVersion.Implementations;

namespace Day8;

public class Program
{
    static void Main()
    {
        // Event pattern
        var eventWeatherStation = new EventWeatherStation();

        var currentReport = new EventCurrentConditionsReport();
        var statisticReport = new EventStatisticReport();

        currentReport.Subscribe(eventWeatherStation);
        statisticReport.Subscribe(eventWeatherStation);

        // simulating data entry
        eventWeatherStation.UpdateData(-15, 25, 1112);
        eventWeatherStation.UpdateData(-1, 35, 1060);
        eventWeatherStation.UpdateData(5, 50, 1015);

        // Observer pattern
        var observableWeatherStation = new ObservableWeatherStation();

        var observerCurrentReport = new ObserverCurrentConditionsReport();
        var observerStatisticReport = new ObserverStatisticReport();

        observableWeatherStation.AddObserver(observerCurrentReport);
        observableWeatherStation.AddObserver(observerStatisticReport);

        // simulating data entry
        observableWeatherStation.UpdateData(20, 50, 1012);
        observableWeatherStation.UpdateData(33, 60, 960);
        observableWeatherStation.UpdateData(40, 80, 915);
    }
}
