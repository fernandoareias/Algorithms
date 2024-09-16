using Algorithm.Algorithms.Sorting;
using Xunit;

namespace Algorithm.Tests.Algorithms.Sorting
{
    public class MergeSortTests
    {
        [Fact]
        public void SortSortsArrayOfIntegers()
        {
            
            int[] input = { 5, 3, 8, 1, 2 };
            int[] expected = { 1, 2, 3, 5, 8 };

            
            MergeSort.Sort(input, 0, input.Length - 1);

            
            Assert.Equal(expected, input);
        }

        [Fact]
        public void SortSortsArrayOfStrings()
        {
            
            string[] input = { "apple", "orange", "banana", "grape" };
            string[] expected = { "apple", "banana", "grape", "orange" };

            
            MergeSort.Sort(input, 0, input.Length - 1);

            
            Assert.Equal(expected, input);
        }

        [Fact]
        public void SortSortsEmptyArray()
        {
            
            int[] input = { };
            int[] expected = { };

            
            MergeSort.Sort(input, 0, input.Length - 1);

            
            Assert.Equal(expected, input);
        }

        [Fact]
        public void SortSortsSingleElementArray()
        {
            
            int[] input = { 1 };
            int[] expected = { 1 };

            
            MergeSort.Sort(input, 0, input.Length - 1);

            
            Assert.Equal(expected, input);
        }

        [Fact]
        public void SortSortsArrayWithDuplicates()
        {
            
            int[] input = { 4, 2, 2, 3, 1 };
            int[] expected = { 1, 2, 2, 3, 4 };

            
            MergeSort.Sort(input, 0, input.Length - 1);

            
            Assert.Equal(expected, input);
        }

        [Fact]
        public void SortArrayAlreadySortedReturnsSameArray()
        {
            
            int[] input = { 1, 2, 3, 4, 5 };
            int[] expected = { 1, 2, 3, 4, 5 };

            
            MergeSort.Sort(input, 0, input.Length - 1);

            
            Assert.Equal(expected, input);
        }
    }
}
