using Algorithm;

using Xunit;

namespace LinkedListTests
{
    public class LinkedListTests
    {
        [Fact]
        public void AddHeadShouldAddNodeAtHead()
        {
            
            var list = new Algorithm.LinkedList<int>();

            
            list.AddHead(1);
            list.AddHead(2);

            
            Assert.NotNull(list.Root);
            Assert.Equal(2, list.Root.Value);
            Assert.NotNull(list.Root.Next);
            Assert.Equal(1, list.Root.Next.Value);
            Assert.Null(list.Root.Next.Next);
            Assert.Equal(2u, list.Count);
        }

        [Fact]
        public void AddTailShouldAddNodeAtTail()
        {
            
            var list = new Algorithm.LinkedList<int>();
            list.AddHead(1);

            
            list.AddTail(2);

            
            Assert.NotNull(list.Root);
            Assert.NotNull(list.Root.Next);
            Assert.Equal(1, list.Root.Value);
            Assert.Equal(2, list.Root.Next.Value);
            Assert.Null(list.Root.Next.Next);
            Assert.Equal(2u, list.Count);
        }

        [Fact]
        public void ContainsShouldReturnTrueIfNodeExists()
        {
            
            var list = new Algorithm.LinkedList<int>();
            list.AddHead(1);
            list.AddHead(2);

            
            var result = list.Contains(1);

            
            Assert.True(result);
        }

        [Fact]
        public void ContainsShouldReturnFalseIfNodeDoesNotExist()
        {
            
            var list = new Algorithm.LinkedList<int>();
            list.AddHead(1);
            list.AddHead(2);

            
            var result = list.Contains(3);

            
            Assert.False(result);
        }

        [Fact]
        public void RemoveShouldRemoveNode()
        {
            
            var list = new Algorithm.LinkedList<int>();
            list.AddHead(1);
            list.AddHead(2);
            list.AddHead(3);

            
            list.Remove(2);

            
            Assert.NotNull(list.Root);
            Assert.Equal(3, list.Root.Value);
            Assert.NotNull(list.Root.Next);
            Assert.Equal(1, list.Root.Next.Value);
            Assert.Null(list.Root.Next.Next);
            Assert.Equal(2u, list.Count);
        }

        [Fact]
        public void RemoveHeadShouldRemoveHeadNode()
        {
            
            var list = new Algorithm.LinkedList<int>();
            list.AddHead(1);
            list.AddHead(2);

            
            list.RemoveHead();

            
            Assert.NotNull(list.Root);
            Assert.Equal(1, list.Root.Value);
            Assert.Null(list.Root.Next);
            Assert.Equal(1u, list.Count);
        }

        [Fact]
        public void RemoveTailShouldRemoveTailNode()
        {
            
            var list = new Algorithm.LinkedList<int>();
            list.AddHead(1);
            list.AddHead(2);

            
            list.RemoveTail();

            
            Assert.NotNull(list.Root);
            Assert.Equal(2, list.Root.Value);
            Assert.Null(list.Root.Next);
            Assert.Equal(1u, list.Count);
        }
    }
}
