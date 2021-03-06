﻿namespace DataStructures.Tree
{
    public interface ITree<T> : ICollection
    {
        ITreeNode<T> Root { get; }

        void Add(T value);
    }
}
