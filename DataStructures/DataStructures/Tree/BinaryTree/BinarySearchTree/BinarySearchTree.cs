namespace DataStructures.Tree.BinaryTree.BinarySearchTree
{
    public class BinarySearchTree<T> : ITree<T>
    {
        private IBinaryTreeNode<T> _root;

        public ITreeNode<T> Root => _root;

        public int Count { get; private set; }

        public void Add(T value)
        {
            IBinaryTreeNode<T> node = new BinaryTreeNode<T>(value);

            if (_root == null)
            {
                _root = node;
            }
            else
            {
                _root.AddChild(value);
            }
        }
    }
}
