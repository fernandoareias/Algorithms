using Algorithm.Algorithms.Sorting;
using Xunit;

namespace Algorithm.Tests.Algorithms.Sorting
{
    public class IntroSortTests
    {
        [Fact]
        public void SortSortsArrayOfIntegers()
        {
            int[] input = { 5, 3, 8, 1, 2 };
            int[] expected = { 1, 2, 3, 5, 8 };

            IntroSort.Sort(input);

            Assert.Equal(expected, input);
        }

        [Fact]
        public void SortSortsArrayOfStrings()
        {
            string[] input = { "apple", "orange", "banana", "grape" };
            string[] expected = { "apple", "banana", "grape", "orange" };

            IntroSort.Sort(input);

            Assert.Equal(expected, input);
        }

        [Fact]
        public void SortSortsEmptyArray()
        {
            int[] input = { };
            int[] expected = { };

            IntroSort.Sort(input);

            Assert.Equal(expected, input);
        }

        [Fact]
        public void SortSortsSingleElementArray()
        {
            int[] input = { 1 };
            int[] expected = { 1 };

            IntroSort.Sort(input);

            Assert.Equal(expected, input);
        }

        [Fact]
        public void SortSortsArrayWithDuplicates()
        {
            int[] input = { 4, 2, 2, 3, 1 };
            int[] expected = { 1, 2, 2, 3, 4 };

            IntroSort.Sort(input);

            Assert.Equal(expected, input);
        }

        [Fact]
        public void SortSortsLargeArray()
        {
            int[] input = { 100, 50, 200, 150, 75, 25, 125, 175 };
            int[] expected = { 25, 50, 75, 100, 125, 150, 175, 200 };

            IntroSort.Sort(input);

            Assert.Equal(expected, input);
        }

        [Fact]
        public void SortSortsArrayWithNegativeNumbers()
        {
            int[] input = { -1, -3, 2, 0, 4, -2 };
            int[] expected = { -3, -2, -1, 0, 2, 4 };

            IntroSort.Sort(input);

            Assert.Equal(expected, input);
        }

        [Fact]
        public void SortSortsArrayOfDoubles()
        {
            double[] input = { 1.1, 2.2, 0.0, 1.2, 2.1 };
            double[] expected = { 0.0, 1.1, 1.2, 2.1, 2.2 };

            IntroSort.Sort(input);

            Assert.Equal(expected, input);
        }
    }
}
