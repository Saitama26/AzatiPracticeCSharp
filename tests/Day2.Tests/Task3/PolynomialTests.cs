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
        var areEqual = p1 == p2;
        var areNotEqual = p1 != p2;

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
        var result = p.ToString();

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void CompareTo_Null_ReturnsPositive()
    {
        // Arrange
        var p = new Polynomial(1, 2);

        // Act
        var result = p.CompareTo(null);

        // Assert
        Assert.True(result > 0);
    }

    [Fact]
    public void CompareTo_DifferentDegree_ReturnsCorrectOrder()
    {
        // Arrange
        var p1 = new Polynomial(1, 2);
        var p2 = new Polynomial(1, 2, 3);

        // Act & Assert
        Assert.True(p1.CompareTo(p2) < 0);
        Assert.True(p2.CompareTo(p1) > 0);
    }

    [Fact]
    public void CompareTo_SameDegreeDifferentCoefficients_ReturnsCorrectOrder()
    {
        // Arrange
        var p1 = new Polynomial(1, 2, 3);
        var p2 = new Polynomial(1, 2, 4);

        // Act & Assert
        Assert.True(p1.CompareTo(p2) < 0);
        Assert.True(p2.CompareTo(p1) > 0);
    }

    [Fact]
    public void CompareTo_EqualPolynomials_ReturnsZero()
    {
        // Arrange
        var p1 = new Polynomial(1, 2, 3);
        var p2 = new Polynomial(1, 2, 3);

        // Act
        var result = p1.CompareTo(p2);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void Clone_CreatesIndependentCopy()
    {
        // Arrange
        var p1 = new Polynomial(1, 2, 3);

        // Act
        var clone = (Polynomial)p1.Clone();

        // Assert
        Assert.True(p1.Equals(clone));
        Assert.NotSame(p1, clone);
    }

    [Fact]
    public void Equals_SameCoefficients_ReturnsTrue()
    {
        // Arrange
        var p1 = new Polynomial(1, 2, 3);
        var p2 = new Polynomial(1, 2, 3);

        // Act
        var result = p1.Equals(p2);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Equals_DifferentCoefficients_ReturnsFalse()
    {
        // Arrange
        var p1 = new Polynomial(1, 2, 3);
        var p2 = new Polynomial(3, 2, 1);

        // Act
        var result = p1.Equals(p2);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void GetHashCode_EqualPolynomials_HaveSameHash()
    {
        // Arrange
        var p1 = new Polynomial(1, 2, 3);
        var p2 = new Polynomial(1, 2, 3);

        // Act
        var hash1 = p1.GetHashCode();
        var hash2 = p2.GetHashCode();

        // Assert
        Assert.Equal(hash1, hash2);
    }

    [Fact]
    public void GetHashCode_DifferentPolynomials_HaveDifferentHash()
    {
        // Arrange
        var p1 = new Polynomial(1, 2, 3);
        var p2 = new Polynomial(3, 2, 1);

        // Act
        var hash1 = p1.GetHashCode();
        var hash2 = p2.GetHashCode();

        // Assert
        Assert.NotEqual(hash1, hash2);
    }
}