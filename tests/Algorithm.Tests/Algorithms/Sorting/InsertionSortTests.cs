using Algorithm.Algorithms.Sorting;
using Xunit;

namespace Algorithm.Tests.Algorithms.Sorting
{
    public class InsertionSortTests
    {
        [Fact]
        public void SortSortsArrayOfIntegers()
        {
            int[] input = { 5, 3, 8, 1, 2 };
            int[] expected = { 1, 2, 3, 5, 8 };
            
            var result = InsertionSort.Sort(input, input.Length);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void SortSortsArrayOfStrings()
        {
            string[] input = { "apple", "orange", "banana", "grape" };
            string[] expected = { "apple", "banana", "grape", "orange" };

            var result = InsertionSort.Sort(input, input.Length);
            
            Assert.Equal(expected, result);
        }

        [Fact]
        public void SortSortsEmptyArray()
        {
            int[] input = { };
            int[] expected = { };

            var result = InsertionSort.Sort(input, input.Length);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void SortSortsSingleElementArray()
        {
            int[] input = { 1 };
            int[] expected = { 1 };

            var result = InsertionSort.Sort(input, input.Length);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void SortSortsArrayWithDuplicates()
        {
            int[] input = { 4, 2, 2, 3, 1 };
            int[] expected = { 1, 2, 2, 3, 4 };
            
            var result = InsertionSort.Sort(input, input.Length);
            
            Assert.Equal(expected, result);
        }

        [Fact]
        public void SortSortsArrayOfNegativeNumbers()
        {
            int[] input = { -5, -1, -3, -2, -4 };
            int[] expected = { -5, -4, -3, -2, -1 };

            var result = InsertionSort.Sort(input, input.Length);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void SortSortsArrayOfFloatingPointNumbers()
        {
            double[] input = { 3.1, 2.4, 1.6, 4.8, 3.3 };
            double[] expected = { 1.6, 2.4, 3.1, 3.3, 4.8 };

            var result = InsertionSort.Sort(input, input.Length);

            Assert.Equal(expected, result);
        }
    }
}
