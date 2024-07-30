namespace Algorithm
{
    public class LinkedListNode<T> where T : notnull
    {
        public LinkedListNode(T value)
        {
            Value = value;
        }

        public T Value { get; set; }
        public LinkedListNode<T>? Next { get; set; }
    }

    public class LinkedList<T> where T : notnull
    {
        public uint Count { get; private set; } = 0;
        public LinkedListNode<T>? Root { get; private set; }

        /// <summary>
        /// O(1)
        /// </summary>
        /// <param name="value"></param>
        public void AddHead(T value)
        {
            var newNode = new LinkedListNode<T>(value)
            {
                Next = Root
            };
            Root = newNode;
            Count++;
        }

        /// <summary>
        /// O(N)
        /// </summary>
        /// <param name="value"></param>
        public void AddTail(T value)
        {
            var newNode = new LinkedListNode<T>(value);

            if (Root == null)
            {
                Root = newNode;
                Count++;
                return;
            }

            var current = Root;
            while (current.Next != null)
            {
                current = current.Next;
            }

            current.Next = newNode;
            Count++;
        }

        public bool Contains(T value)
        {
            var current = Root;
            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    return true;
                }
                current = current.Next;
            }

            return false;
        }

        /// <summary>
        /// O(N)
        /// </summary>
        /// <param name="value"></param>
        public void Remove(T value)
        {
            if (Root == null)
                return;

            if (Root.Value.Equals(value))
            {
                Root = Root.Next;
                Count--;
                return;
            }

            var prev = Root;
            var current = Root.Next;

            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    prev.Next = current.Next;
                    Count--;
                    return;
                }

                prev = current;
                current = current.Next;
            }
        }

        /// <summary>
        /// O(1)
        /// </summary>
        public void RemoveHead()
        {
            if (Root == null)
                return;

            Root = Root.Next;
            Count--;
        }

        /// <summary>
        /// O(N)
        /// </summary>
        public void RemoveTail()
        {
            if (Root == null)
                return;

            if (Root.Next == null)
            {
                Root = null;
                Count--;
                return;
            }

            var current = Root;
            LinkedListNode<T>? prev = null;

            while (current.Next != null)
            {
                prev = current;
                current = current.Next;
            }

            if (prev != null)
            {
                prev.Next = null;
            }

            Count--;
        }
    }
}
