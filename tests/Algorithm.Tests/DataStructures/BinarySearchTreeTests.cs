using System;
using Xunit;

namespace Algorithm.Tests
{
    public class BinarySearchTreeTests
    {
        [Fact]
        public void AddNodeSuccessfully()
        {
            var bst = new BinarySearchTree<int>();
            bst.Add(10);

            Assert.NotNull(bst.Root);
            Assert.Equal(10, bst.Root.Value);
        }

        [Fact]
        public void SearchKeyNotFoundReturnsNull()
        {
            var bst = new BinarySearchTree<int>();
            bst.Add(10);
            bst.Add(20);
            bst.Add(5);

            var result = bst.Search(15);

            Assert.Null(result);
        }

        [Fact]
        public void SearchKeyFoundReturnsNode()
        {
            var bst = new BinarySearchTree<int>();
            bst.Add(10);
            bst.Add(20);
            bst.Add(5);

            var result = bst.Search(20);

            Assert.NotNull(result);
            Assert.Equal(20, result.Value);
        }

        [Fact]
        public void DeleteLeafNodeSuccessfully()
        {
            var bst = new BinarySearchTree<int>();
            bst.Add(10);
            bst.Add(20);
            bst.Add(5);

            bst.Delete(20);
            var result = bst.Search(20);

            Assert.Null(result);
            Assert.NotNull(bst.Search(10));
            Assert.NotNull(bst.Search(5));
        }

        [Fact]
        public void DeleteNodeWithOneChildSuccessfully()
        {
            var bst = new BinarySearchTree<int>();
            bst.Add(10);
            bst.Add(20);
            bst.Add(5);
            bst.Add(3);

            bst.Delete(5);
            var result = bst.Search(5);

            Assert.Null(result);
            Assert.NotNull(bst.Search(3));
        }

        [Fact]
        public void DeleteNodeWithTwoChildrenSuccessfully()
        {
            var bst = new BinarySearchTree<int>();
            bst.Add(10);
            bst.Add(20);
            bst.Add(5);
            bst.Add(3);
            bst.Add(7);

            bst.Delete(5);
            var result = bst.Search(5);

            Assert.Null(result);
            Assert.NotNull(bst.Search(3));
            Assert.NotNull(bst.Search(7));
        }

        [Fact]
        public void GetHeightOfEmptyTreeReturnsMinusOne()
        {
            var bst = new BinarySearchTree<int>();

            var height = bst.GetHeight();

            Assert.Equal(-1, height);
        }

        [Fact]
        public void GetHeightOfTreeWithNodesReturnsCorrectHeight()
        {
            var bst = new BinarySearchTree<int>();
            bst.Add(10);
            bst.Add(20);
            bst.Add(5);
            bst.Add(3);
            bst.Add(7);

            var height = bst.GetHeight();

            Assert.Equal(2, height); 
        }
    }
}
