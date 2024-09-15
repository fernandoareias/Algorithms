using System;

namespace Algorithm.Algorithms.Sorting
{
    /// <summary>
    /// Time O(N^2)
    /// Space O(1)
    /// </summary>
    public static class InsertionSort
    {
        public static T[] Sort<T>(T[] array, int length) where T : IComparable<T>
        {
            for (int i = 1; i < length; i++)
            {
                T key = array[i];
                int j = i - 1;

                while (j >= 0 && array[j].CompareTo(key) > 0)
                {
                    array[j + 1] = array[j]; 
                    j--;
                }

                array[j + 1] = key;
            }

            return array;
        }
        
        
        /// <summary>
        /// Sorts a part of the array from index 'start' to index 'end' using Insertion Sort algorithm.
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

            for (int i = start + 1; i <= end; i++)
            {
                T key = array[i];
                int j = i - 1;

                while (j >= start && array[j].CompareTo(key) > 0)
                {
                    array[j + 1] = array[j];
                    j--;
                }

                array[j + 1] = key;
            }
        }
    }
}