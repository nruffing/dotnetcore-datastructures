namespace DataStructures.List.LinkedList
{
    public interface ILinkedList<T> : IList<T>
    {
        ILinkedListNode<T> First { get; }

        ILinkedListNode<T> Last { get; }

        void AddFirst(T value);

        void AddLast(T value);

        void Remove(ILinkedListNode<T> node);

        T RemoveLast();

        T RemoveFirst();
    }
}
