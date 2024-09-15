using Algorithm.Algorithms.Sorting;
using Xunit;

namespace Algorithm.Tests.Algorithms.Sorting
{
    public class HeapSortTests
    {
        [Fact]
        public void SortSortsArrayOfIntegers()
        {
            int[] input = { 5, 3, 8, 1, 2 };
            int[] expected = { 1, 2, 3, 5, 8 };
            
            int[] result = HeapSort.Sort(input, input.Length);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void SortSortsArrayOfStrings()
        {
            string[] input = { "apple", "orange", "banana", "grape" };
            string[] expected = { "apple", "banana", "grape", "orange" };

            string[] result = HeapSort.Sort(input, input.Length);
            
            Assert.Equal(expected, result);
        }

        [Fact]
        public void SortSortsEmptyArray()
        {
            int[] input = { };
            int[] expected = { };

            int[] result = HeapSort.Sort(input, input.Length);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void SortSortsSingleElementArray()
        {
            int[] input = { 1 };
            int[] expected = { 1 };

            int[] result = HeapSort.Sort(input, input.Length);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void SortSortsArrayWithDuplicates()
        {
            int[] input = { 4, 2, 2, 3, 1 };
            int[] expected = { 1, 2, 2, 3, 4 };
            
            int[] result = HeapSort.Sort(input, input.Length);
            
            Assert.Equal(expected, result);
        }

        [Fact]
        public void SortArrayAlreadySorted()
        {
            int[] input = { 1, 2, 3, 4, 5 };
            int[] expected = { 1, 2, 3, 4, 5 };

            int[] result = HeapSort.Sort(input, input.Length);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void SortReversedArray()
        {
            int[] input = { 5, 4, 3, 2, 1 };
            int[] expected = { 1, 2, 3, 4, 5 };

            int[] result = HeapSort.Sort(input, input.Length);

            Assert.Equal(expected, result);
        }
    }
}
