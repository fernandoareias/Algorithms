namespace Algorithm.Tests;

public class BinarySearchTreePostOrderDFSTests
{
    [Fact]
    public void PostOrderDFSTraversalEmptyTreeReturnsEmptyList()
    {
        var bst = new BinarySearchTree<int>();

        var result = BinarySearchTreePostOrderDFS.DepthFirstSearch(bst);

        Assert.Empty(result);
    }

    [Fact]
    public void PostOrderDFSTraversalSingleNodeTreeReturnsSingleValue()
    {
        var bst = new BinarySearchTree<int>();
        bst.Add(10);

        var result = BinarySearchTreePostOrderDFS.DepthFirstSearch(bst);

        Assert.Single(result);
        Assert.Equal(10, result[0]);
    }

    [Fact]
    public void PostOrderDFSTraversalMultipleNodesReturnsCorrectOrder()
    {
        var bst = new BinarySearchTree<int>();
        bst.Add(10);
        bst.Add(20);
        bst.Add(5);
        bst.Add(3);
        bst.Add(7);

        var result = BinarySearchTreePostOrderDFS.DepthFirstSearch(bst);

        var expectedOrder = new List<int> { 3, 7, 5, 20, 10 };
        Assert.Equal(expectedOrder, result);
    }
}