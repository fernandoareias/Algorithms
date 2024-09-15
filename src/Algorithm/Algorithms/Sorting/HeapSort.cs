namespace Algorithm.Algorithms.Sorting;

/// <summary>
/// Time O(N log N)
/// Space O(N)
/// </summary>
public static class HeapSort
{
    public static T[] Sort<T>(T[] array, int size) where T : IComparable<T>
    {
        if (size <= 1) return array;

        for (int i = size / 2 - 1; i >= 0; i--)
            Heapify(array, size, i);

        for (int i = size - 1; i >= 0; i--)
        { 
            (array[0], array[i]) = (array[i], array[0]);

            Heapify(array, i, 0);
        }
        
        return array;
    }

    public static void Heapify<T>(T[] array, int size, int index) where T : IComparable<T>
    {
        int largestIndex = index;
        int leftChild = 2 * index + 1;
        int rightChild = 2 * index + 2;
        
        if(leftChild < size && array[leftChild].CompareTo(array[largestIndex]) > 0)
            largestIndex = leftChild;
        
        if (rightChild < size && array[rightChild].CompareTo(array[largestIndex]) > 0)
            largestIndex = rightChild;
        
        if (largestIndex != index)
        {
            (array[index], array[largestIndex]) = (array[largestIndex], array[index]);
            Heapify(array, size, largestIndex);
        }
    }
}