using System;
 
public enum Color { Red, Black }
 
public class RedBlackTreeNode<T> where T : IComparable
{ 
    public T Data { get; set; }

    public RedBlackTreeNode<T> Left { get; set; }

    public RedBlackTreeNode<T> Right { get; set; }

    public RedBlackTreeNode<T> Parent { get; set; }

    public Color RedBlackTreeNodeColor { get; set; }

    public RedBlackTreeNode(T data)
    {
        Data = data;
        RedBlackTreeNodeColor = Color.Red; 
    }
}
public class RedBlackTree<T> where T : IComparable
{
    private RedBlackTreeNode<T> root;

    public void Insert(T data)
    {
        RedBlackTreeNode<T> newNode = new RedBlackTreeNode<T>(data);

        if (root == null)
        {
            root = newNode;
            root.RedBlackTreeNodeColor = Color.Black;
        }
        else
        {
            Insert(root, newNode);
            FixTree(newNode);
        }
    }

    private void Insert(RedBlackTreeNode<T> root, RedBlackTreeNode<T> newNode)
    {
        if (newNode.Data.CompareTo(root.Data) < 0)
        {
            if (root.Left == null)
            {
                root.Left = newNode;
                newNode.Parent = root;
            }
            else
            {
                Insert(root.Left, newNode);
            }
        }
        else
        {
            if (root.Right == null)
            {
                root.Right = newNode;
                newNode.Parent = root;
            }
            else
            {
                Insert(root.Right, newNode);
            }
        }
    }

    private void FixTree(RedBlackTreeNode<T> node)
    {
        while (node != root && node.Parent.RedBlackTreeNodeColor == Color.Red)
        {
            if (node.Parent == node.Parent.Parent.Left)
            {
                RedBlackTreeNode<T> uncle = node.Parent.Parent.Right;
                if (uncle != null && uncle.RedBlackTreeNodeColor == Color.Red)
                {
                    node.Parent.RedBlackTreeNodeColor = Color.Black;
                    uncle.RedBlackTreeNodeColor = Color.Black;
                    node.Parent.Parent.RedBlackTreeNodeColor = Color.Red;
                    node = node.Parent.Parent;
                }
                else
                {
                    if (node == node.Parent.Right)
                    {
                        node = node.Parent;
                        LeftRotate(node);
                    }
                    node.Parent.RedBlackTreeNodeColor = Color.Black;
                    node.Parent.Parent.RedBlackTreeNodeColor = Color.Red;
                    RightRotate(node.Parent.Parent);
                }
            }
            else
            {
                RedBlackTreeNode<T> uncle = node.Parent.Parent.Left;
                if (uncle != null && uncle.RedBlackTreeNodeColor == Color.Red)
                {
                    node.Parent.RedBlackTreeNodeColor = Color.Black;
                    uncle.RedBlackTreeNodeColor = Color.Black;
                    node.Parent.Parent.RedBlackTreeNodeColor = Color.Red;
                    node = node.Parent.Parent;
                }
                else
                {
                    if (node == node.Parent.Left)
                    {
                        node = node.Parent;
                        RightRotate(node);
                    }
                    node.Parent.RedBlackTreeNodeColor = Color.Black;
                    node.Parent.Parent.RedBlackTreeNodeColor = Color.Red;
                    LeftRotate(node.Parent.Parent);
                }
            }
        }
        root.RedBlackTreeNodeColor = Color.Black;
    }

    private void LeftRotate(RedBlackTreeNode<T> node)
    {
        RedBlackTreeNode<T> temp = node.Right;
        node.Right = temp.Left;
        if (temp.Left != null)
        {
            temp.Left.Parent = node;
        }
        temp.Parent = node.Parent;
        if (node.Parent == null)
        {
            root = temp;
        }
        else if (node == node.Parent.Left)
        {
            node.Parent.Left = temp;
        }
        else
        {
            node.Parent.Right = temp;
        }
        temp.Left = node;
        node.Parent = temp;
    }

    private void RightRotate(RedBlackTreeNode<T> node)
    {
        RedBlackTreeNode<T> temp = node.Left;
        node.Left = temp.Right;
        if (temp.Right != null)
        {
            temp.Right.Parent = node;
        }
        temp.Parent = node.Parent;
        if (node.Parent == null)
        {
            root = temp;
        }
        else if (node == node.Parent.Right)
        {
            node.Parent.Right = temp;
        }
        else
        {
            node.Parent.Left = temp;
        }
        temp.Right = node;
        node.Parent = temp;
    }

    public void InOrderTraversal(Action<RedBlackTreeNode<T>> action)
    {
        InOrderTraversal(root, action);
    }

    private void InOrderTraversal(RedBlackTreeNode<T> node, Action<RedBlackTreeNode<T>> action)
    {
        if (node != null)
        {
            InOrderTraversal(node.Left, action);
            action(node);
            InOrderTraversal(node.Right, action);
        }
    }

    public RedBlackTreeNode<T> Search(T data)
    {
        return Search(root, data);
    }

    private RedBlackTreeNode<T> Search(RedBlackTreeNode<T> node, T data)
    {
        if (node == null || data.CompareTo(node.Data) == 0)
        {
            return node;
        }

        if (data.CompareTo(node.Data) < 0)
        {
            return Search(node.Left, data);
        }
        else
        {
            return Search(node.Right, data);
        }
    }
}
 