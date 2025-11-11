using Day3.Task1_3.Interfaces;
namespace Day3.Task1_3;

public static partial class ArrayExtension
{
    public static T[] SortBy<T>(this T[] array, IComparer<T> comparer)
    {
        if (array == null) 
        {
            throw new ArgumentNullException($"{nameof(array)} can't be null"); 
        }
        if (comparer == null)
        {
            throw new ArgumentNullException($"{nameof(comparer)} can't be null"); 
        }

        T[] sort = (T[])array.Clone();
        Array.Sort(sort, comparer);

        return sort;
    }

    public static TResult[] Transform<TSource, TResult>(this TSource[] array, ITransformer<TSource, TResult> transformer)
    {
        if (array == null)
        {
            throw new ArgumentNullException($"{nameof(array)} can't be null");
        }
        if (transformer == null)
        {
            throw new ArgumentNullException($"{nameof(transformer)} can't be null");
        }

        List<TResult> list = new List<TResult>();

        foreach (var item in array)
            list.Add(transformer.Transform(item));

        return list.ToArray<TResult>();
    }

    public static T[] Filter<T>(this T[] array, IPredicate<T> predicate)
    {
        if (array == null)
        {
            throw new ArgumentNullException($"{nameof(array)} can't be null");
        }
        if (predicate == null)
        {
            throw new ArgumentNullException($"{nameof(predicate)} can't be null");
        }

        List<T> result = new List<T>();

        foreach (var i in array)
            if (predicate.IsMatched(i)) result.Add(i);

        return result.ToArray<T>();
    }
}