using System;
using DataStructures.Exceptions;

namespace DataStructures.Tree.BinaryTree.BinarySearchTree
{
    /// <summary>
    /// Implementation of a self-balancing red-black binary search tree. 
    /// </summary>
    public class BinarySearchTree<T> : ITree<T> where T : IComparable<T>
    {
        private IBinarySearchTreeNode<T> _root;

        public ITreeNode<T> Root => _root;

        public int Count { get; private set; }

        public void Add(T value)
        {
            if (Count == Int32.MaxValue)
            {
                throw new CollectionFullException();
            }

            if (_root == null)
            {
                _root = new BinarySearchTreeNode<T>(value);
                _root.IsBlack = true; // ensure root node is still black
            }
            else
            {
                _root.AddChild(value);

                // We need to make sure that _root is still the root
                while (_root.Parent != null)
                {
                    _root = _root.Parent;
                }
            }

            Count++;
        }
    }
}
