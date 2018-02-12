using DataStructures.List;

namespace DataStructures.Tree.BinaryTree
{
    public class BinaryTreeNode<T> : IBinaryTreeNode<T>
    {
        public BinaryTreeNode()
        {
        }

        public BinaryTreeNode(T value)
        {
            Value = value;
        }

        public T Value { get; set; }

        public IBinaryTreeNode<T> Left { get; set; }

        public IBinaryTreeNode<T> Right { get; set; }

        public IBinaryTreeNode<T> Parent { get; set; }

        public IList<ITreeNode<T>> Children => throw new System.NotImplementedException();

        public virtual void AddChild(T value)
        {
            throw new System.NotImplementedException();
        }
    }
}
