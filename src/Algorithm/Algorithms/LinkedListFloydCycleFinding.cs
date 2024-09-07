namespace Algorithm;

public static class LinkedListFloydCycleFinding
{
    public static bool HasCycle<T>(LinkedListNode<T> root)
    {
        if (root == null)
            return false; 

        LinkedListNode<T> slow = root;
        LinkedListNode<T> fast = root.Next;

        while (fast != null && fast?.Next != null)
        {
            if (slow == fast)
                return true;

            slow = slow.Next;
            fast = fast.Next.Next; 
        }

        return false; 
    }
}
