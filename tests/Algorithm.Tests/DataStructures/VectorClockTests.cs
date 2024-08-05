using System;
using Algorithm;
using Xunit;

public class VectorClockTests
{
    [Fact]
    public void IncrementShouldIncreaseNodeCount()
    {
        var vc = new VectorClock();

        vc.Increment("node1");
        
        Assert.Equal(1, vc.GetValue("node1"));
    }

    [Fact]
    public void UpdateShouldMergeVectorClocks()
    {
        var vc1 = new VectorClock();
        var vc2 = new VectorClock();

        vc1.Increment("node1");
        vc1.Increment("node2");

        vc2.Increment("node2");
        vc2.Increment("node3");
        
        vc1.Update(vc2);
        
        Assert.Equal(1, vc1.GetValue("node1"));
        Assert.Equal(1, vc1.GetValue("node2"));
        Assert.Equal(1, vc1.GetValue("node3"));
    }

    [Fact]
    public void IsLessThanShouldReturnTrueIfLessThanOther()
    {
        var vc1 = new VectorClock();
        var vc2 = new VectorClock();

        vc1.Increment("node1");

        vc2.Increment("node1");
        vc2.Increment("node2");

        bool result = vc1.IsLessThan(vc2);

        Assert.True(result);
    }

    [Fact]
    public void IsLessThanShouldReturnFalseIfNotLessThanOther()
    {
        var vc1 = new VectorClock();
        var vc2 = new VectorClock();

        vc1.Increment("node1");
        vc1.Increment("node2");

        vc2.Increment("node1");

        bool result = vc1.IsLessThan(vc2);

        Assert.False(result);
    }

    [Fact]
    public void IsEqualShouldReturnTrueIfEqual()
    {
        var vc1 = new VectorClock();
        var vc2 = new VectorClock();

        vc1.Increment("node1");
        vc1.Increment("node2");

        vc2.Increment("node1");
        vc2.Increment("node2");

        bool result = vc1.IsEqual(vc2);

        Assert.True(result);
    }

    [Fact]
    public void IsEqualShouldReturnFalseIfNotEqual()
    {
        var vc1 = new VectorClock();
        var vc2 = new VectorClock();

        vc1.Increment("node1");

        vc2.Increment("node1");
        vc2.Increment("node2");

        bool result = vc1.IsEqual(vc2);

        Assert.False(result);
    }
}
