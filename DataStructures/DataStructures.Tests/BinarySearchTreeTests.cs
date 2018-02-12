using Xunit;
using DataStructures.Tree;
using DataStructures.Tree.BinaryTree.BinarySearchTree;

namespace DataStructures.Tests
{
    public class BinarySearchTreeTests
    {
        [Fact]
        public void ConstructionTest()
        {
            ITree<int> tree = new BinarySearchTree<int>();

            Assert.Equal(0, tree.Count);
            Assert.Null(tree.Root);
        }

        [Fact]
        public void AddFirstNodeTest()
        {
            ITree<int> tree = new BinarySearchTree<int>();
            tree.Add(1);

            Assert.Equal(1, tree.Count);
            Assert.Equal(1, tree.Root.Value);

            IBinarySearchTreeNode<int> rootNode = (IBinarySearchTreeNode<int>)tree.Root;
            Assert.True(rootNode.IsBlack);

            Assert.Null(rootNode.Left);
            Assert.Null(rootNode.Right);
        }

        [Fact]
        public void SimpleRedViolationTest_RedUncle_1()
        {
            ITree<int> tree = new BinarySearchTree<int>();
            tree.Add(3);
            tree.Add(2);
            tree.Add(4);

            IBinarySearchTreeNode<int> rootNode = (IBinarySearchTreeNode<int>)tree.Root;

            Assert.True(rootNode.IsBlack);
            Assert.False(rootNode.Left.IsBlack);
            Assert.False(rootNode.Right.IsBlack);

            tree.Add(1);

            Assert.Equal(4, tree.Count);

            Assert.Equal(3, rootNode.Value);
            Assert.Equal(2, rootNode.Left.Value);
            Assert.Equal(4, rootNode.Right.Value);
            Assert.Equal(1, rootNode.Left.Left.Value);

            Assert.Null(rootNode.Left.Right);
            Assert.Null(rootNode.Left.Left.Left);
            Assert.Null(rootNode.Left.Left.Right);
            Assert.Null(rootNode.Right.Left);
            Assert.Null(rootNode.Right.Right);

            Assert.Same(rootNode, rootNode.Left.Parent);
            Assert.Same(rootNode, rootNode.Right.Parent);
            Assert.Same(rootNode.Left, rootNode.Left.Left.Parent);

            Assert.True(rootNode.IsBlack);
            Assert.True(rootNode.Left.IsBlack);
            Assert.True(rootNode.Right.IsBlack);
            Assert.False(rootNode.Left.Left.IsBlack);
        }

        [Fact]
        public void SimpleRedViolationTest_RedUncle_2()
        {
            ITree<int> tree = new BinarySearchTree<int>();
            tree.Add(5);
            tree.Add(3);
            tree.Add(6);

            IBinarySearchTreeNode<int> rootNode = (IBinarySearchTreeNode<int>)tree.Root;

            Assert.True(rootNode.IsBlack);
            Assert.False(rootNode.Left.IsBlack);
            Assert.False(rootNode.Right.IsBlack);

            tree.Add(4);

            Assert.Equal(4, tree.Count);

            Assert.Equal(5, rootNode.Value);
            Assert.Equal(3, rootNode.Left.Value);
            Assert.Equal(6, rootNode.Right.Value);
            Assert.Equal(4, rootNode.Left.Right.Value);

            Assert.Null(rootNode.Left.Left);
            Assert.Null(rootNode.Left.Right.Left);
            Assert.Null(rootNode.Left.Right.Right);
            Assert.Null(rootNode.Right.Left);
            Assert.Null(rootNode.Right.Right);

            Assert.Same(rootNode, rootNode.Left.Parent);
            Assert.Same(rootNode, rootNode.Right.Parent);
            Assert.Same(rootNode.Left, rootNode.Left.Right.Parent);

            Assert.True(rootNode.IsBlack);
            Assert.True(rootNode.Left.IsBlack);
            Assert.True(rootNode.Right.IsBlack);
            Assert.False(rootNode.Left.Right.IsBlack);
        }
    }
}
