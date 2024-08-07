namespace Algorithm.Tests;

public class BinarySearchTreeInOrderDFSTests
{
    [Fact]
    public void InOrderDFSTraversalEmptyTreeReturnsEmptyList()
    {
        var bst = new BinarySearchTree<int>();

        var result = BinarySearchTreeInOrderDFS.DepthFirstSearch(bst);

        Assert.Empty(result);
    }

    [Fact]
    public void InOrderDFSTraversalSingleNodeTreeReturnsSingleValue()
    {
        var bst = new BinarySearchTree<int>();
        bst.Add(10);

        var result = BinarySearchTreeInOrderDFS.DepthFirstSearch(bst);

        Assert.Single(result);
        Assert.Equal(10, result[0]);
    }

    [Fact]
    public void InOrderDFSTraversalMultipleNodesReturnsCorrectOrder()
    {
        var bst = new BinarySearchTree<int>();
        bst.Add(10);
        bst.Add(20);
        bst.Add(5);
        bst.Add(3);
        bst.Add(7);

        var result = BinarySearchTreeInOrderDFS.DepthFirstSearch(bst);

        var expectedOrder = new List<int> { 3, 5, 7, 10, 20 };
        Assert.Equal(expectedOrder, result);
    }
}