using Day4.Task1.Interfaces;

namespace Day4.Task1.Implementation;

public class EuclideanGcdAlgorithm : IGcdAlgorithm
{
    public int Calculate(int first, int second)
    {
        var x = Math.Abs((long)first);
        var y = Math.Abs((long)second);

        while (x != 0 && y != 0)
        {
            if (x > y)
                x %= y;
            else
                y %= x;
        }

        return (int)Math.Max(x, y);
    }
}