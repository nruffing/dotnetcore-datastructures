namespace DataStructures.List.LinkedList
{
    public interface ILinkedListNode<T>
    {
        T Value { get; set; }

        ILinkedListNode<T> Next { get; set; }

        ILinkedListNode<T> Previous { get; set; }
    }
}
