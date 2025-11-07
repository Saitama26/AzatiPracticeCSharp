using Day3.task1_3;

namespace Day3.Tests.Task3;

public class ArrayExtensionSortByTest
{
    [Fact]
    public void SortBy_LengthAscending()
    {
        // Arrange
        string[] input = { "apple", "kiwi", "banana", "pear" };

        // Act: сортировка по длине строки
        string[] result = input.SortBy((x, y) => x.Length.CompareTo(y.Length));

        // Assert
        Assert.Equal(new[] { "kiwi", "pear", "apple", "banana" }, result);
    }

    [Fact]
    public void SortBy_LengthDescending()
    {
        // Arrange
        string[] input = { "apple", "kiwi", "banana", "pear" };

        // Act: сортировка по убыванию длины строки
        string[] result = input.SortBy((x, y) => y.Length.CompareTo(x.Length));

        // Assert
        Assert.Equal(new[] { "banana", "apple", "kiwi", "pear" }, result);
    }

    [Fact]
    public void SortBy_CharCountAscending()
    {
        // Arrange
        string[] input = { "apple", "banana", "kiwi", "pear" };
        char symbol = 'a';

        // Act: сортировка по возрастанию количества 'a'
        string[] result = input.SortBy((x, y) =>
            x.Count(c => c == symbol).CompareTo(y.Count(c => c == symbol)));

        // Assert
        Assert.Equal(new[] { "kiwi", "apple", "pear", "banana" }, result);
    }

    [Fact]
    public void SortBy_CharCountDescending()
    {
        // Arrange
        string[] input = { "apple", "banana", "kiwi", "pear" };
        char symbol = 'a';

        // Act: сортировка по убыванию количества 'a'
        string[] result = input.SortBy((x, y) =>
            y.Count(c => c == symbol).CompareTo(x.Count(c => c == symbol)));

        // Assert
        Assert.Equal(new[] { "banana", "apple", "pear", "kiwi" }, result);
    }

    [Fact]
    public void SortBy_ThrowsIfArrayIsNull()
    {
        // Arrange
        string[] input = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
            input.SortBy((x, y) => x.Length.CompareTo(y.Length)));
    }

    [Fact]
    public void SortBy_ThrowsIfFuncIsNull()
    {
        // Arrange
        string[] input = { "apple", "banana" };

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
            input.SortBy(null));
    }
}
