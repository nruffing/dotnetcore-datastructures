using System;

namespace DataStructures.Tree.BinaryTree.BinarySearchTree
{
    /// <summary>
    /// Implementation of a self-balancing red-black binary search tree node. 
    /// </summary>
    public class BinarySearchTreeNode<T> : BinaryTreeNode<T>, IBinarySearchTreeNode<T> where T : IComparable<T>
    {
        public BinarySearchTreeNode()
        {
        }

        public BinarySearchTreeNode(T value)
            : base(value)
        {
        }

        public new IBinarySearchTreeNode<T> Left { get; set; }

        public new IBinarySearchTreeNode<T> Right { get; set; }

        public new IBinarySearchTreeNode<T> Parent { get; set; }

        public bool IsBlack { get; set; }

        public override void AddChild(T value)
        {
            if (value.CompareTo(this.Value) < 0) // if the nodes value is less than this nodes value
            {
                if (this.Left == null)
                {
                    IBinarySearchTreeNode<T> newNode = new BinarySearchTreeNode<T>(value);
                    this.Left = newNode;
                    this.Left.Parent = this;
                    // this.Left.IsBlack = false; // New leaf nodes should always be red

                    Balance(newNode);
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
                    IBinarySearchTreeNode<T> newNode = new BinarySearchTreeNode<T>(value);
                    this.Right = newNode;
                    this.Right.Parent = this;
                    // this.Right.IsBlack = false; // New leaf nodes should always be red

                    Balance(newNode);
                }
                else
                {
                    this.Right.AddChild(value);
                }
            }
        }

        private static void Balance(IBinarySearchTreeNode<T> newNode)
        {
            IBinarySearchTreeNode<T> parent = newNode.Parent;
            if (parent != null)
            {
                if (!parent.IsBlack) // We have a red violation
                {
                    IBinarySearchTreeNode<T> uncle = GetSibling(parent);
                    if (uncle == null || uncle.IsBlack)
                    {
                        // the uncle is black
                        // TODO
                    }
                    else // the uncle is red
                    {
                        parent.IsBlack = true;
                        uncle.IsBlack = true;

                        IBinarySearchTreeNode<T> grandparent = parent.Parent; // Since we are able to get the uncle we know that the grandparent exists
                        grandparent.IsBlack = false;

                        Balance(grandparent);
                    }
                }
                // else the parent node of the new node is black and the tree is already balanced
            }
            else
            {
                // this must be the root node, ensure it is black
                newNode.IsBlack = true;
            }
        }

        private static IBinarySearchTreeNode<T> GetSibling(IBinarySearchTreeNode<T> node)
        {
            IBinarySearchTreeNode<T> sibling = null;

            if (node.Parent != null)
            {
                if (node.Parent.Left == node)
                {
                    sibling = node.Parent.Right;
                }
                else
                {
                    sibling = node.Parent.Left;
                }
            }

            return sibling;
        }
    }
}
