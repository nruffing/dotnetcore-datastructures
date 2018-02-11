namespace DataStructures.Stack
{
    public interface IStack<T> : ICollection
    {
        void Push(T value);

        T Pop();

        T Peek();
    }
}
