using Algorithm;
using Xunit;

public class JaggedArrayTests
{
    [Fact]
    public void CreateJaggedArrayShouldReturnJaggedArrayWithCorrectStructure()
    {
        var result = JaggedArray.CreateJaggedArrau();

        Assert.NotNull(result);
        Assert.Equal(3, result.Length);

        Assert.Equal(new[] { 1, 2, 3 }, result[0]);
        Assert.Equal(new[] { 4, 5 }, result[1]);
        Assert.Equal(new[] { 6, 7, 8, 9 }, result[2]);

        Assert.Equal(3, result[0].Length);
        Assert.Equal(2, result[1].Length);
        Assert.Equal(4, result[2].Length);
    }
}