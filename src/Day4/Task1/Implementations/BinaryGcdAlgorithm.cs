using Day4.Task1.Interfaces;

namespace Day4.Task1.Implementation;

public class BinaryGcdAlgorithm : IGcdAlgorithm
{
    public int Calculate(int first, int second)
    {
        var a = Math.Abs((long)first);
        var b = Math.Abs((long)second);

        if (a == 0) return (int)b;
        if (b == 0) return (int)a;
        if (a == b) return (int)a;

        var aIsEven = (a & 1L) == 0;
        var bIsEven = (b & 1L) == 0;

        if (aIsEven && bIsEven)
            return Calculate((int)(a >> 1), (int)(b >> 1)) << 1;
        else if (aIsEven && !bIsEven)
            return Calculate((int)(a >> 1), (int)b);
        else if (bIsEven)
            return Calculate((int)a, (int)(b >> 1));
        else if (a > b)
            return Calculate((int)(a - b >> 1), (int)b);
        else
            return Calculate((int)a, (int)(b - a >> 1));
    }
}