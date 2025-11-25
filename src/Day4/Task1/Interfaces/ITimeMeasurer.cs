namespace Day4.Task1.Interfaces;

public interface ITimeMeasurer
{
    T Measure<T>(Func<T> function);
}