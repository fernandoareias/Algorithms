namespace Algorithm
{
    // Desempenho no pior caso:  O(n)
    // Desempenho no melhor caso:  O(1)
    // Desempenho médio:  O(log n)
    // Complexidade de espaço no pior caso:  O(1)

    /// <summary>
    /// Classe que representa um nó da árvore binária de busca.
    /// </summary>
    /// <typeparam name="T">Tipo de dado armazenado no nó.</typeparam>
    public class BinarySearchTreeNode<T> where T : notnull
    {
        public T Value { get; set; }
        public BinarySearchTreeNode<T>? Left { get; set; }
        public BinarySearchTreeNode<T>? Right { get; set; }
    }

    /// <summary>
    /// Classe que representa uma árvore binária de busca.
    /// </summary>
    /// <typeparam name="T">Tipo de dado armazenado nos nós da árvore.</typeparam>
    public class BinarySearchTree<T> where T : IComparable<T>
    {
        public BinarySearchTreeNode<T>? Root { get; private set; } = null;

        public BinarySearchTreeNode<T>? Search(T value)
        {
            var current = Root;

            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    return current;
                }
                if (current.Value.CompareTo(value) > 0)
                {
                    current = current.Left;
                }
                else
                {
                    current = current.Right;
                }
            }
            return null;
        }

        public void Add(T value)
        {
            var newNode = new BinarySearchTreeNode<T> { Value = value };

            if (Root == null)
            {
                Root = newNode;
                return;
            }

            var current = Root;
            BinarySearchTreeNode<T>? parent = null;

            while (true)
            {
                parent = current;

                if (value.CompareTo(parent.Value) < 0)
                {
                    current = parent.Left;
                    if (current == null)
                    {
                        parent.Left = newNode;
                        return;
                    }
                }
                else
                {
                    current = parent.Right;
                    if (current == null)
                    {
                        parent.Right = newNode;
                        return;
                    }
                }
            }
        }

        public void Delete(T value)
        {
            if (Root == null) return;

            BinarySearchTreeNode<T>? parent = null;
            var current = Root;

            while (current != null && !current.Value.Equals(value))
            {
                parent = current;
                if (value.CompareTo(current.Value) < 0)
                {
                    current = current.Left;
                }
                else
                {
                    current = current.Right;
                }
            }

            if (current == null) return; 

            if (current.Left == null && current.Right == null)
            {
                if (current == Root)
                {
                    Root = null;
                }
                else if (parent.Left == current)
                {
                    parent.Left = null;
                }
                else
                {
                    parent.Right = null;
                }
            }
            else if (current.Left == null)
            {
                if (current == Root)
                {
                    Root = current.Right;
                }
                else if (parent.Left == current)
                {
                    parent.Left = current.Right;
                }
                else
                {
                    parent.Right = current.Right;
                }
            }
            else if (current.Right == null)
            {
                if (current == Root)
                {
                    Root = current.Left;
                }
                else if (parent.Left == current)
                {
                    parent.Left = current.Left;
                }
                else
                {
                    parent.Right = current.Left;
                }
            }
            else
            {
                var successorParent = current;
                var successor = current.Right;

                while (successor.Left != null)
                {
                    successorParent = successor;
                    successor = successor.Left;
                }

                if (successorParent != current)
                {
                    successorParent.Left = successor.Right;
                    successor.Right = current.Right;
                }

                successor.Left = current.Left;

                if (current == Root)
                {
                    Root = successor;
                }
                else if (parent.Left == current)
                {
                    parent.Left = successor;
                }
                else
                {
                    parent.Right = successor;
                }
            }
        }

        public int GetHeight()
        {
            return GetHeight(Root);
        }

        private int GetHeight(BinarySearchTreeNode<T>? node)
        {
            if (node == null)
            {
                return -1;
            }

            int leftHeight = GetHeight(node.Left);
            int rightHeight = GetHeight(node.Right);

            return Math.Max(leftHeight, rightHeight) + 1;
        }
    }
}
