using DataStructures.List.LinkedList;
using DataStructures.Exceptions;

namespace DataStructures.Stack
{
    public class Stack<T> : IStack<T>
    {
        private ILinkedList<T> _list;

        public Stack()
        {
            _list = new LinkedList<T>();
        }

        public long Count { get; }

        public void Push(T value)
        {
            _list.AddLast(value);
        }

        public T Pop()
        {
            if (_list.Last == null)
            {
                throw new CollectionEmptyException();
            }

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
