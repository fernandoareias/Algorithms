using System;
using System.Collections.Generic;
using Xunit;

namespace Algorithm.Tests
{
    public class DoubleLinkedListTests
    {
        [Fact]
        public void AddHeadShouldAddNodeToHead()
        {
            var list = new DoubleLinkedList<int>();
            list.AddHead(1);
            list.AddHead(2);
            list.AddHead(3);

            var result = list.ToList();
            Assert.Equal(new List<int> { 3, 2, 1 }, result);
        }

        [Fact]
        public void AddTailShouldAddNodeToTail()
        {
            var list = new DoubleLinkedList<int>();
            list.AddTail(1);
            list.AddTail(2);
            list.AddTail(3);

            var result = list.ToList();
            Assert.Equal(new List<int> { 1, 2, 3 }, result);
        }

        [Fact]
        public void RemoveHeadShouldRemoveNodeFromHead()
        {
            var list = new DoubleLinkedList<int>();
            list.AddTail(1);
            list.AddTail(2);
            list.AddTail(3);
            list.RemoveHead();

            var result = list.ToList();
            Assert.Equal(new List<int> { 2, 3 }, result);
        }

        [Fact]
        public void RemoveTailShouldRemoveNodeFromTail()
        {
            var list = new DoubleLinkedList<int>();
            list.AddTail(1);
            list.AddTail(2);
            list.AddTail(3);
            list.RemoveTail();

            var result = list.ToList();
            Assert.Equal(new List<int> { 1, 2 }, result);
        }

        [Fact]
        public void ContainsShouldReturnTrueIfValueExists()
        {
            var list = new DoubleLinkedList<int>();
            list.AddTail(1);
            list.AddTail(2);
            list.AddTail(3);

            Assert.True(list.Contains(2));
            Assert.False(list.Contains(4));
        }

        [Fact]
        public void RemoveShouldRemoveNodeByValue()
        {
            var list = new DoubleLinkedList<int>();
            list.AddTail(1);
            list.AddTail(2);
            list.AddTail(3);
            list.Remove(2);

            var result = list.ToList();
            Assert.Equal(new List<int> { 1, 3 }, result);
        }

        [Fact]
        public void FindShouldReturnNodeIfValueExists()
        {
            var list = new DoubleLinkedList<int>();
            list.AddTail(1);
            list.AddTail(2);
            list.AddTail(3);

            var node = list.Find(2);
            Assert.NotNull(node);
            Assert.Equal(2, node?.Value);
        }

        [Fact]
        public void ClearShouldRemoveAllNodes()
        {
            var list = new DoubleLinkedList<int>();
            list.AddTail(1);
            list.AddTail(2);
            list.AddTail(3);
            list.Clear();

            Assert.Equal((uint)0, list.Count);
            Assert.False(list.Contains(1));
            Assert.False(list.Contains(2));
            Assert.False(list.Contains(3));
        }

        [Fact]
        public void ToListShouldReturnAllValuesInOrder()
        {
            var list = new DoubleLinkedList<int>();
            list.AddTail(1);
            list.AddTail(2);
            list.AddTail(3);

            var result = list.ToList();
            Assert.Equal(new List<int> { 1, 2, 3 }, result);
        }
    }
}
