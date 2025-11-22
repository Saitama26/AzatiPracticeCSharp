using Day4.Task1.Interfaces;
using System.Diagnostics;

namespace Day4.Task1.Implementation;

public class FileLoggingTimeMeasurer : ITimeMeasurer
{
    private readonly string _filePath;
    public FileLoggingTimeMeasurer(string filePath)
    {
        if (string.IsNullOrWhiteSpace(filePath))
        {
            throw new ArgumentException("File path must be provided.", nameof(filePath));
        }
        _filePath = filePath;
    }

    public T Measure<T>(Func<T> function)
    {
        if(function == null) 
        {
            throw new ArgumentNullException($"{nameof(function)} can't be null"); 
        }

        var sw = Stopwatch.StartNew();
        var result = function();
        sw.Stop();

        File.AppendAllText(_filePath, $"Execution took {(double)sw.ElapsedTicks / Stopwatch.Frequency * 1000} ms{Environment.NewLine}");
        
        return result;
    }
}