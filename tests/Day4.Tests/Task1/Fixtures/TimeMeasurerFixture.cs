using Day4.Task1.Implementation;

namespace Day4.Tests.Task1.Fixtures;

public class TimeMeasurerFixture : IDisposable
{
    private readonly string _tempLogFile;

    public ConsoleTimeMeasurer ConsoleMeasurer { get; }
    public FileLoggingTimeMeasurer FileMeasurer { get; }
    public string LogFilePath => _tempLogFile;

    public TimeMeasurerFixture()
    {
        _tempLogFile = Path.GetTempFileName();
        ConsoleMeasurer = new ConsoleTimeMeasurer();
        FileMeasurer = new FileLoggingTimeMeasurer(_tempLogFile);
    }

    public void Dispose()
    {
        if (File.Exists(_tempLogFile))
        {
            File.Delete(_tempLogFile);
        }
    }
}
