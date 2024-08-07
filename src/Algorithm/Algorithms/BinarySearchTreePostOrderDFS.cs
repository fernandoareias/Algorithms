using System;
using System.Collections.Generic;

namespace Algorithm
{
    public static class BinarySearchTreePostOrderDFS
    {
        public static List<T> DepthFirstSearch<T>(BinarySearchTree<T> tree) where T : IComparable<T>
        {
            var result = new List<T>();
            if (tree.Root == null)
            {
                return result;
            }

            var stack1 = new Stack<BinarySearchTreeNode<T>>();
            var stack2 = new Stack<BinarySearchTreeNode<T>>();
            stack1.Push(tree.Root);

            while (stack1.Count > 0)
            {
                var current = stack1.Pop();
                stack2.Push(current);

                if (current.Left != null)
                {
                    stack1.Push(current.Left);
                }

                if (current.Right != null)
                {
                    stack1.Push(current.Right);
                }
            }

            while (stack2.Count > 0)
            {
                result.Add(stack2.Pop().Value);
            }

            return result;
        }
    }
}