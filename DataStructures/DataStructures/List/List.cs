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

            _array[Count] = value;

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
