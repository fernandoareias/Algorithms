using System;

namespace Algorithm.Algorithms.Sorting
{
    public static class MergeSort
    {
        public static void Sort<T>(T[] array, int left, int right) where T : IComparable<T>
        {
            if (left >= right)
                return;

            int middle = left + (right - left) / 2;

            Sort(array, left, middle);
            Sort(array, middle + 1, right);

            MergeArray(array, left, middle, right);
        }

        private static void MergeArray<T>(T[] array, int left, int middle, int right) where T : IComparable<T>
        {
            int leftArrayLength = middle - left + 1;
            int rightArrayLength = right - middle;

            T[] leftTempArray = new T[leftArrayLength];
            T[] rightTempArray = new T[rightArrayLength];

            Array.Copy(array, left, leftTempArray, 0, leftArrayLength);
            Array.Copy(array, middle + 1, rightTempArray, 0, rightArrayLength);

            int i = 0, j = 0;
            int k = left;

            while (i < leftArrayLength && j < rightArrayLength)
            {
                if (leftTempArray[i].CompareTo(rightTempArray[j]) <= 0)
                {
                    array[k++] = leftTempArray[i++];
                }
                else
                {
                    array[k++] = rightTempArray[j++];
                }
            }

            while (i < leftArrayLength)
            {
                array[k++] = leftTempArray[i++];
            }

            while (j < rightArrayLength)
            {
                array[k++] = rightTempArray[j++];
            }
        }
    }
}
