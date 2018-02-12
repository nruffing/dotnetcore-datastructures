namespace DataStructures.Tree.BinaryTree.BinarySearchTree
{
    public interface IBinarySearchTreeNode<T> : IBinaryTreeNode<T>
    {
        bool IsBlack { get; set; }

        new IBinarySearchTreeNode<T> Left { get; set; }

        new IBinarySearchTreeNode<T> Right { get; set; }

        new IBinarySearchTreeNode<T> Parent { get; set; }
    }
}
