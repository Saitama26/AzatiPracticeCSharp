namespace Day6.Task1;

public class BinarySearchTree<T>
{
    private Node<T> _root;
    private IComparer<T> _comparer;

    public BinarySearchTree(IComparer<T> comparer = null)
    {
        _root = null;
        _comparer = comparer ?? Comparer<T>.Default;
    }

    public void Insert(T data)
    {
        _root = InsertRec(_root, data);
    }

    public IEnumerable<T> PreOrder() => PreOrder(_root);

    public IEnumerable<T> InOrder() => InOrder(_root);

    public IEnumerable<T> PostOrder() => PostOrder(_root);

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