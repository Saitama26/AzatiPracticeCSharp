using Day2.Task3;
namespace Day2.Tests.Task3;
public class PolynomialTests
{
    [Theory]
    [InlineData(new double[] { 1, 2 }, new double[] { 3, 4 }, new double[] { 4, 6 })]
    [InlineData(new double[] { 5 }, new double[] { 7 }, new double[] { 12 })]
    [InlineData(new double[] { 0, 1 }, new double[] { 0, 1 }, new double[] { 0, 2 })]
    public void OperatorPlus_ValidInputs_ReturnsExpected(double[] a, double[] b, double[] expected)
    {
        // Arrange
        var p1 = new Polynomial(a);
        var p2 = new Polynomial(b);
        var expectedPoly = new Polynomial(expected);

        // Act
        var result = p1 + p2;

        // Assert
        Assert.True(result == expectedPoly);
    }

    [Theory]
    [InlineData(new double[] { 3, 2 }, new double[] { 1, 1 }, new double[] { 2, 1 })]
    [InlineData(new double[] { 5 }, new double[] { 7 }, new double[] { -2 })]
    [InlineData(new double[] { 0, 1 }, new double[] { 0, 1 }, new double[] { 0, 0 })]
    public void OperatorMinus_ValidInputs_ReturnsExpected(double[] a, double[] b, double[] expected)
    {
        // Arrange
        var p1 = new Polynomial(a);
        var p2 = new Polynomial(b);
        var expectedPoly = new Polynomial(expected);

        // Act
        var result = p1 - p2;

        // Assert
        Assert.True(result == expectedPoly);
    }

    [Theory]
    [InlineData(new double[] { 1, 1 }, new double[] { 1, 1 }, new double[] { 1, 2, 1 })]
    [InlineData(new double[] { 2 }, new double[] { 3 }, new double[] { 6 })]
    [InlineData(new double[] { 1, 2 }, new double[] { 0, 1 }, new double[] { 0, 1, 2 })]
    public void OperatorMultiply_ValidInputs_ReturnsExpected(double[] a, double[] b, double[] expected)
    {
        // Arrange
        var p1 = new Polynomial(a);
        var p2 = new Polynomial(b);
        var expectedPoly = new Polynomial(expected);

        // Act
        var result = p1 * p2;

        // Assert
        Assert.True(result == expectedPoly);
    }

    [Theory]
    [InlineData(new double[] { 1, 2 }, new double[] { 1, 2 }, true)]
    [InlineData(new double[] { 1, 2 }, new double[] { 2, 1 }, false)]
    [InlineData(new double[] { 0, 0, 3 }, new double[] { 0, 0, 3 }, true)]
    public void OperatorEquality_WorksCorrectly(double[] a, double[] b, bool expectedEqual)
    {
        // Arrange
        var p1 = new Polynomial(a);
        var p2 = new Polynomial(b);

        // Act
        bool areEqual = p1 == p2;
        bool areNotEqual = p1 != p2;

        // Assert
        Assert.Equal(expectedEqual, areEqual);
        Assert.Equal(!expectedEqual, areNotEqual);
    }

    [Theory]
    [InlineData(new double[] { 1, 2 }, "2x + 1")]
    [InlineData(new double[] { 0, 0, 3 }, "3x^2")]
    [InlineData(new double[] { 5 }, "5")]
    public void ToString_ReturnsExpectedFormat(double[] coeffs, string expected)
    {
        // Arrange
        var p = new Polynomial(coeffs);

        // Act
        string result = p.ToString();

        // Assert
        Assert.Equal(expected, result);
    }
}
