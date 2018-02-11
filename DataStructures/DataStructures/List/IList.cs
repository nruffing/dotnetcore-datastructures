namespace DataStructures.List
{
    public interface IList<T>
    {
        T this[int index] { get; set; }

        long Count { get; }
    }
}
