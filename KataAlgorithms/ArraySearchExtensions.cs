namespace KataAlgorithms;

public static class ArraySearchExtensions
{
    public static int LinearSearch(this int[]? array, int? element)
    {
        ArgumentNullException.ThrowIfNull(array);
        ArgumentNullException.ThrowIfNull(element);
        
        for (var i = 0; i < array.Length; i++)
        {
            if (array[i].Equals(element))
            {
                return i;
            }
        }

        return -1;
    }

    public static int BinarySearch<T>(this T[]? array, T? element) 
        where T : IComparable<T>
    {
        ArgumentNullException.ThrowIfNull(array);
        ArgumentNullException.ThrowIfNull(element);

        var lo = 0;
        var hi = array.Length - 1;

        while (lo <= hi)
        {
            var middle = lo + ((hi - lo) >> 1);
            var value = array[middle];

            var comparedResult = value.CompareTo(element);
            switch (comparedResult)
            {
                case 0:
                    return middle;
                case > 0:
                    hi = middle - 1;
                    break;
                default:
                    lo = middle + 1;
                    break;
            }
        }

        return -1;
    }
}