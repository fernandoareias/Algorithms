using Xunit;

namespace Algorithm.Tests
{
    public class LinkedListFloydCycleFindingTests
    {
        [Fact]
        public void HasCycleShouldReturnFalseWhenListIsEmpty()
        {
            LinkedListNode<int>? root = null;

            var hasCycle = LinkedListFloydCycleFinding.HasCycle(root);

            Assert.False(hasCycle);
        }

        [Fact]
        public void HasCycleShouldReturnFalseWhenListHasOneElementWithoutCycle()
        {
            var node = new LinkedListNode<int>(1);
            LinkedListNode<int> root = node;

            var hasCycle = LinkedListFloydCycleFinding.HasCycle(root);

            Assert.False(hasCycle);
        }

        [Fact]
        public void HasCycleShouldReturnTrueWhenListHasOneElementWithCycle()
        {
            var node = new LinkedListNode<int>(1);
            node.Next = node; 
            LinkedListNode<int> root = node;

            var hasCycle = LinkedListFloydCycleFinding.HasCycle(root);

            Assert.True(hasCycle);
        }

        [Fact]
        public void HasCycleShouldReturnTrueWhenListHasCycle()
        {
            var node1 = new LinkedListNode<int>(1);
            var node2 = new LinkedListNode<int>(2);
            var node3 = new LinkedListNode<int>(3);
            var node4 = new LinkedListNode<int>(4);
            var node5 = new LinkedListNode<int>(5);

            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;
            node4.Next = node5;
            node5.Next = node3; 

            LinkedListNode<int> root = node1;

            var hasCycle = LinkedListFloydCycleFinding.HasCycle(root);

            Assert.True(hasCycle);
        }

        [Fact]
        public void HasCycleShouldReturnFalseWhenListHasNoCycle()
        {
            var node1 = new LinkedListNode<int>(1);
            var node2 = new LinkedListNode<int>(2);
            var node3 = new LinkedListNode<int>(3);
            var node4 = new LinkedListNode<int>(4);
            var node5 = new LinkedListNode<int>(5);

            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;
            node4.Next = node5;

            LinkedListNode<int> root = node1;

            var hasCycle = LinkedListFloydCycleFinding.HasCycle(root);

            Assert.False(hasCycle);
        }
    }
}
