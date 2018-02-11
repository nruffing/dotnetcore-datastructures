using DataStructures.List.LinkedList;
using DataStructures.Exceptions;

namespace DataStructures.Queue
{
    public class Queue<T> : IQueue<T>
    {
        private ILinkedList<T> _list;

        public Queue()
        {
            _list = new LinkedList<T>();
        }
        public long Count { get; private set; }

        public void Enqueue(T value)
        {
            _list.AddFirst(value);

            Count++;
        }

        public T Dequeue()
        {
            if (_list.Last == null)
            {
                throw new CollectionEmptyException();
            }

            Count--;

            return _list.RemoveLast();
        }

        public T Peek()
        {
            if (_list.Last == null)
            {
                throw new CollectionEmptyException();
            }

            return _list.Last.Value;
        }
    }
}
