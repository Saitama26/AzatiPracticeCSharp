using Day4.Task1.Implementation;

namespace Day4.Tests.Task1.Fixtures;

public class GcdFixture
{
    public EuclideanGcdAlgorithm Euclidean { get; }
    public BinaryGcdAlgorithm Binary { get; }

    public GcdFixture()
    {
        Euclidean = new EuclideanGcdAlgorithm();
        Binary = new BinaryGcdAlgorithm();
    }
}