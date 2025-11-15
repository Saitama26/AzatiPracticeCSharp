using Day3.Task1_3.Interfaces;

namespace Day3.Task1_3;

public static partial class ArrayExtension
{
    public static IEnumerable<T> SortBy<T>(this IEnumerable<T> array, IComparer<T> comparer)
    {
        if (array == null) 
        {
            throw new ArgumentNullException($"{nameof(array)} can't be null"); 
        }
        if (comparer == null)
        {
            throw new ArgumentNullException($"{nameof(comparer)} can't be null"); 
        }

        return array.OrderBy(x => x, comparer);
    }

    public static IEnumerable<TResult> Transform<TSource, TResult>(this IEnumerable<TSource> array, ITransformer<TSource, TResult> transformer)
    {
        if (array == null)
        {
            throw new ArgumentNullException($"{nameof(array)} can't be null");
        }
        if (transformer == null)
        {
            throw new ArgumentNullException($"{nameof(transformer)} can't be null");
        }

        var result = new List<TResult>();

        foreach (var item in array)
        {
            result.Add(transformer.Transform(item));
        }

        return result;
    }

    public static IEnumerable<T> Filter<T>(this IEnumerable<T> array, IPredicate<T> predicate)
    {
        if (array == null)
            throw new ArgumentNullException(nameof(array));
        if (predicate == null)
            throw new ArgumentNullException(nameof(predicate));

        var result = new List<T>();
        foreach (var item in array)
        {
            if (predicate.IsMatched(item))
                result.Add(item);
        }
        return result;
    }
}