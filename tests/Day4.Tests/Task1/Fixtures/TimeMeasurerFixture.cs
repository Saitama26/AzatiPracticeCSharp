using Day4.Task1.Implementation;

namespace Day4.Tests.Task1.Fixtures;

public class TimeMeasurerFixture
{
    public ConsoleTimeMeasurer consoleMeasurer { get; }
    public FileLoggingTimeMeasurer fileMeasurer { get; }

    public TimeMeasurerFixture()
    {
        consoleMeasurer = new ConsoleTimeMeasurer();
        fileMeasurer = new FileLoggingTimeMeasurer("D:\\log.txt");
    }
}
