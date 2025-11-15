namespace Day3.Task1_3.Interfaces;

/// <summary>
///     Predicate interface with condition matching method.
/// </summary>
public interface IPredicate<T>
{
    bool IsMatched(T element);
}