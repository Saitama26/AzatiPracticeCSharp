using QueueString = Day5.Task2.Queue<string>;
using QueueInt = Day5.Task2.Queue<int>;

namespace Day5.Tests.Task2;

public class QueueTests
{
    [Fact]
    public void Enqueue_AddsItems_IncreasesCount()
    {
        // Arrange
        var queue = new QueueInt();

        // Act
        queue.Enqueue(1);
        queue.Enqueue(2);

        // Assert
        Assert.Equal(2, queue.Count);
        Assert.True(queue.Contains(1));
        Assert.True(queue.Contains(2));
    }

    [Fact]
    public void Dequeue_RemovesAndReturnsFirstElement()
    {
        // Arrange
        var queue = new QueueString();
        queue.Enqueue("first");
        queue.Enqueue("second");

        // Act
        var result = queue.Dequeue();

        // Assert
        Assert.Equal("first", result);
        Assert.Equal(1, queue.Count);
        Assert.False(queue.Contains("first"));
    }

    [Fact]
    public void Dequeue_EmptyQueue_ThrowsInvalidOperationException()
    {
        // Arrange
        var queue = new QueueInt();

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
    }

    [Fact]
    public void Peek_ReturnsFirstElementWithoutRemoving()
    {
        // Arrange
        var queue = new QueueInt();
        queue.Enqueue(10);
        queue.Enqueue(20);

        // Act
        var result = queue.Peek();

        // Assert
        Assert.Equal(10, result);
        Assert.Equal(2, queue.Count); // элемент не удалён
    }

    [Fact]
    public void Peek_EmptyQueue_ThrowsInvalidOperationException()
    {
        // Arrange
        var queue = new QueueInt();

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => queue.Peek());
    }

    [Fact]
    public void Contains_ReturnsTrueIfElementExists()
    {
        // Arrange
        var queue = new QueueInt();
        queue.Enqueue(5);

        // Act & Assert
        Assert.True(queue.Contains(5));
        Assert.False(queue.Contains(10));
    }

    [Fact]
    public void Clear_RemovesAllElements()
    {
        // Arrange
        var queue = new QueueInt();
        queue.Enqueue(1);
        queue.Enqueue(2);

        // Act
        queue.Clear();

        // Assert
        Assert.Equal(0, queue.Count);
        Assert.False(queue.Contains(1));
    }

    [Fact]
    public void GetEnumerator_IteratesOverElementsInOrder()
    {
        // Arrange
        var queue = new QueueInt();
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);

        // Act
        var items = queue.ToList();

        // Assert
        Assert.Equal(new[] { 1, 2, 3 }, items);
    }
}