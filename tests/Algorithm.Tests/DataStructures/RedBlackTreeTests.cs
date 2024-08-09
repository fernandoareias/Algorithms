using Xunit;
using System.Collections.Generic;

public class RedBlackTreeTests
{
    [Fact]
    public void InsertRootNode_ShouldBeBlack()
    {
        var tree = new RedBlackTree<int>();
        tree.Insert(10);
        var root = tree.Search(10);
        Assert.NotNull(root);
        Assert.Equal(Color.Black, root.RedBlackTreeNodeColor);
    }

    [Fact]
    public void InsertNode_ShouldBeRed()
    {
        var tree = new RedBlackTree<int>();
        tree.Insert(10);
        tree.Insert(20);
        var node = tree.Search(20);
        Assert.NotNull(node);
        Assert.Equal(Color.Red, node.RedBlackTreeNodeColor);
    }

    [Fact]
    public void SearchExistingNode_ShouldReturnNode()
    {
        var tree = new RedBlackTree<int>();
        tree.Insert(10);
        tree.Insert(20);
        var result = tree.Search(20);
        Assert.NotNull(result);
        Assert.Equal(20, result.Data);
    }

    [Fact]
    public void SearchNonExistingNode_ShouldReturnNull()
    {
        var tree = new RedBlackTree<int>();
        tree.Insert(10);
        var result = tree.Search(15);
        Assert.Null(result);
    }

    [Fact]
    public void InsertLeftAndRightNodes_ShouldBalanceTree()
    {
        var tree = new RedBlackTree<int>();
        tree.Insert(30);
        tree.Insert(20);
        tree.Insert(10);
        var root = tree.Search(20);
        Assert.NotNull(root);
        Assert.Equal(Color.Black, root.RedBlackTreeNodeColor);
        Assert.Equal(20, root.Data);
    }

    [Fact]
    public void InOrderTraversal_ShouldReturnSortedOrder()
    {
        var tree = new RedBlackTree<int>();
        tree.Insert(30);
        tree.Insert(10);
        tree.Insert(20);
        var output = new List<int>();
        tree.InOrderTraversal(node => output.Add(node.Data));
        Assert.Equal(new List<int> { 10, 20, 30 }, output);
    }
}