using System;

namespace DataStructures.List
{
    public class List<T> : IList<T>
    {
        private const int DEFAULT_SIZE = 4;

        private T[] _array;

        public List()
            : this(DEFAULT_SIZE)
        {
        }

        public List(int size)
        {
            if (size < 0)
            {
                throw new ArgumentException("List must have a positive size.", nameof(size));
            }

            _array = new T[size];
        }

        public int Count { get; private set; }

        public T this[int index] 
        { 
            get 
            {
                VerifyIndexIsInBounds(index);
                return _array[index];
            }
            set 
            {
                VerifyIndexIsInBounds(index);
                _array[index] = value;
            }
        }

        public void Add(T value)
        {
            EnsureArrayHasRoom();

            _array[Count++] = value;
        }

        public T Remove(int index)
        {
            VerifyIndexIsInBounds(index);

            T result = _array[index];

            // If we have more than 1 element or we are not removing the last element
            // we need to shift all the elements after the one being removed.
            if (Count > 1 && index != Count - 1)
            {
                for (int i = index + 1; i < Count; i++)
                {
                    _array[i - 1] = _array[i];
                }
            }

            // Otherwise we just need to decrement the count
            Count--;

            return result;
        }

        public void Insert(T value, int index)
        {
            if (index < 0 || index > Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            EnsureArrayHasRoom();

            if (Count > 0 || index != Count)
            {
                // Move all elements after the insertion point one index
                for (int i = Count - 1; i >= index; i--)
                {
                    _array[i + 1] = _array[i];
                }
            }

            _array[index] = value;

            Count++;
        }

        private void EnsureArrayHasRoom()
        {
            // This method assumes that one element is going to be added to the list.

            if (Count == _array.Length)
            {
                // We need to make the array bigger to have enough room for the new element.
                // We will create a new array that is twice the size of the current one unless
                // that will overlow Int32.MaxValue in which the new array will get a size of
                // Int32.MaxValue.  The current array will then be copied into the new array.

                long newSize = _array.Length * 2;
                if (newSize > Int32.MaxValue)
                {
                    newSize = Int32.MaxValue;
                }

                T[] newArray = new T[newSize];

                for (int i = 0; i < Count; i++)
                {
                    newArray[i] = _array[i];
                }

                _array = newArray;
            }
        }

        private void VerifyIndexIsInBounds(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException();
            }
        }
    }
}
