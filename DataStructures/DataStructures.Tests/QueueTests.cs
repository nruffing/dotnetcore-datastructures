using Xunit;
using DataStructures.Queue;
using DataStructures.Exceptions;

namespace DataStructures.Tests
{
    public class QueueTests
    {
        [Fact]
        public void ConstructionTest()
        {
            IQueue<int> queue = new Queue<int>();
            Assert.Equal(0, queue.Count);
        }

        [Fact]
        public void EmptyPeekTest()
        {
            IQueue<int> queue = new Queue<int>();
            Assert.Throws<CollectionEmptyException>(() => queue.Peek());
        }

        [Fact]
        public void EmptyDequeueTest()
        {
            IQueue<int> queue = new Queue<int>();
            Assert.Throws<CollectionEmptyException>(() => queue.Dequeue());
        }

        [Fact]
        public void EnqueueTest()
        {
            IQueue<int> queue = new Queue<int>();
            queue.Enqueue(1);

            Assert.Equal(1, queue.Count);
            Assert.Equal(1, queue.Peek());
        }

        [Fact]
        public void PeekTest()
        {
            IQueue<int> queue = new Queue<int>();
            queue.Enqueue(1);

            Assert.Equal(1, queue.Peek());
            Assert.Equal(1, queue.Count);
        }

        [Fact]
        public void DequeueTest()
        {
            IQueue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);

            Assert.Equal(2, queue.Count);
            Assert.Equal(1, queue.Peek());
            Assert.Equal(1, queue.Dequeue());
            Assert.Equal(1, queue.Count);
        }
    }
}
