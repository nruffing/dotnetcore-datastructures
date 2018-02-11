namespace DataStructures.List.LinkedList
{
    public class LinkedListNode<T> : ILinkedListNode<T>
    {
        public LinkedListNode()
        {
            
        }

        public LinkedListNode(T value)
        {
            Value = value;    
        }

        public T Value { get; set; }

        public ILinkedListNode<T> Next { get; set; }

        public ILinkedListNode<T> Previous { get; set; }
    }
}
