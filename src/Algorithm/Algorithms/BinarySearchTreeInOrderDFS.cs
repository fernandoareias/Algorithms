using System;
using System.Collections.Generic;

namespace Algorithm
{
    public static class BinarySearchTreeInOrderDFS
    {
        public static List<T> DepthFirstSearch<T>(BinarySearchTree<T> tree) where T : IComparable<T>
        {
            var result = new List<T>();
            var stack = new Stack<BinarySearchTreeNode<T>>();
            var current = tree.Root;

            while (current != null || stack.Count > 0)
            {
                while (current != null)
                {
                    stack.Push(current);
                    current = current.Left;
                }

                current = stack.Pop();
                result.Add(current.Value);
                current = current.Right;
            }

            return result;
        }
    }
}