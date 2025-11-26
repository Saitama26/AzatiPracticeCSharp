using System.Collections;

namespace Day6.Task1;

public class BinarySearchTree<T> : ICollection<T>, IEnumerable<T>, IEnumerable
{
    private Node<T> _root;
    private IComparer<T> _comparer;
    private int _count;

    public int Count => _count;
    public bool IsReadOnly => false;

    public BinarySearchTree(IComparer<T> comparer = null)
    {
        _root = null;
        _comparer = comparer ?? Comparer<T>.Default;
    }

    public void Add(T item) 
    {
        _root = InsertRec(_root, item);
        _count++;
    }

    public void Clear()
    {
        _root = null;
        _count = 0;
    }

    public bool Contains(T item)
    {
        var current = _root;
        while (current != null)
        {
            int cmp = _comparer.Compare(item, current.Data);
            if (cmp == 0) return true;
            current = cmp < 0 ? current.Left : current.Right;
        }
        return false;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        foreach (var item in InOrder())
        {
            array[arrayIndex++] = item;
        }
    }

    public bool Remove(T item)
    {
        bool removed;
        (_root, removed) = RemoveRec(_root, item);
        if (removed) _count--;
        return removed;
    }

    public IEnumerable<T> PreOrder() => PreOrder(_root);

    public IEnumerable<T> InOrder() => InOrder(_root);

    public IEnumerable<T> PostOrder() => PostOrder(_root);

    public IEnumerator<T> GetEnumerator() => InOrder().GetEnumerator();
    
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    
    private (Node<T> node, bool removed) RemoveRec(Node<T> root, T item)
    {
        if (root == null) return (null, false);

        int cmp = _comparer.Compare(item, root.Data);
        if (cmp < 0)
        {
            (root.Left, var removed) = RemoveRec(root.Left, item);
            return (root, removed);
        }
        else if (cmp > 0)
        {
            (root.Right, var removed) = RemoveRec(root.Right, item);
            return (root, removed);
        }
        else
        {
            if (root.Left == null) return (root.Right, true);
            if (root.Right == null) return (root.Left, true);

            var minNode = FindMin(root.Right);
            root.Data = minNode.Data;
            (root.Right, _) = RemoveRec(root.Right, minNode.Data);
            return (root, true);
        }
    }

    private Node<T> FindMin(Node<T> node)
    {
        while (node.Left != null) node = node.Left;
        return node;
    }

    private Node<T> InsertRec(Node<T> root, T Data)
    {
        if (root == null)
        {
            return new Node<T>(Data);
        }

        if (_comparer.Compare(Data, root.Data) < 0)
        {
            root.Left = InsertRec(root.Left, Data);
        }
        else if (_comparer.Compare(Data, root.Data) > 0)
        {
            root.Right = InsertRec(root.Right, Data);
        }
     
        return root;
    }

    private IEnumerable<T> PostOrder(Node<T> root)
    {
        if(root != null)
        {
            foreach (var node in PostOrder(root.Left)) yield return node;
            foreach (var node in PostOrder(root.Right)) yield return node;
            yield return root.Data;
        }
    }

    private IEnumerable<T> InOrder(Node<T> root)
    {
        if(root != null)    
        {
            foreach(var node in InOrder(root.Left)) yield return node;
            yield return root.Data;
            foreach (var node in InOrder(root.Right)) yield return node;
        }
    }

    private IEnumerable<T> PreOrder(Node<T> root)
    {
        if(root != null)
        {
            yield return root.Data;
            foreach(var node in PreOrder(root.Left)) yield return node;
            foreach(var node in PreOrder(root.Right)) yield return node;
        }
    }
}