using Day6.Task1;
using Day6.Tests.Task1.TestData;
using Day4.Task2.Implementations;

namespace Day6.Tests.Task1;

public class BinarySearchTreeTests
{
    [Fact]
    public void Add_IncreasesCount_AndContainsElement()
    {
        var bst = new BinarySearchTree<int>();
        bst.Add(5);
        bst.Add(3);
        bst.Add(8);

        Assert.Equal(3, bst.Count);
        Assert.True(bst.Contains(5));
        Assert.True(bst.Contains(3));
        Assert.True(bst.Contains(8));
    }

    [Fact]
    public void Clear_RemovesAllElements()
    {
        var bst = new BinarySearchTree<int>();
        bst.Add(1);
        bst.Add(2);
        bst.Add(3);

        bst.Clear();

        Assert.Equal(0, bst.Count);
        Assert.False(bst.Contains(1));
    }

    [Fact]
    public void Contains_ReturnsFalse_WhenElementNotPresent()
    {
        var bst = new BinarySearchTree<int>();
        bst.Add(10);
        bst.Add(20);

        Assert.False(bst.Contains(5));
    }

    [Fact]
    public void CopyTo_CopiesElementsInOrder()
    {
        var bst = new BinarySearchTree<int>();
        bst.Add(5);
        bst.Add(3);
        bst.Add(8);

        var array = new int[3];
        bst.CopyTo(array, 0);

        Assert.Equal(new[] { 3, 5, 8 }, array);
    }

    [Fact]
    public void Remove_RemovesLeafNode()
    {
        var bst = new BinarySearchTree<int>();
        bst.Add(5);
        bst.Add(3);
        bst.Add(8);

        var removed = bst.Remove(3);

        Assert.True(removed);
        Assert.False(bst.Contains(3));
        Assert.Equal(2, bst.Count);
    }

    [Fact]
    public void Remove_RemovesNodeWithOneChild()
    {
        var bst = new BinarySearchTree<int>();
        bst.Add(5);
        bst.Add(3);
        bst.Add(2); // child of 3

        var removed = bst.Remove(3);

        Assert.True(removed);
        Assert.Contains(2, bst);
    }

    [Fact]
    public void Remove_RemovesNodeWithTwoChildren()
    {
        var bst = new BinarySearchTree<int>();
        bst.Add(5);
        bst.Add(3);
        bst.Add(7);
        bst.Add(6);
        bst.Add(8);

        var removed = bst.Remove(7);

        Assert.True(removed);
        Assert.False(bst.Contains(7));
        Assert.True(bst.Contains(6));
        Assert.True(bst.Contains(8));
    }

    [Fact]
    public void Remove_ReturnsFalse_WhenElementNotFound()
    {
        var bst = new BinarySearchTree<int>();
        bst.Add(5);
        bst.Add(3);

        var removed = bst.Remove(10);

        Assert.False(removed);
        Assert.Equal(2, bst.Count);
    }

    [Fact]
    public void Enumerator_IteratesInOrder()
    {
        var bst = new BinarySearchTree<int>();
        bst.Add(5);
        bst.Add(3);
        bst.Add(8);

        var result = bst.ToList();

        Assert.Equal(new[] { 3, 5, 8 }, result);
    }

    [Fact]
    public void IsReadOnly_ReturnsFalse()
    {
        var bst = new BinarySearchTree<int>();
        Assert.False(bst.IsReadOnly);
    }

    [Theory]
    [InlineData(new[] { 5, 3, 8 }, new[] { 3, 5, 8 })]
    [InlineData(new[] { 10, 4, 15, 2 }, new[] { 2, 4, 10, 15 })]
    [InlineData(new[] { 7, 1, 9, 0, 5 }, new[] { 0, 1, 5, 7, 9 })]
    public void InOrder_ReturnsSortedSequence(int[] input, int[] expected)
    {
        // Arrange
        var bst = new BinarySearchTree<int>();
        foreach (var value in input)
            bst.Add(value);

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
            bst.Add(value);

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
            bst.Add(value);

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
        bst.Add(5);
        bst.Add(3);
        bst.Add(8);

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
        bst.Add("pear");
        bst.Add("apple");
        bst.Add("orange");

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
        bst.Add("pear");
        bst.Add("apple");
        bst.Add("orange");

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

        bst.Add(new Point { X = 2, Y = 5 });
        bst.Add(new Point { X = 1, Y = 3 });
        bst.Add(new Point { X = 2, Y = 1 });

        // Act
        var result = bst.InOrder().ToList();


        // Assert
        Assert.Equal(new List<Point>() {
                new Point { X = 1, Y = 3 },
                new Point { X = 2, Y = 1 },
                new Point { X = 2, Y = 5 }
            }, result);
    }

    [Fact]
    public void InOrder_Point_SortedByYDescending()
    {
        // Arrange
        var bst = new BinarySearchTree<Point>(
            Comparer<Point>.Create((a, b) => b.Y.CompareTo(a.Y))
        );

        bst.Add(new Point { X = 1, Y = 3 });
        bst.Add(new Point { X = 2, Y = 5 });
        bst.Add(new Point { X = 2, Y = 1 });

        // Act
        var result = bst.InOrder().ToList();

        // Assert
        Assert.Equal(new List<Point>
        {
            new Point { X = 2, Y = 5 },
            new Point { X = 1, Y = 3 },
            new Point { X = 2, Y = 1 }
        }, result);
    }

    [Fact]
    public void InOrder_Book_DefaultComparer_SortsByIsbn()
    {
        // Arrange
        var bst = new BinarySearchTree<Book>();

        var book1 = new Book("222", "AuthorB", "TitleB", "PubB", 2020, 200, 20.0, null);
        var book2 = new Book("111", "AuthorA", "TitleA", "PubA", 2019, 150, 15.0, null);
        var book3 = new Book("333", "AuthorC", "TitleC", "PubC", 2021, 300, 30.0, null);

        bst.Add(book1);
        bst.Add(book2);
        bst.Add(book3);

        // Act
        var result = bst.InOrder().ToList();

        // Assert
        Assert.Equal(new[] { book2, book1, book3 }, result);
    }

    [Fact]
    public void InOrder_Book_CustomComparer_SortsByAuthorThenYear()
    {
        // Arrange
        var bst = new BinarySearchTree<Book>(
            Comparer<Book>.Create((a, b) =>
            {
                var cmp = string.Compare(a.Author, b.Author, StringComparison.OrdinalIgnoreCase);
                return cmp != 0 ? cmp : a.YearOfPublication.CompareTo(b.YearOfPublication);
            })
        );

        var book1 = new Book("111", "AuthorB", "Title1", "Pub1", 2020, 200, 20.0, null);
        var book2 = new Book("222", "AuthorA", "Title2", "Pub2", 2019, 150, 15.0, null);
        var book3 = new Book("333", "AuthorB", "Title3", "Pub3", 2018, 300, 30.0, null);

        bst.Add(book1);
        bst.Add(book2);
        bst.Add(book3);

        // Act
        var result = bst.InOrder().ToList();

        // Assert
        Assert.Equal(new[] { book2, book3, book1 }, result);
    }

    [Fact]
    public void InOrder_Book_CustomComparer_SortsByPriceDescending()
    {
        // Arrange
        var bst = new BinarySearchTree<Book>(
            Comparer<Book>.Create((a, b) => b.Price.CompareTo(a.Price))
        );

        var book1 = new Book("111", "AuthorA", "Title1", "Pub1", 2020, 200, 10.0, null);
        var book2 = new Book("222", "AuthorB", "Title2", "Pub2", 2019, 150, 25.0, null);
        var book3 = new Book("333", "AuthorC", "Title3", "Pub3", 2021, 300, 15.0, null);

        bst.Add(book1);
        bst.Add(book2);
        bst.Add(book3);

        // Act
        var result = bst.InOrder().ToList();

        // Assert
        Assert.Equal(new[] { book2, book3, book1 }, result);
    }
}