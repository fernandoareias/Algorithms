using Xunit;
using System;

namespace Algorithm.Tests
{
    public class QueueTests
    {
        [Fact]
        public void EnqueueShouldIncreaseCount()
        {
            
            var queue = new Queue<int>();
            
            
            queue.Enqueue(1);
            
            
            Assert.Equal(1, queue.Count);
        }
        
        [Fact]
        public void DequeueShouldReturnFirstElement()
        {
            
            var queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            
            
            var result = queue.Dequeue();
            
            
            Assert.Equal(1, result);
            Assert.Equal(1, queue.Count);
        }
        
        [Fact]
        public void PeekShouldReturnFirstElementWithoutRemoving()
        {
            
            var queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            
            
            var result = queue.Peek();
            
            
            Assert.Equal(1, result);
            Assert.Equal(2, queue.Count); // Count should be unchanged
        }
        
        [Fact]
        public void DequeueShouldThrowExceptionWhenQueueIsEmpty()
        {
            
            var queue = new Queue<int>();
            
            Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
        }
        
        [Fact]
        public void PeekShouldThrowExceptionWhenQueueIsEmpty()
        {
            
            var queue = new Queue<int>();
            
            Assert.Throws<InvalidOperationException>(() => queue.Peek());
        }
        
        [Fact]
        public void ClearShouldResetQueue()
        {
            
            var queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            
            
            queue.Clear();
            
            
            Assert.Equal(0, queue.Count);
            Assert.Throws<InvalidOperationException>(() => queue.Peek());
        }
        
        [Fact]
        public void EnqueueShouldResizeArrayWhenFull()
        {
            
            var queue = new Queue<int>(2, 2.0f); // Small capacity to force resizing
            queue.Enqueue(1);
            queue.Enqueue(2);
            
            
            queue.Enqueue(3); // This should trigger a resize
            
            
            Assert.Equal(3, queue.Count);
            Assert.Equal(1, queue.Dequeue()); // Ensure the queue still works
        }
        
        [Fact]
        public void ToArrayShouldReturnCorrectArrayRepresentation()
        {
            
            var queue = new Queue<int>(4);
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            
            
            var resultArray = queue.ToArray();
            
            
            Assert.Equal(new int[] { 1, 2, 3 }, resultArray);
        }
    }
}
