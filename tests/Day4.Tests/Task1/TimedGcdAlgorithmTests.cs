using Day4.Task1.Implementation;
using Day4.Tests.Task1.Fixtures;

namespace Day4.Tests.Task1;

public class TimedGcdAlgorithmTests : IClassFixture<GcdFixture>, IClassFixture<TimeMeasurerFixture>
{
    private readonly GcdFixture _gcdFixture;
    private readonly TimeMeasurerFixture _timeFixture;

    public TimedGcdAlgorithmTests(GcdFixture gcdFixture, TimeMeasurerFixture timeMeasurerFixture)
    {
        _gcdFixture = gcdFixture;
        _timeFixture = timeMeasurerFixture;
    }

    [Fact]
    public void Constructor_NullAlgorithm_ThrowsArgumentNullException_WhenAlgorithmIsNull()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => new TimedGcdAlgorithm(null, _timeFixture.consoleMeasurer));
    }

    [Fact]
    public void Constructor_NullTimeMeasurer_ThrowsArgumentNullException_WhenMeasurerIsNull()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => new TimedGcdAlgorithm(_gcdFixture.Euclidean, null));
    }

    [Fact]
    public void Calculate_UsesEuclideanAlgorithm_ReturnsCorrectResult()
    {
        // Arrange
        var timedAlgorithm = new TimedGcdAlgorithm(_gcdFixture.Euclidean, _timeFixture.consoleMeasurer);

        // Act
        var result = timedAlgorithm.Calculate(252, 105);

        // Assert
        Assert.Equal(21, result);
    }

    [Fact]
    public void Calculate_UsesBinaryAlgorithm_ReturnsCorrectResult()
    {
        // Arrange
        var timedAlgorithm = new TimedGcdAlgorithm(_gcdFixture.Binary, _timeFixture.consoleMeasurer);

        // Act
        var result = timedAlgorithm.Calculate(252, 105);

        // Assert
        Assert.Equal(21, result);
    }

    [Fact]
    public void Calculate_LogsExecutionTimeToFile()
    {
        // Arrange
        var timedAlgorithm = new TimedGcdAlgorithm(_gcdFixture.Euclidean, _timeFixture.fileMeasurer);

        // Act
        var result = timedAlgorithm.Calculate(252, 105);

        // Assert
        Assert.Equal(21, result);

        Assert.True(File.Exists("D:\\log.txt"));
    }
}