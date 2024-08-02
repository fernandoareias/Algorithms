using Algorithm.Algorithms.Sorting;

namespace Algorithm.Tests.Algorithms.Sorting;

public class BubbleSortTests
{
    [Fact]
    public void SortSortsArrayOfIntegers()
    {
        int[] input = { 5, 3, 8, 1, 2 };
        int[] expected = { 1, 2, 3, 5, 8 };
        
        int[] result = BubbleSort.Sort(input);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void SortSortsArrayOfStrings()
    {
        string[] input = { "apple", "orange", "banana", "grape" };
        string[] expected = { "apple", "banana", "grape", "orange" };

        string[] result = BubbleSort.Sort(input);
        
        Assert.Equal(expected, result);
    }

    [Fact]
    public void SortSortsEmptyArray()
    {
        int[] input = { };
        int[] expected = { };

        int[] result = BubbleSort.Sort(input);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void SortSortsSingleElementArray()
    {
        int[] input = { 1 };
        int[] expected = { 1 };

        int[] result = BubbleSort.Sort(input);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void SortSortsArrayWithDuplicates()
    {
        int[] input = { 4, 2, 2, 3, 1 };
        int[] expected = { 1, 2, 2, 3, 4 };
        
        int[] result = BubbleSort.Sort(input);
        
        Assert.Equal(expected, result);
    }
}