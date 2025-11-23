using System.Collections;

namespace Day5.Task2
{
    public class Queue<T> : IEnumerable<T>
    {
        private readonly List<T> _queue;
        private int _version; 

        public int Count => _queue.Count;

        public Queue()
        {
            _queue = new List<T>();
            _version = 0;
        }

        public T Dequeue()
        {
            if (_queue.Count == 0)
                throw new InvalidOperationException("Queue is empty");

            var elem = _queue[0];
            _queue.RemoveAt(0);
            _version++; 
            
            return elem;
        }

        public T Peek()
        {
            if (_queue.Count == 0)
                throw new InvalidOperationException("Queue is empty");

            return _queue[0];
        }

        public void Enqueue(T item)
        {
            _queue.Add(item);
            _version++;
        }

        public bool Contains(T item) => _queue.Contains(item);

        public void Clear()
        {
            _queue.Clear();
            _version++;
        }

        public IEnumerator<T> GetEnumerator() => new QueueEnumerator(this);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private class QueueEnumerator : IEnumerator<T>
        {
            private readonly Queue<T> _queue;
            private readonly int _version;
            private int _index;
            private T _current;

            public QueueEnumerator(Queue<T> queue)
            {
                _queue = queue;
                _version = queue._version;
                _index = -1;
                _current = default!;
            }

            public T Current
            {
                get
                {
                    if (_index < 0 || _index >= _queue._queue.Count)
                        throw new InvalidOperationException($"{nameof(Current)} is not established.");
                    
                    return _current;
                }
            }

            object IEnumerator.Current => Current!;

            public bool MoveNext()
            {
                if (_version != _queue._version)
                    throw new InvalidOperationException("Collection was modified during iteration.");

                if (++_index < _queue._queue.Count)
                {
                    _current = _queue._queue[_index];
                    return true;
                }

                return false;
            }

            public void Reset()
            {
                if (_version != _queue._version)
                    throw new InvalidOperationException("Collection was modified during iteration.");
                _index = -1;
                _current = default!;
            }

            public void Dispose() { }
        }
    }
}