using Day4.Task1.Implementation;
using Day4.Task1.Interfaces;

namespace Day4.Tests.Task1;

/// <summary>
/// Tests for the Binary GCD algorithm implementation.
/// Inherits common test cases from GcdAlgorithmTestsBase.
/// </summary>
public class BinaryGcdAlgorithmTests : GcdAlgorithmTestsBase
{
    protected override IGcdAlgorithm Algorithm { get; } = new BinaryGcdAlgorithm();
}