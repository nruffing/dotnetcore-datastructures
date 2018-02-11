namespace DataStructures.Queue
{
    public interface IQueue<T> : ICollection
    {
        void Enqueue(T value);

        T Dequeue();

        T Peek();
    }
}
