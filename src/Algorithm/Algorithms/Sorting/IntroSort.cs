using System;

namespace Algorithm.Algorithms.Sorting
{
    public static class IntroSort
    {
        public static void Sort<T>(T[] array) where T : IComparable<T>
        {
            if (array == null) throw new ArgumentNullException(nameof(array));

            int depthLimit = 2 * (int)Math.Log(array.Length);
            IntroSortRecursive(array, 0, array.Length - 1, depthLimit);
        }

        private static void IntroSortRecursive<T>(T[] array, int start, int end, int depthLimit) where T : IComparable<T>
        {
            if (start >= end) return;

            int size = end - start + 1;

            // Usa InsertionSort para partições pequenas
            if (size <= 46)
            {
                InsertionSort.Sort(array, start, end); 
                return;
            }

            // Usa HeapSort se atingir o limite de profundidade
            if (depthLimit == 0)
            {
                HeapSort.Sort(array, array.Length);
                return;
            }

            int pivot = Partition(array, start, end);
            IntroSortRecursive(array, start, pivot - 1, depthLimit - 1);
            IntroSortRecursive(array, pivot + 1, end, depthLimit - 1);
        }

        private static int Partition<T>(T[] array, int low, int high) where T : IComparable<T>
        {
            T pivot = array[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (array[j].CompareTo(pivot) <= 0)
                {
                    i++;
                    Swap(array, i, j);
                }
            }

            Swap(array, i + 1, high);
            return i + 1;
        }

        private static void Swap<T>(T[] array, int i, int j)
        {
            if (i != j)
            {
                (array[i], array[j]) = (array[j], array[i]);
            }
        }
    }
}