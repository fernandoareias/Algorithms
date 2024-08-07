using System.Collections.Generic;
using Xunit;

namespace Algorithm.Tests
{
    public class BinarySearchTreePreOrderDFSTests
    {
        [Fact]
        public void PreOrderDFSTraversalEmptyTreeReturnsEmptyList()
        {
            var bst = new BinarySearchTree<int>();

            var result = BinarySearchTreePreOrderDFS.DepthFirstSearch(bst);

            Assert.Empty(result);
        }

        [Fact]
        public void PreOrderDFSTraversalSingleNodeTreeReturnsSingleValue()
        {
            var bst = new BinarySearchTree<int>();
            bst.Add(10);

            var result = BinarySearchTreePreOrderDFS.DepthFirstSearch(bst);

            Assert.Single(result);
            Assert.Equal(10, result[0]);
        }

        [Fact]
        public void PreOrderDFSTraversalMultipleNodesReturnsCorrectOrder()
        {
            var bst = new BinarySearchTree<int>();
            bst.Add(10);
            bst.Add(20);
            bst.Add(5);
            bst.Add(3);
            bst.Add(7);

            var result = BinarySearchTreePreOrderDFS.DepthFirstSearch(bst);

            var expectedOrder = new List<int> { 10, 5, 3, 7, 20 };
            Assert.Equal(expectedOrder, result);
        }
    }
}
