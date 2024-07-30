using System;
using Xunit;

namespace Algorithm.Tests
{
    public class StackTests
    {
        [Fact]
        public void PushShouldIncreaseCount()
        {
            
            var stack = new Stack<int>();

            
            stack.Push(1);
            stack.Push(2);

            
            Assert.Equal(2, stack.Count);
        }

        [Fact]
        public void PopShouldReturnLastPushedElement()
        {
            
            var stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);

            
            var result = stack.Pop();

            
            Assert.Equal(2, result);
            Assert.Equal(1, stack.Count);
        }

        [Fact]
        public void PopShouldThrowExceptionWhenStackIsEmpty()
        {
            
            var stack = new Stack<int>();

            Assert.Throws<InvalidOperationException>(() => stack.Pop());
        }

        [Fact]
        public void PeekShouldReturnLastPushedElementWithoutRemovingIt()
        {
            
            var stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);

            
            var result = stack.Peek();

            
            Assert.Equal(2, result);
            Assert.Equal(2, stack.Count);
        }

        [Fact]
        public void PeekShouldThrowExceptionWhenStackIsEmpty()
        {
            
            var stack = new Stack<int>();

            Assert.Throws<InvalidOperationException>(() => stack.Peek());
        }

        [Fact]
        public void ClearShouldResetCountToZero()
        {
            
            var stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);

            
            stack.Clear();

            
            Assert.Equal(0, stack.Count);
            Assert.Throws<InvalidOperationException>(() => stack.Peek());
        }

        [Fact]
        public void PushShouldResizeArrayWhenFull()
        {
            
            var stack = new Stack<int>(2); 
            stack.Push(1);
            stack.Push(2);

            
            stack.Push(3); 

            
            Assert.Equal(3, stack.Count);
            Assert.Equal(3, stack.Pop()); 
        }
    }
}
