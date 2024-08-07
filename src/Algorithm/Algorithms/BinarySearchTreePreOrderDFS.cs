using System;
using System.Collections.Generic;

namespace Algorithm
{
    public static class BinarySearchTreePreOrderDFS
    {
        public static List<T> DepthFirstSearch<T>(BinarySearchTree<T> tree) where T : IComparable<T>
        {
            var result = new List<T>();
            if (tree.Root == null)
            {
                return result;
            }

            var stack = new Stack<BinarySearchTreeNode<T>>();
            stack.Push(tree.Root);

            while (stack.Count > 0)
            {
                var current = stack.Pop();
                result.Add(current.Value);

                if (current.Right != null)
                {
                    stack.Push(current.Right);
                }

                if (current.Left != null)
                {
                    stack.Push(current.Left);
                }
            }

            return result;
        }
    }
}