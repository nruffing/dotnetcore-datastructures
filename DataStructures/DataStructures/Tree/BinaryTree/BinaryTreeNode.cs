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

        public IList<ITreeNode<T>> Children
        {
            get
            {
                IList<ITreeNode<T>> children = new List<ITreeNode<T>>(2);
                children.Add(Left);
                children.Add(Right);
                return children;
            }
        }
    }
}
