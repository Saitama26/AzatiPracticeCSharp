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
        Assert.Throws<ArgumentNullException>(() => new TimedGcdAlgorithm(null, _timeFixture.ConsoleMeasurer));
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
        var timedAlgorithm = new TimedGcdAlgorithm(_gcdFixture.Euclidean, _timeFixture.ConsoleMeasurer);

        // Act
        var result = timedAlgorithm.Calculate(252, 105);

        // Assert
        Assert.Equal(21, result);
    }

    [Fact]
    public void Calculate_UsesBinaryAlgorithm_ReturnsCorrectResult()
    {
        // Arrange
        var timedAlgorithm = new TimedGcdAlgorithm(_gcdFixture.Binary, _timeFixture.ConsoleMeasurer);

        // Act
        var result = timedAlgorithm.Calculate(252, 105);

        // Assert
        Assert.Equal(21, result);
    }

    [Fact]
    public void Calculate_LogsExecutionTimeToFile()
    {
        // Arrange
        var timedAlgorithm = new TimedGcdAlgorithm(_gcdFixture.Euclidean, _timeFixture.FileMeasurer);

        // Act
        var result = timedAlgorithm.Calculate(252, 105);

        // Assert
        Assert.Equal(21, result);
        Assert.True(File.Exists(_timeFixture.LogFilePath));

        // Verify log file contains timing information
        var logContent = File.ReadAllText(_timeFixture.LogFilePath);
        Assert.False(string.IsNullOrWhiteSpace(logContent), "Log file should contain timing information");
    }
}