using DataStructures.List;

namespace DataStructures.Tree
{
    public interface ITreeNode<T>
    {
        T Value { get; set; }

        IList<ITreeNode<T>> Children { get; }
    }
}
