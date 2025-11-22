using Day4.Task1.Interfaces;

namespace Day4.Task1.Implementation;

public class TimedGcdAlgorithm : IGcdAlgorithm
{
    private readonly IGcdAlgorithm _algorithm;
    private readonly ITimeMeasurer _timeMeasurer;

    public TimedGcdAlgorithm(IGcdAlgorithm algorithm, ITimeMeasurer timeMeasurer)
    {
        if (algorithm == null)
        {
            throw new ArgumentNullException($"{nameof(algorithm)} can't be null");
        }

        if(timeMeasurer == null )
        {
            throw new ArgumentNullException($"{nameof(timeMeasurer)} can't be null");
        }

        _algorithm = algorithm;
        _timeMeasurer = timeMeasurer;
    }

    public int Calculate(int first, int second)
    {
        var result = _timeMeasurer.Measure(() => _algorithm.Calculate(first, second));

        return result;
    }
}