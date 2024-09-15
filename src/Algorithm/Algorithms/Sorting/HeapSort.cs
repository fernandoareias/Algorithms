using System;

namespace Algorithm.Algorithms.Sorting
{
    /// <summary>
    /// Time O(N log N)
    /// Space O(N)
    /// </summary>
    public static class HeapSort
    {
        /// <summary>
        /// Sorts the entire array using Heap Sort algorithm.
        /// </summary>
        /// <typeparam name="T">The type of elements in the array, which must implement IComparable.</typeparam>
        /// <param name="array">The array to be sorted.</param>
        /// <param name="size">The number of elements in the array.</param>
        /// <returns>The sorted array.</returns>
        public static T[] Sort<T>(T[] array, int size) where T : IComparable<T>
        {
            if (size <= 1) return array;

            // Build heap
            for (int i = size / 2 - 1; i >= 0; i--)
                Heapify(array, size, i);

            // Extract elements from heap
            for (int i = size - 1; i >= 0; i--)
            {
                // Move current root to end
                (array[0], array[i]) = (array[i], array[0]);

                // Call max heapify on the reduced heap
                Heapify(array, i, 0);
            }

            return array;
        }

        /// <summary>
        /// Sorts a part of the array from index 'start' to index 'end' using Heap Sort algorithm.
        /// </summary>
        /// <typeparam name="T">The type of elements in the array, which must implement IComparable.</typeparam>
        /// <param name="array">The array to be sorted.</param>
        /// <param name="start">The starting index of the subarray to be sorted.</param>
        /// <param name="end">The ending index of the subarray to be sorted.</param>
        public static void Sort<T>(T[] array, int start, int end) where T : IComparable<T>
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));
            if (start < 0 || end >= array.Length || start > end)
                throw new ArgumentOutOfRangeException("Invalid range specified.");

            int size = end - start + 1;

            if (size <= 1) return;

            // Build heap on the specified subarray
            for (int i = (size / 2) - 1; i >= 0; i--)
                Heapify(array, start, size, i);

            // Extract elements from heap
            for (int i = size - 1; i >= 0; i--)
            {
                // Move current root to end
                (array[start], array[start + i]) = (array[start + i], array[start]);

                // Call max heapify on the reduced heap
                Heapify(array, start, i, 0);
            }
        }

        private static void Heapify<T>(T[] array, int size, int index) where T : IComparable<T>
        {
            int largestIndex = index;
            int leftChild = 2 * index + 1;
            int rightChild = 2 * index + 2;

            if (leftChild < size && array[leftChild].CompareTo(array[largestIndex]) > 0)
                largestIndex = leftChild;

            if (rightChild < size && array[rightChild].CompareTo(array[largestIndex]) > 0)
                largestIndex = rightChild;

            if (largestIndex != index)
            {
                // Swap elements
                (array[index], array[largestIndex]) = (array[largestIndex], array[index]);

                // Recursively heapify the affected subtree
                Heapify(array, size, largestIndex);
            }
        }

        private static void Heapify<T>(T[] array, int start, int size, int index) where T : IComparable<T>
        {
            int largestIndex = index;
            int leftChild = 2 * index + 1;
            int rightChild = 2 * index + 2;

            leftChild = start + leftChild;
            rightChild = start + rightChild;

            if (leftChild < start + size && array[leftChild].CompareTo(array[largestIndex]) > 0)
                largestIndex = leftChild;

            if (rightChild < start + size && array[rightChild].CompareTo(array[largestIndex]) > 0)
                largestIndex = rightChild;

            if (largestIndex != index)
            {
                // Swap elements
                (array[index], array[largestIndex]) = (array[largestIndex], array[index]);

                // Recursively heapify the affected subtree
                Heapify(array, start, size, largestIndex);
            }
        }
    }
}
