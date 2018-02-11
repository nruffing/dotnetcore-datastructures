using System;
using Xunit;
using DataStructures.List;

namespace DataStructures.Tests
{
    public class ListTests
    {
        [Fact]
        public void ConstructionTest()
        {
            IList<int> list = new List<int>();
            Assert.Equal(0, list.Count);

            list = new List<int>(6);
            Assert.Equal(0, list.Count);

            Assert.Throws<ArgumentException>(() => list = new List<int>(-1));
        }

        [Fact]
        public void GetIndexerTest()
        {
            IList<int> list = new List<int>(2);

            Assert.Throws<IndexOutOfRangeException>(() => list[-1]);
            Assert.Throws<IndexOutOfRangeException>(() => list[1]);

            list.Add(3);
            list.Add(4);

            Assert.Equal(4, list[1]);
        }

        [Fact]
        public void SetIndexerTest()
        {
            IList<int> list = new List<int>(2);

            Assert.Throws<IndexOutOfRangeException>(() => list[-1] = 1);
            Assert.Throws<IndexOutOfRangeException>(() => list[1] = 1);

            list.Add(3);
            list.Add(4);
            list[1] = 5;

            Assert.Equal(5, list[1]);
        }

        [Fact]
        public void AddTest()
        {
            IList<int> list = new List<int>(1);

            list.Add(1);

            Assert.Equal(1, list.Count);
            Assert.Equal(1, list[0]);

            list.Add(2);
            list.Add(3);

            Assert.Equal(3, list.Count);
            Assert.Equal(1, list[0]);
            Assert.Equal(2, list[1]);
            Assert.Equal(3, list[2]);
        }

        [Fact]
        public void RemoveFromIndexOutOfBoundsTest()
        {
            IList<int> list = new List<int>();

            Assert.Throws<IndexOutOfRangeException>(() => list.Remove(-1));

            list.Add(1);

            Assert.Throws<IndexOutOfRangeException>(() => list.Remove(1));
        }

        [Fact]
        public void RemoveFromIndexTest()
        {
            IList<int> list = new List<int>();
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
            IList<int> list = new List<int>();
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
