namespace DataStructures.Tree.BinaryTree
{
    public interface IBinaryTreeNode<T> : ITreeNode<T>
    {
        IBinaryTreeNode<T> Left { get; set; }

        IBinaryTreeNode<T> Right { get; set; }

        IBinaryTreeNode<T> Parent { get; set; }
    }
}
