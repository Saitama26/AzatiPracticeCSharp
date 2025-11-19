using Day6.Task2;
using Day6.Tests.Task2.TestData;

namespace Day6.Tests.Task2;

public class BinarySearchTreeTests
{
    [Theory]
    [InlineData(new[] { 5, 3, 8 }, new[] { 3, 5, 8 })]
    [InlineData(new[] { 10, 4, 15, 2 }, new[] { 2, 4, 10, 15 })]
    [InlineData(new[] { 7, 1, 9, 0, 5 }, new[] { 0, 1, 5, 7, 9 })]
    public void InOrder_ReturnsSortedSequence(int[] input, int[] expected)
    {
        // Arrange
        var bst = new BinarySearchTree<int>();
        foreach (var value in input)
            bst.Insert(value);

        // Act
        var result = bst.InOrder().ToList();

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(new[] { 5, 3, 8 }, new[] { 5, 3, 8 })]
    [InlineData(new[] { 10, 4, 15, 2 }, new[] { 10, 4, 2, 15 })]
    [InlineData(new[] { 7, 1, 9, 0, 5 }, new[] { 7, 1, 0, 5, 9 })]
    public void PreOrder_ReturnsCorrectSequence(int[] input, int[] expected)
    {
        // Arrange
        var bst = new BinarySearchTree<int>();
        foreach (var value in input)
            bst.Insert(value);

        // Act
        var result = bst.PreOrder().ToList();

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(new[] { 5, 3, 8 }, new[] { 3, 8, 5 })]
    [InlineData(new[] { 10, 4, 15, 2 }, new[] { 2, 4, 15, 10 })]
    [InlineData(new[] { 7, 1, 9, 0, 5 }, new[] { 0, 5, 1, 9, 7 })]
    public void PostOrder_ReturnsCorrectSequence(int[] input, int[] expected)
    {
        // Arrange
        var bst = new BinarySearchTree<int>();
        foreach (var value in input)
            bst.Insert(value);

        // Act
        var result = bst.PostOrder().ToList();

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Traversals_OnEmptyTree_ReturnEmpty()
    {
        // Arrange
        var bst = new BinarySearchTree<int>();

        // Act
        var pre = bst.PreOrder().ToList();
        var inorder = bst.InOrder().ToList();
        var post = bst.PostOrder().ToList();

        // Assert
        Assert.Empty(pre);
        Assert.Empty(inorder);
        Assert.Empty(post);
    }

    [Fact]
    public void InOrder_WithCustomComparer_ReverseOrder()
    {
        // Arrange
        var bst = new BinarySearchTree<int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));
        bst.Insert(5);
        bst.Insert(3);
        bst.Insert(8);

        // Act
        var result = bst.InOrder().ToList();

        // Assert
        Assert.Equal(new[] { 8, 5, 3 }, result);
    }

    [Fact]
    public void InOrder_String_DefaultComparer_ReturnsSorted()
    {
        // Arrange
        var bst = new BinarySearchTree<string>();
        bst.Insert("pear");
        bst.Insert("apple");
        bst.Insert("orange");

        // Act
        var result = bst.InOrder().ToList();

        // Assert
        Assert.Equal(new[] { "apple", "orange", "pear" }, result);
    }

    [Fact]
    public void InOrder_String_CustomComparer_ReverseOrder()
    {
        // Arrange
        var bst = new BinarySearchTree<string>(Comparer<string>.Create((a, b) => b.CompareTo(a)));
        bst.Insert("pear");
        bst.Insert("apple");
        bst.Insert("orange");

        // Act
        var result = bst.InOrder().ToList();

        // Assert
        Assert.Equal(new[] { "pear", "orange", "apple" }, result);
    }

    [Fact]
    public void InOrder_Point_CustomComparer_SortedByXThenY()
    {
        // Arrange
        var bst = new BinarySearchTree<Point>(
            Comparer<Point>.Create((a, b) =>
            {
                var cmp = a.X.CompareTo(b.X);
                return cmp != 0 ? cmp : a.Y.CompareTo(b.Y);
            })
        );

        bst.Insert(new Point { X = 2, Y = 5 });
        bst.Insert(new Point { X = 1, Y = 3 });
        bst.Insert(new Point { X = 2, Y = 1 });

        // Act
        var result = bst.InOrder().ToList();

        // Assert
        Assert.Equal(new List<Point>() {
                new Point { X = 1, Y = 3 },
                new Point { X = 2, Y = 1 },
                new Point { X = 2, Y = 5 }
            }, result);
    }
}