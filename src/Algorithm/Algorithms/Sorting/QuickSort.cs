namespace Algorithm.Algorithms.Sorting;

public static class QuickSort
{
    
    /// <summary>
    /// Implementacao do quick sort simples
    /// </summary>
    /// <param name="arr"></param>
    /// <typeparam name="T"></typeparam>
    public static void SortSimple<T>(T[] arr) where T : IComparable<T>
        => SortSimple(arr, 0, arr.Length - 1);

    
    public static void SortSimple<T>(T[] arr, int start_pos, int end_pos) where T : IComparable<T>
    {
        if (start_pos >= end_pos) return;

        var pivot = arr[start_pos];
        int leftPointer = start_pos;
        int rightPointer = end_pos;

        while (leftPointer <= rightPointer)
        {
            while (arr[leftPointer].CompareTo(pivot) < 0) leftPointer++;
            while (arr[rightPointer].CompareTo(pivot) > 0) rightPointer--;

            if (leftPointer <= rightPointer)
            {
                (arr[leftPointer], arr[rightPointer]) = (arr[rightPointer], arr[leftPointer]);
                leftPointer++;
                rightPointer--;
            }
        }

        if (start_pos < rightPointer) SortSimple(arr, start_pos, rightPointer);
        if (leftPointer < end_pos) SortSimple(arr, leftPointer, end_pos);
    }
    
    /// <summary>
    /// Sort usando a média para o pivot
    /// </summary>
    /// <param name="arr"></param>
    /// <typeparam name="T"></typeparam>
    public static void SortUsingMedianForPivot<T>(T[] arr) where T : IComparable<T>
        => SortUsingMedianForPivot(arr, 0, arr.Length - 1);

    public static void SortUsingMedianForPivot<T>(T[] arr, int start_pos, int end_pos) where T : IComparable<T>
    {
        if (start_pos >= end_pos) return;

        var pivot = arr[(start_pos + end_pos) / 2];
        int leftPointer = start_pos;
        int rightPointer = end_pos;

        while (leftPointer <= rightPointer)
        {
            while (arr[leftPointer].CompareTo(pivot) < 0) leftPointer++;
            while (arr[rightPointer].CompareTo(pivot) > 0) rightPointer--;

            if (leftPointer <= rightPointer)
            {
                (arr[leftPointer], arr[rightPointer]) = (arr[rightPointer], arr[leftPointer]);
                leftPointer++;
                rightPointer--;
            }
        }

        if (start_pos < rightPointer) SortUsingMedianForPivot(arr, start_pos, rightPointer);
        if (leftPointer < end_pos) SortUsingMedianForPivot(arr, leftPointer, end_pos);
    }
    
    
    /// <summary>
    /// Quick sort usando a mediana
    /// </summary>
    /// <param name="arr"></param>
    /// <typeparam name="T"></typeparam>
    public static void SortUsingMedianOfThreeForPivot<T>(T[] arr) where T : IComparable<T>
        => SortUsingMedianOfThreeForPivot(arr, 0, arr.Length - 1);

    public static void SortUsingMedianOfThreeForPivot<T>(T[] arr, int start_pos, int end_pos) where T : IComparable<T>
    {
        if (start_pos >= end_pos) return;

        var pivot = MedianOfThree(arr, start_pos, (start_pos + end_pos) / 2, end_pos);
        int leftPointer = start_pos;
        int rightPointer = end_pos;

        while (leftPointer <= rightPointer)
        {
            while (arr[leftPointer].CompareTo(pivot) < 0) leftPointer++;
            while (arr[rightPointer].CompareTo(pivot) > 0) rightPointer--;

            if (leftPointer <= rightPointer)
            {
                (arr[leftPointer], arr[rightPointer]) = (arr[rightPointer], arr[leftPointer]);
                leftPointer++;
                rightPointer--;
            }
        }

        if (start_pos < rightPointer) SortUsingMedianOfThreeForPivot(arr, start_pos, rightPointer);
        if (leftPointer < end_pos) SortUsingMedianOfThreeForPivot(arr, leftPointer, end_pos);
    }

    private static T MedianOfThree<T>(T[] arr, int a, int b, int c) where T : IComparable<T>
    {
        // Retorna a mediana dos três valores (a, b, c)
        if (arr[a].CompareTo(arr[b]) > 0) (a, b) = (b, a); // a <= b
        if (arr[b].CompareTo(arr[c]) > 0) (b, c) = (c, b); // b <= c
        if (arr[a].CompareTo(arr[b]) > 0) (a, b) = (b, a); // a <= b novamente
        return arr[b]; // Mediana de a, b, c
    }
}