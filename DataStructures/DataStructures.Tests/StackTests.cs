using Xunit;
using DataStructures.Stack;
using DataStructures.Exceptions;

namespace DataStructures.Tests
{
    public class StackTests
    {
        [Fact]
        public void ConstructionTest()
        {
            IStack<int> stack = new Stack<int>();
            Assert.Equal(0, stack.Count);
        }

        [Fact]
        public void EmptyPeekTest()
        {
            IStack<int> stack = new Stack<int>();
            Assert.Throws<CollectionEmptyException>(() => stack.Peek());
        }

        [Fact]
        public void EmptyPopTest()
        {
            IStack<int> stack = new Stack<int>();
            Assert.Throws< CollectionEmptyException>(() => stack.Pop());
        }

        [Fact]
        public void PushTest()
        {
            IStack<int> stack = new Stack<int>();
            stack.Push(1);

            Assert.Equal(1, stack.Count);
            Assert.Equal(1, stack.Peek());
        }

        [Fact]
        public void PeekTest()
        {
            IStack<int> stack = new Stack<int>();
            stack.Push(1);

            Assert.Equal(1, stack.Peek());
            Assert.Equal(1, stack.Count);
        }

        [Fact]
        public void PopTest()
        {
            IStack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);

            Assert.Equal(2, stack.Count);
            Assert.Equal(2, stack.Peek());
            Assert.Equal(2, stack.Pop());
            Assert.Equal(1, stack.Count);
        }
    }
}