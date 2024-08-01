using System;
using Xunit;
using Algorithm;

namespace Algorithm.Tests
{
    public class BTreeTests
    {
        [Fact]
        public void InsertAndSearchSingleElementReturnsCorrectValue()
        {
            
            var bTree = new BTree<int, string>(2);
            
            
            bTree.Insert(10, "Value10");
            var result = bTree.Search(10);
            
            
            Assert.Equal("Value10", result);
        }
        
        [Fact]
        public void InsertAndSearchUsingRecursionReturnsCorrectValue()
        {
            
            var bTree = new BTree<int, string>(2);
            
            bTree.Insert(10, "Value10");
            var result = bTree.SearchWithRecursion(10);
            
            
            Assert.Equal("Value10", result);
        }
        
        [Fact]
        public void InsertAndSearchMultipleElementsReturnsCorrectValues()
        {
            
            var bTree = new BTree<int, string>(2);
            
            
            bTree.Insert(10, "Value10");
            bTree.Insert(20, "Value20");
            bTree.Insert(5, "Value5");
            
            var result10 = bTree.Search(10);
            var result20 = bTree.Search(20);
            var result5 = bTree.Search(5);
            
            
            Assert.Equal("Value10", result10);
            Assert.Equal("Value20", result20);
            Assert.Equal("Value5", result5);
        }

        [Fact]
        public void SearchKeyNotFoundThrowsKeyNotFoundException()
        {
            
            var bTree = new BTree<int, string>(2);
            
            
            bTree.Insert(10, "Value10");
            
            
            Assert.Throws<KeyNotFoundException>(() => bTree.Search(20));
        }

        [Fact]
        public void InsertAndSplitNodeDegree2SplitsCorrectly()
        {
            
            var bTree = new BTree<int, string>(2);
            
            
            bTree.Insert(10, "Value10");
            bTree.Insert(20, "Value20");
            bTree.Insert(5, "Value5");
            bTree.Insert(6, "Value6");
            bTree.Insert(15, "Value15");
            
            
            var result10 = bTree.Search(10);
            var result20 = bTree.Search(20);
            var result5 = bTree.Search(5);
            var result6 = bTree.Search(6);
            var result15 = bTree.Search(15);
            
            Assert.Equal("Value10", result10);
            Assert.Equal("Value20", result20);
            Assert.Equal("Value5", result5);
            Assert.Equal("Value6", result6);
            Assert.Equal("Value15", result15);
        }
    }
}
