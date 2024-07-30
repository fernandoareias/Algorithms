namespace Algorithm;

public class DoubleLinkedListNode<T> where T : notnull
{
    public DoubleLinkedListNode(T value)
    {
        Value = value;
    }
    
    public T Value { get; set; }
    public DoubleLinkedListNode<T>? Prev { get; set; }
    public DoubleLinkedListNode<T>? Next { get; set; }
}

public class DoubleLinkedList<T> where T : notnull
{

    public uint Count = 0;
    public DoubleLinkedListNode<T>? Root { get; set; }

    
    /// <summary>
    /// O(N)
    /// </summary>
    /// <param name="value"></param>
    public void AddTail(T value)
    {
        var newNode = new DoubleLinkedListNode<T>(value);
        if (Root is null)
        {
            Root = newNode;
            Count++;
            return;
        }

        var lastNode = Root;
        while (lastNode.Next != null)
        {
            lastNode = lastNode.Next;
        }

        lastNode.Next = newNode;
        newNode.Prev = lastNode;
        Count++;
    }

    /// <summary>
    /// O(1)
    /// </summary>
    /// <param name="value"></param>
    public void AddHead(T value)
    {
        var newNode = new DoubleLinkedListNode<T>(value);

        if (Root is null)
        {
            Root = newNode;
            Count++;
            return;
        }

        newNode.Next = Root;
        Root.Prev = newNode;

        Root = newNode;
        Count++;
    }

    /// <summary>
    /// O(1)
    /// </summary>
    public void RemoveHead()
    {
        if (Root?.Next == null)
        {
            Root = null;
            Count--;
            return;
        }

        Root = Root.Next;
        Root.Prev = null;
        Count--;
    }

    /// <summary>
    /// O(N)
    /// </summary>
    public void RemoveTail()
    {
        if (Root is null)
        {
            // A lista está vazia, nada para remover
            return;
        }

        if (Root.Next is null)
        {
            // A lista tem apenas um nó
            Root = null;
            Count--;
            return;
        }

        var lastNode = Root;
        while (lastNode.Next != null)
        {
            lastNode = lastNode.Next;
        }

        var prevNode = lastNode.Prev;
        prevNode.Next = null; 
        lastNode.Prev = null; 

        Count--;
    }


    public bool Contains(T value)
    {

        if (Root == null) return false;

        var current = Root;
        while (current != null)
        {
            if (current.Value.Equals(value))
                return true;

            current = current.Next;
        }

        return false;
    }
    
    /// <summary>
    /// O(N)
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public DoubleLinkedListNode<T>? Find(T value)
    {
        var current = Root;
        while (current != null)
        {
            if (current.Value.Equals(value))
                return current;

            current = current.Next;
        }

        return null;
    }

    /// <summary>
    /// O(N)
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public bool Remove(T value)
    {
        var nodeToRemove = Find(value);
        if (nodeToRemove == null)
            return false;

        if (nodeToRemove.Prev != null)
            nodeToRemove.Prev.Next = nodeToRemove.Next;
        else
            Root = nodeToRemove.Next; 

        if (nodeToRemove.Next != null)
            nodeToRemove.Next.Prev = nodeToRemove.Prev;

        nodeToRemove.Next = null; 
        nodeToRemove.Prev = null; 

        Count--;
        return true;
    }
    
    public void Clear()
    {
        Root = null;
        Count = 0;
    }

    
    public List<T> ToList()
    {
        var list = new List<T>();
        var current = Root;
        while (current != null)
        {
            list.Add(current.Value);
            current = current.Next;
        }
        return list;
    }

    
    public void Print()
    {
        var current = Root;
        while (current != null)
        {
            Console.WriteLine(current.Value);
            current = current.Next;
        }
    }


}