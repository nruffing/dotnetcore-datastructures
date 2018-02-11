using System;
using Xunit;
using DataStructures.List.LinkedList;

namespace DataStructures.Tests
{
    public class LinkedLiskTests
    {
        [Fact]
        public void ConstructionTest()
        {
            ILinkedList<int> list = new LinkedList<int>();
            Assert.Null(list.First);
            Assert.Null(list.Last);
            Assert.Equal(0, list.Count);
        }

        [Fact]
        public void AddFirstNodeFromFrontTest()
        {
            ILinkedList<int> list = new LinkedList<int>();
            list.AddFirst(2);
            Assert.NotNull(list.First);
            Assert.Same(list.First, list.Last);
            Assert.Equal(2, list.First.Value);
            Assert.Equal(1, list.Count);
        }

        [Fact]
        public void AddFirstNodeFromBackTest()
        {
            ILinkedList<int> list = new LinkedList<int>();
            list.AddLast(2);
            Assert.NotNull(list.First);
            Assert.Same(list.First, list.Last);
            Assert.Equal(2, list.First.Value);
            Assert.Equal(1, list.Count);
        }

        [Fact]
        public void AddFirstTest()
        {
            ILinkedList<int> list = new LinkedList<int>();
            list.AddLast(2);
            list.AddFirst(1);

            Assert.NotNull(list.First);
            Assert.NotNull(list.Last);
            Assert.NotSame(list.First, list.Last);
            Assert.Equal(1, list.First.Value);
            Assert.Equal(2, list.Last.Value);
            Assert.Equal(2, list.Count);

            Assert.Same(list.First.Next, list.Last);
            Assert.Same(list.Last.Previous, list.First);
        }

        [Fact]
        public void AddLastTest()
        {
            ILinkedList<int> list = new LinkedList<int>();
            list.AddFirst(1);
            list.AddLast(2);

            Assert.NotNull(list.First);
            Assert.NotNull(list.Last);
            Assert.NotSame(list.First, list.Last);
            Assert.Equal(1, list.First.Value);
            Assert.Equal(2, list.Last.Value);
            Assert.Equal(2, list.Count);

            Assert.Same(list.First.Next, list.Last);
            Assert.Same(list.Last.Previous, list.First);
        }

        [Fact]
        public void RemoveTest()
        {
            ILinkedList<int> list = new LinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);

            Assert.Equal(3, list.Count);

            list.Remove(list.First.Next); // remove second node

            Assert.Equal(2, list.Count);

            Assert.Same(list.First.Next, list.Last);
            Assert.Same(list.Last.Previous, list.First);
        }

        [Fact]
        public void GetIndexerTest()
        {
            ILinkedList<int> list = new LinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);

            Assert.Equal(2, list[1]);
        }

        [Fact]
        public void SetIndexerTest()
        {
            ILinkedList<int> list = new LinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);

            list[1] = 4;
            Assert.Equal(4, list[1]);
        }

        [Fact]
        public void IndexOutOfRangeTest()
        {
            ILinkedList<int> list = new LinkedList<int>();

            Assert.Throws<IndexOutOfRangeException>(() => list[0]);

            list.AddLast(1);

            Assert.Throws<IndexOutOfRangeException>(() => list[1]);
            Assert.Throws<IndexOutOfRangeException>(() => list[-1]);
        }

        [Fact]
        public void RemoveNullThrows()
        {
            ILinkedList<int> list = new LinkedList<int>();

            Assert.Throws<ArgumentException>(() => list.Remove(null));
        }

        [Fact]
        public void RemoveFromIndexOutOfBoundsTest()
        {
            ILinkedList<int> list = new LinkedList<int>();

            Assert.Throws<IndexOutOfRangeException>(() => list.Remove(-1));

            list.Add(1);

            Assert.Throws<IndexOutOfRangeException>(() => list.Remove(1));
        }

        [Fact]
        public void RemoveFromIndexTest()
        {
            ILinkedList<int> list = new LinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            Assert.Equal(2, list.Remove(1));
            Assert.Equal(2, list.Count);
            Assert.Equal(1, list[0]);
            Assert.Equal(3, list[1]);
        }

        [Fact]
        public void RemoveLastElementFromIndexTest()
        {
            ILinkedList<int> list = new LinkedList<int>();
            list.Add(1);

            list.Remove(0);
            Assert.Equal(0, list.Count);

            list.Add(1);
            list.Add(2);

            list.Remove(1);
            Assert.Equal(1, list.Count);
        }
    }
}