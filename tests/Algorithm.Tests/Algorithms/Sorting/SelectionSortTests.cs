using Algorithm.Algorithms.Sorting;
using Xunit;

public class SelectionSortTests
{
    [Fact]
    public void SortSortsArrayOfIntegers()
    {
        int[] input = { 64, 25, 12, 22, 11 };
        int[] expected = { 11, 12, 22, 25, 64 };
        int[] result = SelectionSort.Sort(input);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void SortSortsArrayOfStrings()
    {
        string[] input = { "apple", "orange", "banana", "grape" };
        string[] expected = { "apple", "banana", "grape", "orange" };
        string[] result = SelectionSort.Sort(input);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void SortSortsArrayOfDoubles()
    {
        double[] input = { 64.2, 25.5, 12.1, 22.3, 11.7 };
        double[] expected = { 11.7, 12.1, 22.3, 25.5, 64.2 };
        double[] result = SelectionSort.Sort(input);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void SortSortsArrayOfChars()
    {
        char[] input = { 'd', 'a', 'c', 'b' };
        char[] expected = { 'a', 'b', 'c', 'd' };
        char[] result = SelectionSort.Sort(input);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void SortSortsArrayWithDuplicateValues()
    {
        int[] input = { 3, 1, 2, 2, 1, 3 };
        int[] expected = { 1, 1, 2, 2, 3, 3 };
        int[] result = SelectionSort.Sort(input);
        Assert.Equal(expected, result);
    }
}