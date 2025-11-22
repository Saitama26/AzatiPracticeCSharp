using Day4.Task1.Implementation;
using Day4.Task1.Interfaces;

namespace Day4.Tests.Task1;

/// <summary>
/// Tests for the Euclidean GCD algorithm implementation.
/// Inherits common test cases from GcdAlgorithmTestsBase.
/// </summary>
public class EuclideanGcdAlgorithmTests : GcdAlgorithmTestsBase
{
    protected override IGcdAlgorithm Algorithm { get; } = new EuclideanGcdAlgorithm();
}