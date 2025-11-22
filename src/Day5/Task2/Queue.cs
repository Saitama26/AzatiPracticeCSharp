using System.Collections;

namespace Day5.Task2;

public class Queue<T> : IEnumerable<T>
{
    private readonly List<T> _queue;
    public int Count { get => _queue.Count; }

    public Queue()
    {
        _queue = new List<T>();
    }

    public T Dequeue()
    {
        if (_queue.Count == 0)
        {
            throw new InvalidOperationException($"Queue is empty");
        }

        var elem = _queue[0];
        _queue.RemoveAt(0);
        return elem;
    }

    public T Peek()
    {
        if (_queue.Count == 0)
        {
            throw new InvalidOperationException("Queue is empty");
        }

        return _queue[0];
    }

    public void Enqueue(T item) => _queue.Add(item);

    public bool Contains(T item) => _queue.Contains(item);

    public void Clear() => _queue.Clear();
        
    public IEnumerator<T> GetEnumerator() => _queue.GetEnumerator();
    
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}