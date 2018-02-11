namespace DataStructures.List
{
    public interface IList<T> : ICollection
    {
        T this[int index] { get; set; }

        void Add(T value);
    }
}
