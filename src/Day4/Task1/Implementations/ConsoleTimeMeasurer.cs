using Day4.Task1.Interfaces;
using System.Diagnostics;

namespace Day4.Task1.Implementation;

public class ConsoleTimeMeasurer : ITimeMeasurer
{
    public T Measure<T>(Func<T> function)
    {
        if (function == null)
        {
            throw new ArgumentNullException($"{nameof(function)} can't be null");
        }

        var sw = Stopwatch.StartNew();
        var result = function();
        sw.Stop();

        Console.WriteLine($"Execution took {sw.ElapsedMilliseconds} ms{Environment.NewLine}");

        return result;
    }
}