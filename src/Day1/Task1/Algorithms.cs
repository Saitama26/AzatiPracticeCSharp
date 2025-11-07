namespace Day1.Task1_2;

public static partial class Algorithms
{
    /// <summary>
    /// Calculates the n-th root of a number with the given precision
    /// using Newton's method.
    /// </summary>
    /// <param name="value">The number to extract the root from.</param>
    /// <param name="degree">The degree of the root (must be positive).</param>
    /// <param name="accuracy">Number of decimal places for the result.</param>
    /// <returns>
    /// The n-th root of <paramref name="num"/> truncated to the specified accuracy.
    /// </returns>
    /// <exception cref="ArgumentException">
    /// Thrown if <paramref name="num"/> is NaN.
    /// </exception>
    /// <exception cref="Exception">
    /// Thrown if <paramref name="n"/> is not positive or if trying to
    /// compute an even root of a negative number.
    /// </exception>
    public static double FindNthRoot(double value, int degree, int accuracy = 1)
    {
        if (value == 0) return 0;
        if (double.IsNaN(value))
            throw new ArgumentException("Value must not be NaN", nameof(value));

        if (degree < 0)
            throw new ArgumentOutOfRangeException(nameof(degree), "Degree must be positive");

        if (accuracy < 0)
            throw new ArgumentOutOfRangeException(nameof(accuracy), "Accuracy must be positive");

        if (double.IsInfinity(value))
            throw new ArgumentException("Value must not be infinity", nameof(value));

        if (value < 0 && degree % 2 == 0)
            throw new ArgumentException("Cannot compute even root of a negative number", nameof(value));


        double x = value > 1 ? value : 1;
        double prev = 0;
        double eps = Math.Pow(10, -accuracy);

        do
        {
            prev = x;
            x = ((degree - 1) * x + value / Math.Pow(x, degree - 1)) / degree;

        } while (Math.Abs(x - prev) > eps);

        return x.RoundDown(accuracy);
    }

    private static double RoundDown(this double value, int digits)
    {
        var factor = Math.Pow(10, digits);

        return Math.Truncate(value * factor) / factor;
    }
}
