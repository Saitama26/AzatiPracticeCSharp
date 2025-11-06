using System.Diagnostics;

namespace Day1.Task3;

public static class GCD
{
    /// <summary>
    /// Calculates the GCD (Greatest Common Divisor) of the specified integers using the Euclidean algorithm.
    /// </summary>
    /// <param name="first">The first integer.</param>
    /// <param name="second">The second integer.</param>
    /// <param name="others">Optional additional integers.</param>
    /// <returns>The GCD of all provided numbers.</returns>
    /// <exception cref="ArgumentException">Thrown if fewer than two values are provided.</exception>
    public static int GetGcdEuclidean(int first, int second, params int[] others)
    {
        var values = new int[others.Length + 2];
        values[0] = first;
        values[1] = second;
        Array.Copy(others, 0, values, 2, others.Length);

        if (values.All(v => v == 0))
            throw new ArgumentException("At least one value must be non-zero.", nameof(values));

        var gcd = values[0];
        for (int i = 1; i < values.Length; i++)
        {
            gcd = GetGcdEuclidean(gcd, values[i]);
        }
        return gcd;
    }

    /// <summary>
    /// Calculates the GCD of the specified integers using the Euclidean algorithm and measures execution time.
    /// </summary>
    /// <param name="first">The first integer.</param>
    /// <param name="second">The second integer.</param>
    /// <param name="elapsedMs">The elapsed time in milliseconds.</param>
    /// <param name="others">Optional additional integers.</param>
    /// <returns>The GCD of all provided numbers.</returns>
    /// <exception cref="ArgumentException">Thrown if fewer than two values are provided.</exception>
    public static int GetGcdEuclidean(int first, int second, out long elapsedMs, params int[] others)
    {
        var sw = Stopwatch.StartNew();
        var gcd = GetGcdEuclidean(first, second, others);
        sw.Stop();

        elapsedMs = sw.ElapsedMilliseconds;
        return gcd;
    }

    /// <summary>
    /// Calculates the GCD (Greatest Common Divisor) of the specified integers using Stein's algorithm (binary GCD).
    /// </summary>
    /// <param name="first">The first integer.</param>
    /// <param name="second">The second integer.</param>
    /// <param name="others">Optional additional integers.</param>
    /// <returns>The GCD of all provided numbers.</returns>
    /// <exception cref="ArgumentException">Thrown if fewer than two values are provided.</exception>
    public static int GetGcdStein(int first, int second, params int[] others)
    {
        var values = new int[others.Length + 2];
        values[0] = first;
        values[1] = second;
        Array.Copy(others, 0, values, 2, others.Length);

        if (values.All(v => v == 0))
            throw new ArgumentException("At least one value must be non-zero.", nameof(values));

        var gcd = values[0];
        for (int i = 1; i < values.Length; i++)
        {
            gcd = GetGcdStein(gcd, values[i]);
        }
        return gcd;
    }

    /// <summary>
    /// Calculates the GCD of the specified integers using Stein's algorithm (binary GCD) and measures execution time.
    /// </summary>
    /// <param name="first">The first integer.</param>
    /// <param name="second">The second integer.</param>
    /// <param name="elapsedMs">The elapsed time in milliseconds.</param>
    /// <param name="others">Optional additional integers.</param>
    /// <returns>The GCD of all provided numbers.</returns>
    /// <exception cref="ArgumentException">Thrown if fewer than two values are provided.</exception>
    public static int GetGcdStein(int first, int second, out long elapsedMs, params int[] others)
    {
        var sw = Stopwatch.StartNew();
        var gcd = GetGcdStein(first, second, others);
        sw.Stop();

        elapsedMs = sw.ElapsedMilliseconds;
        return gcd;
    }



    private static int GetGcdEuclidean(int a, int b)
    {
        long x = Math.Abs((long)a);
        long y = Math.Abs((long)b);

        while (x != 0 && y != 0)
        {
            if (x > y)
                x %= y;
            else
                y %= x;
        }
        return (int)Math.Max(x, y);
    }

    private static int GetGcdStein(int val1, int val2)
    {
        long a = Math.Abs((long)val1);
        long b = Math.Abs((long)val2);

        if (a == 0) return (int)b;
        if (b == 0) return (int)a;
        if (a == b) return (int)a;

        bool aIsEven = (a & 1L) == 0;
        bool bIsEven = (b & 1L) == 0;

        if (aIsEven && bIsEven)
            return GetGcdStein((int)(a >> 1), (int)(b >> 1)) << 1;
        else if (aIsEven && !bIsEven)
            return GetGcdStein((int)(a >> 1), (int)b);
        else if (bIsEven)
            return GetGcdStein((int)a, (int)(b >> 1));
        else if (a > b)
            return GetGcdStein((int)((a - b) >> 1), (int)b);
        else
            return GetGcdStein((int)a, (int)((b - a) >> 1));
    }

}
