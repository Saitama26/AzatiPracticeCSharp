namespace Day6.Task1;

public class Node<T>
{
    public Node<T> Left;
    public Node<T> Right;
    public T Data;

    public Node(T value)
    {
        Data = value;
    }
}