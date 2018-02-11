using System;
using DataStructures.Exceptions;

namespace DataStructures.List.LinkedList
{
    public class LinkedList<T> : ILinkedList<T>
    {
        public T this[int index] 
        { 
            get 
            {
                return Get(index);
            }
            set 
            {
                Set(index, value);
            }
        }

        public int Count { get; private set; }

        public ILinkedListNode<T> First { get; private set; }

        public ILinkedListNode<T> Last { get; private set; }

        public void AddFirst(T value)
        {
            VerifyCollectionHasRoom();

            ILinkedListNode<T> node = new LinkedListNode<T>(value);

            // If first is null than this linked list is empty and we should set First and Last to the new node.
            if (First == null)
            {
                First = node;
                Last = node;
            }
            else
            {
                // We need to set the current First node as the next node of the current node and then set Previous
                // of the current First node to the new node.
                node.Next = First;
                First.Previous = node;
                First = node;
            }

            Count++;
        }

        public void AddLast(T value)
        {
            VerifyCollectionHasRoom();

            ILinkedListNode<T> node = new LinkedListNode<T>(value);

            // If first is null than this linked list is empty and we should set First and Last to the new node.
            if (First == null)
            {
                First = node;
                Last = node;
            }
            else
            {
                // We need to set Next of the Last node to the new node and Previous of the new Node to the current Last node.
                Last.Next = node;
                node.Previous = Last;
                Last = node;
            }

            Count++;
        }

        public void Remove(ILinkedListNode<T> node)
        {
            if (node == null)
            {
                throw new ArgumentException("Cannot remove a null node", nameof(node));
            }

            // TODO: Should we verify that this node is actually part of this list?

            if (node.Previous != null)
            {
                node.Previous.Next = node.Next;
            }

            if (node.Next != null)
            {
                node.Next.Previous = node.Previous;
            }

            Count--;
        }

        public T RemoveFirst()
        {
            if (First == null)
            {
                throw new CollectionEmptyException();
            }

            T result = First.Value;
            Remove(First);
            return result;
        }

        public T RemoveLast()
        {
            if (Last == null)
            {
                throw new CollectionEmptyException();
            }

            T result = Last.Value;
            Remove(Last);
            return result;
        }

        public void Add(T value)
        {
            AddLast(value);
        }

        private T Get(int index)
        {
            VerifyIndexIsInBounds(index);

            return GetNode(index).Value;
        }

        private void Set(int index, T value)
        {
            VerifyIndexIsInBounds(index);

            GetNode(index).Value = value;
        }

        private ILinkedListNode<T> GetNode(int index)
        {
            int searchIndex = 0;
            ILinkedListNode<T> node = First;

            while (searchIndex < index)
            {
                node = node.Next;
                searchIndex++;
            }

            return node;
        }

        private void VerifyIndexIsInBounds(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException();
            }
        }

        private void VerifyCollectionHasRoom()
        {
            if (Count >= Int32.MaxValue)
            {
                throw new CollectionFullException();
            }
        }
    }
}
