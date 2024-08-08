public class Node<T>
{
    public T Value;
    public Node<T>? Left;
    public Node<T>? Right;
    public int Height;

    public Node(T value)
    {
        Value = value;
        Height = 1;
    }
}

public class AVLTree<T> where T : IComparable<T>
{
    private Node<T>? root;

    public Node<T>? Root => root;

    public void Insert(T value)
    {
        if (root == null)
        {
            root = new Node<T>(value);
            return;
        }

        Stack<Node<T>> path = new Stack<Node<T>>();
        Node<T>? current = root;

        while (current != null)
        {
            path.Push(current);
            if (value.CompareTo(current.Value) < 0)
                current = current.Left;
            else if (value.CompareTo(current.Value) > 0)
                current = current.Right;
            else
                return; // Valor já existe na árvore
        }

        Node<T> newNode = new Node<T>(value);
        Node<T> parent = path.Peek();
        if (value.CompareTo(parent.Value) < 0)
            parent.Left = newNode;
        else
            parent.Right = newNode;

        // Balanceia a árvore começando a partir do nó inserido
        Balance(path);
    }

    public void Delete(T value)
    {
        root = Delete(root, value);
    }

    private Node<T>? Delete(Node<T>? node, T value)
    {
        if (node == null)
            return null;

        int comparison = value.CompareTo(node.Value);

        if (comparison < 0)
            node.Left = Delete(node.Left, value);
        else if (comparison > 0)
            node.Right = Delete(node.Right, value);
        else
        {
            // Nó a ser removido tem 0 ou 1 filho
            if (node.Left == null)
                return node.Right;
            if (node.Right == null)
                return node.Left;

            // Nó com dois filhos: obtenha o sucessor em ordem
            Node<T> temp = MinValueNode(node.Right);
            node.Value = temp.Value;
            node.Right = Delete(node.Right, temp.Value);
        }

        // Atualiza a altura do nó atual
        node.Height = 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));

        return BalanceNode(node);
    }

    private Node<T> MinValueNode(Node<T>? node)
    {
        Node<T> current = node!;
        while (current.Left != null)
            current = current.Left;
        return current;
    }

    private void Balance(Stack<Node<T>> path)
    {
        while (path.Count > 0)
        {
            Node<T> node = path.Pop();
            node.Height = 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));
            node = BalanceNode(node);

            if (path.Count > 0)
            {
                Node<T> parent = path.Peek();
                if (node.Value.CompareTo(parent.Value) < 0)
                    parent.Left = node;
                else
                    parent.Right = node;
            }
            else
            {
                root = node;
            }
        }
    }

    private Node<T> BalanceNode(Node<T> node)
    {
        int balance = GetHeight(node.Left) - GetHeight(node.Right);

        // Realiza rotações para balancear a árvore
        if (balance > 1)
        {
            if (GetHeight(node.Left?.Right) > GetHeight(node.Left?.Left))
                node.Left = RotateLeft(node.Left!);
            node = RotateRight(node);
        }
        else if (balance < -1)
        {
            if (GetHeight(node.Right?.Left) > GetHeight(node.Right?.Right))
                node.Right = RotateRight(node.Right!);
            node = RotateLeft(node);
        }

        return node;
    }

    private Node<T> RotateLeft(Node<T> x)
    {
        Node<T> y = x.Right!;
        x.Right = y.Left;
        y.Left = x;

        x.Height = Math.Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;
        y.Height = Math.Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;

        return y;
    }

    private Node<T> RotateRight(Node<T> y)
    {
        Node<T> x = y.Left!;
        y.Left = x.Right;
        x.Right = y;

        y.Height = Math.Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;
        x.Height = Math.Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;

        return x;
    }

    private int GetHeight(Node<T>? node)
    {
        return node?.Height ?? 0;
    }

    public List<T> InOrderTraversal()
    {
        List<T> result = new();
        InOrderTraversal(root, result);
        return result;
    }

    private void InOrderTraversal(Node<T>? node, List<T> result)
    {
        if (node == null) return;

        InOrderTraversal(node.Left, result);
        result.Add(node.Value);
        InOrderTraversal(node.Right, result);
    }
}
