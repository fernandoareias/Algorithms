using System;

namespace Algorithm.Algorithms.Sorting
{
    /// <summary>
    /// Time O(N^2)
    /// Space O(1)
    /// </summary>
    public static class InsertionSort
    {
        public static T[] Sort<T>(T[] array, int length) where T : IComparable
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
    }
}