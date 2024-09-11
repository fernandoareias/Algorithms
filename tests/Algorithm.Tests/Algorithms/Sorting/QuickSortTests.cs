using Algorithm.Algorithms.Sorting;
using Xunit;

namespace Algorithm.Tests.Algorithms.Sorting;

public class QuickSortTests
{
    [Fact]
    public void SortSimple_SortsArrayOfIntegers()
    {
        int[] input = { 5, 3, 8, 1, 2 };
        int[] expected = { 1, 2, 3, 5, 8 };
        
        QuickSort.SortSimple(input);

        Assert.Equal(expected, input);
    }

    [Fact]
    public void SortSimple_SortsArrayOfStrings()
    {
        string[] input = { "apple", "orange", "banana", "grape" };
        string[] expected = { "apple", "banana", "grape", "orange" };

        QuickSort.SortSimple(input);
        
        Assert.Equal(expected, input);
    }

    [Fact]
    public void SortSimple_SortsEmptyArray()
    {
        int[] input = { };
        int[] expected = { };

        QuickSort.SortSimple(input);

        Assert.Equal(expected, input);
    }

    [Fact]
    public void SortSimple_SortsSingleElementArray()
    {
        int[] input = { 1 };
        int[] expected = { 1 };

        QuickSort.SortSimple(input);

        Assert.Equal(expected, input);
    }

    [Fact]
    public void SortSimple_SortsArrayWithDuplicates()
    {
        int[] input = { 4, 2, 2, 3, 1 };
        int[] expected = { 1, 2, 2, 3, 4 };
        
        QuickSort.SortSimple(input);
        
        Assert.Equal(expected, input);
    }

    [Fact]
    public void SortUsingMedianForPivot_SortsArrayOfIntegers()
    {
        int[] input = { 5, 3, 8, 1, 2 };
        int[] expected = { 1, 2, 3, 5, 8 };
        
        QuickSort.SortUsingMedianForPivot(input);

        Assert.Equal(expected, input);
    }

    [Fact]
    public void SortUsingMedianForPivot_SortsArrayOfStrings()
    {
        string[] input = { "apple", "orange", "banana", "grape" };
        string[] expected = { "apple", "banana", "grape", "orange" };

        QuickSort.SortUsingMedianForPivot(input);
        
        Assert.Equal(expected, input);
    }

    [Fact]
    public void SortUsingMedianForPivot_SortsEmptyArray()
    {
        int[] input = { };
        int[] expected = { };

        QuickSort.SortUsingMedianForPivot(input);

        Assert.Equal(expected, input);
    }

    [Fact]
    public void SortUsingMedianForPivot_SortsSingleElementArray()
    {
        int[] input = { 1 };
        int[] expected = { 1 };

        QuickSort.SortUsingMedianForPivot(input);

        Assert.Equal(expected, input);
    }

    [Fact]
    public void SortUsingMedianForPivot_SortsArrayWithDuplicates()
    {
        int[] input = { 4, 2, 2, 3, 1 };
        int[] expected = { 1, 2, 2, 3, 4 };
        
        QuickSort.SortUsingMedianForPivot(input);
        
        Assert.Equal(expected, input);
    }

    [Fact]
    public void SortUsingMedianOfThreeForPivot_SortsArrayOfIntegers()
    {
        int[] input = { 5, 3, 8, 1, 2 };
        int[] expected = { 1, 2, 3, 5, 8 };
        
        QuickSort.SortUsingMedianOfThreeForPivot(input);

        Assert.Equal(expected, input);
    }

    [Fact]
    public void SortUsingMedianOfThreeForPivot_SortsArrayOfStrings()
    {
        string[] input = { "apple", "orange", "banana", "grape" };
        string[] expected = { "apple", "banana", "grape", "orange" };

        QuickSort.SortUsingMedianOfThreeForPivot(input);
        
        Assert.Equal(expected, input);
    }

    [Fact]
    public void SortUsingMedianOfThreeForPivot_SortsEmptyArray()
    {
        int[] input = { };
        int[] expected = { };

        QuickSort.SortUsingMedianOfThreeForPivot(input);

        Assert.Equal(expected, input);
    }

    [Fact]
    public void SortUsingMedianOfThreeForPivot_SortsSingleElementArray()
    {
        int[] input = { 1 };
        int[] expected = { 1 };

        QuickSort.SortUsingMedianOfThreeForPivot(input);

        Assert.Equal(expected, input);
    }

    [Fact]
    public void SortUsingMedianOfThreeForPivot_SortsArrayWithDuplicates()
    {
        int[] input = { 4, 2, 2, 3, 1 };
        int[] expected = { 1, 2, 2, 3, 4 };
        
        QuickSort.SortUsingMedianOfThreeForPivot(input);
        
        Assert.Equal(expected, input);
    }
}
