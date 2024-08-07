using System.Collections.Generic;
using Xunit;

namespace Algorithm.Tests
{
    public class BinarySearchTreeBFSTests
    {
        [Fact]
        public void BFSTraversalEmptyTreeReturnsEmptyList()
        {
            var bst = new BinarySearchTree<int>();

            var result = BinarySearchTreeBFS.BreadthFirstSearch(bst);

            Assert.Empty(result);
        }

        [Fact]
        public void BFSTraversalSingleNodeTreeReturnsSingleValue()
        {
            var bst = new BinarySearchTree<int>();
            bst.Add(10);

            var result = BinarySearchTreeBFS.BreadthFirstSearch(bst);

            Assert.Single(result);
            Assert.Equal(10, result[0]);
        }

        [Fact]
        public void BFSTraversalMultipleNodesReturnsCorrectOrder()
        {
            var bst = new BinarySearchTree<int>();
            bst.Add(10);
            bst.Add(20);
            bst.Add(5);
            bst.Add(3);
            bst.Add(7);

            var result = BinarySearchTreeBFS.BreadthFirstSearch(bst);

            var expectedOrder = new List<int> { 10, 5, 20, 3, 7 };
            Assert.Equal(expectedOrder, result);
        }
    }
}