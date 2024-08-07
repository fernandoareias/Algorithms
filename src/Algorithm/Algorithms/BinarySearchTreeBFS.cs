using System;
using System.Collections.Generic;

namespace Algorithm
{
    public static class BinarySearchTreeBFS
    {
        public static List<T> BreadthFirstSearch<T>(BinarySearchTree<T> tree) where T : IComparable<T>
        {
            var result = new List<T>();
            if (tree.Root == null)
            {
                return result;
            }

            var queue = new Queue<BinarySearchTreeNode<T>>();
            queue.Enqueue(tree.Root);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                result.Add(current.Value);

                if (current.Left != null)
                {
                    queue.Enqueue(current.Left);
                }

                if (current.Right != null)
                {
                    queue.Enqueue(current.Right);
                }
            }

            return result;
        }
    }
}