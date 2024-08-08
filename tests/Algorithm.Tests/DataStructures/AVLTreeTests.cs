using System;
using System.Collections.Generic;
using Xunit;

public class AVLTreeTests
{
    [Fact]
    public void Insert_ShouldAddElementToTree()
    {
        AVLTree<int> tree = new();
        tree.Insert(10);
        tree.Insert(20);
        tree.Insert(30);

        List<int> result = tree.InOrderTraversal();
        Assert.Equal(new List<int> { 10, 20, 30 }, result);
    }

    [Fact]
    public void Insert_ShouldBalanceTree()
    {
        AVLTree<int> tree = new();
        tree.Insert(30);
        tree.Insert(20);
        tree.Insert(10);

        List<int> result = tree.InOrderTraversal();
        Assert.Equal(new List<int> { 10, 20, 30 }, result);
    }

    [Fact]
    public void Delete_ShouldRemoveElementFromTree()
    {
        AVLTree<int> tree = new();
        tree.Insert(10);
        tree.Insert(20);
        tree.Insert(30);
        tree.Delete(20);

        List<int> result = tree.InOrderTraversal();
        Assert.Equal(new List<int> { 10, 30 }, result);
    }

    [Fact]
    public void Delete_ShouldBalanceTreeAfterDeletion()
    {
        AVLTree<int> tree = new();
        tree.Insert(30);
        tree.Insert(20);
        tree.Insert(10);
        tree.Delete(10);

        List<int> result = tree.InOrderTraversal();
        Assert.Equal(new List<int> { 20, 30 }, result);
    }

    [Fact]
    public void Delete_ShouldHandleDeletionOfLeafNode()
    {
        AVLTree<int> tree = new();
        tree.Insert(10);
        tree.Delete(10);

        List<int> result = tree.InOrderTraversal();
        Assert.Empty(result);
    }

    [Fact]
    public void Insert_ShouldHandleDuplicateValues()
    {
        AVLTree<int> tree = new();
        tree.Insert(10);
        tree.Insert(10);
        tree.Insert(10);

        List<int> result = tree.InOrderTraversal();
        Assert.Equal(new List<int> { 10 }, result); // Duplicates should not be inserted
    }

    [Fact]
    public void Insert_ShouldHandleComplexCases()
    {
        AVLTree<int> tree = new();
        tree.Insert(50);
        tree.Insert(30);
        tree.Insert(70);
        tree.Insert(20);
        tree.Insert(40);
        tree.Insert(60);
        tree.Insert(80);

        List<int> result = tree.InOrderTraversal();
        Assert.Equal(new List<int> { 20, 30, 40, 50, 60, 70, 80 }, result);
    }
}
