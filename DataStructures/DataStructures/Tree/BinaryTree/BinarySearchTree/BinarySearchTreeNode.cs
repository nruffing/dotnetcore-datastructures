using System;

namespace DataStructures.Tree.BinaryTree.BinarySearchTree
{
    public class BinarySearchTreeNode<T> : BinaryTreeNode<T> where T : IComparable<T>
    {
        public BinarySearchTreeNode()
        {
        }

        public BinarySearchTreeNode(T value)
            : base(value)
        {
        }

        public override void AddChild(T value)
        {
            if (value.CompareTo(this.Value) < 0) // if the nodes value is less than this nodes value
            {
                if (this.Left == null)
                {
                    this.Left = new BinarySearchTreeNode<T>(value);
                }
                else
                {
                    this.Left.AddChild(value);
                }
            }
            else
            {
                if (this.Right == null)
                {
                    this.Right = new BinarySearchTreeNode<T>(Value);
                }
                else
                {
                    this.Right.AddChild(value);
                }
            }
        }
    }
}
