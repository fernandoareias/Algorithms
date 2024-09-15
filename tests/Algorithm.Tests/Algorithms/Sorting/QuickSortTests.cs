using Algorithm.Algorithms.Sorting;
using Xunit;

namespace Algorithm.Tests.Algorithms.Sorting
{
    public class QuickSortTests
    {
        [Fact]
        public void SortSimpleSortsArrayOfIntegers()
        {
            int[] input = { 5, 3, 8, 1, 2 };
            int[] expected = { 1, 2, 3, 5, 8 };
            
            QuickSort.SortSimple(input);

            Assert.Equal(expected, input);
        }

        [Fact]
        public void SortSimpleSortsArrayOfStrings()
        {
            string[] input = { "apple", "orange", "banana", "grape" };
            string[] expected = { "apple", "banana", "grape", "orange" };

            QuickSort.SortSimple(input);
            
            Assert.Equal(expected, input);
        }

        [Fact]
        public void SortSimpleSortsEmptyArray()
        {
            int[] input = { };
            int[] expected = { };

            QuickSort.SortSimple(input);

            Assert.Equal(expected, input);
        }

        [Fact]
        public void SortSimpleSortsSingleElementArray()
        {
            int[] input = { 1 };
            int[] expected = { 1 };

            QuickSort.SortSimple(input);

            Assert.Equal(expected, input);
        }

        [Fact]
        public void SortSimpleSortsArrayWithDuplicates()
        {
            int[] input = { 4, 2, 2, 3, 1 };
            int[] expected = { 1, 2, 2, 3, 4 };
            
            QuickSort.SortSimple(input);
            
            Assert.Equal(expected, input);
        }

        [Fact]
        public void SortUsingMedianForPivotSortsArrayOfIntegers()
        {
            int[] input = { 5, 3, 8, 1, 2 };
            int[] expected = { 1, 2, 3, 5, 8 };
            
            QuickSort.SortUsingMedianForPivot(input);

            Assert.Equal(expected, input);
        }

        [Fact]
        public void SortUsingMedianForPivotSortsArrayOfStrings()
        {
            string[] input = { "apple", "orange", "banana", "grape" };
            string[] expected = { "apple", "banana", "grape", "orange" };

            QuickSort.SortUsingMedianForPivot(input);
            
            Assert.Equal(expected, input);
        }

        [Fact]
        public void SortUsingMedianForPivotSortsEmptyArray()
        {
            int[] input = { };
            int[] expected = { };

            QuickSort.SortUsingMedianForPivot(input);

            Assert.Equal(expected, input);
        }

        [Fact]
        public void SortUsingMedianForPivotSortsSingleElementArray()
        {
            int[] input = { 1 };
            int[] expected = { 1 };

            QuickSort.SortUsingMedianForPivot(input);

            Assert.Equal(expected, input);
        }

        [Fact]
        public void SortUsingMedianForPivotSortsArrayWithDuplicates()
        {
            int[] input = { 4, 2, 2, 3, 1 };
            int[] expected = { 1, 2, 2, 3, 4 };
            
            QuickSort.SortUsingMedianForPivot(input);
            
            Assert.Equal(expected, input);
        }

        [Fact]
        public void SortUsingMedianOfThreeForPivotSortsArrayOfIntegers()
        {
            int[] input = { 5, 3, 8, 1, 2 };
            int[] expected = { 1, 2, 3, 5, 8 };
            
            QuickSort.SortUsingMedianOfThreeForPivot(input);

            Assert.Equal(expected, input);
        }

        [Fact]
        public void SortUsingMedianOfThreeForPivotSortsArrayOfStrings()
        {
            string[] input = { "apple", "orange", "banana", "grape" };
            string[] expected = { "apple", "banana", "grape", "orange" };

            QuickSort.SortUsingMedianOfThreeForPivot(input);
            
            Assert.Equal(expected, input);
        }

        [Fact]
        public void SortUsingMedianOfThreeForPivotSortsEmptyArray()
        {
            int[] input = { };
            int[] expected = { };

            QuickSort.SortUsingMedianOfThreeForPivot(input);

            Assert.Equal(expected, input);
        }

        [Fact]
        public void SortUsingMedianOfThreeForPivotSortsSingleElementArray()
        {
            int[] input = { 1 };
            int[] expected = { 1 };

            QuickSort.SortUsingMedianOfThreeForPivot(input);

            Assert.Equal(expected, input);
        }

        [Fact]
        public void SortUsingMedianOfThreeForPivotSortsArrayWithDuplicates()
        {
            int[] input = { 4, 2, 2, 3, 1 };
            int[] expected = { 1, 2, 2, 3, 4 };
            
            QuickSort.SortUsingMedianOfThreeForPivot(input);
            
            Assert.Equal(expected, input);
        }
        
        // Novos testes para o SortDualPivot
        [Fact]
        public void SortDualPivotSortsArrayOfIntegers()
        {
            int[] input = { 5, 3, 8, 1, 2, 7, 6, 4 };
            int[] expected = { 1, 2, 3, 4, 5, 6, 7, 8 };

            QuickSort.SortDualPivot(input);

            Assert.Equal(expected, input);
        }

        [Fact]
        public void SortDualPivotSortsArrayOfStrings()
        {
            string[] input = { "apple", "orange", "banana", "grape" };
            string[] expected = { "apple", "banana", "grape", "orange" };

            QuickSort.SortDualPivot(input);

            Assert.Equal(expected, input);
        }

        [Fact]
        public void SortDualPivotSortsEmptyArray()
        {
            int[] input = { };
            int[] expected = { };

            QuickSort.SortDualPivot(input);

            Assert.Equal(expected, input);
        }

        [Fact]
        public void SortDualPivotSortsSingleElementArray()
        {
            int[] input = { 1 };
            int[] expected = { 1 };

            QuickSort.SortDualPivot(input);

            Assert.Equal(expected, input);
        }

        [Fact]
        public void SortDualPivotSortsArrayWithDuplicates()
        {
            int[] input = { 4, 2, 2, 3, 1 };
            int[] expected = { 1, 2, 2, 3, 4 };

            QuickSort.SortDualPivot(input);

            Assert.Equal(expected, input);
        }
    }
}
