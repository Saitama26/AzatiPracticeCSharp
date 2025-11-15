using Day4.Task1.Implementation;

namespace Day4.Tests.Task1;

public class TimedGcdAlgorithmTest
{
    [Fact]
    public void Constructor_NullAlgorithm_ThrowsArgumentNullException_WhenAlgorithmIsNull()
    {
        // Arrange
        var measurer = new ConsoleTimeMeasurer();

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => new TimedGcdAlgorithm(null, measurer));
    }

    [Fact]
    public void Constructor_NullTimeMeasurer_ThrowsArgumentNullException_WhenMeasurerIsNull()
    {
        // Arrange
        var algorithm = new EuclideanGcdAlgorithm();

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => new TimedGcdAlgorithm(algorithm, null));
    }

    [Fact]
    public void Calculate_UsesEuclideanAlgorithm_ReturnsCorrectResult()
    {
        // Arrange
        var algorithm = new EuclideanGcdAlgorithm();
        var measurer = new ConsoleTimeMeasurer();
        var timedAlgorithm = new TimedGcdAlgorithm(algorithm, measurer);

        // Act
        var result = timedAlgorithm.Calculate(252, 105);

        // Assert
        Assert.Equal(21, result);
    }

    [Fact]
    public void Calculate_UsesBinaryAlgorithm_ReturnsCorrectResult()
    {
        // Arrange
        var algorithm = new BinaryGcdAlgorithm();
        var measurer = new ConsoleTimeMeasurer();
        var timedAlgorithm = new TimedGcdAlgorithm(algorithm, measurer);

        // Act
        var result = timedAlgorithm.Calculate(252, 105);

        // Assert
        Assert.Equal(21, result);
    }

    [Fact]
    public void Calculate_LogsExecutionTimeToFile()
    {
        // Arrange
        var filePath = "D:\\log.txt";
        var algorithm = new EuclideanGcdAlgorithm();
        var measurer = new FileLoggingTimeMeasurer(filePath);
        var timedAlgorithm = new TimedGcdAlgorithm(algorithm, measurer);

        // Act
        var result = timedAlgorithm.Calculate(252, 105);

        // Assert
        Assert.Equal(21, result);

        var logContent = File.ReadAllText(filePath);
        Assert.Contains("Execution took", logContent);
    }
}