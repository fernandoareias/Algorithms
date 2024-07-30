namespace Algorithm;

/// <summary>
/// FIFO Queue
/// </summary>
/// <typeparam name="T"></typeparam>
public class Queue<T> where T : notnull
{
    private T[] _array;
    private int _head;
    private int _tail;
    private int _size;
    private readonly int _growFactor;
    
    private const int MinimumGrow = 4;
    
    
    public virtual int Count
    {
        get { return _size; }
    }

   
    public Queue()
        : this(32, 2.0f)
    {
    }
    
    
    public Queue(int capacity)
        : this(capacity, 2.0f)
    {
    }
    
    public Queue(int capacity, float growFactor)
    {
        if (capacity < 0)
            throw new ArgumentOutOfRangeException(nameof(capacity), "Capacity must be non-negative.");
        if (growFactor < 1.0f || growFactor > 10.0f)
            throw new ArgumentOutOfRangeException(nameof(growFactor), "Grow factor must be between 1.0 and 10.0.");

        _array = new T[capacity];
        _head = 0;
        _tail = 0;
        _size = 0;
        _growFactor = (int)(growFactor * 100);
    }

    
    public void Enqueue(T obj)
    {
        if (_size == _array.Length)
        {
            int newCapacity = (int)((long)_array.Length * (long)_growFactor / 100);
            if (newCapacity < _array.Length + MinimumGrow)
            {
                newCapacity = _array.Length + MinimumGrow;
            }
            SetCapacity(newCapacity);
        }
        
        _array[_tail] = obj;
        _tail = (_tail + 1) % _array.Length; // Circular
        _size++;
    }
    
   
    public T Dequeue()
    {
        if (_size == 0)
        {
            throw new InvalidOperationException("Queue is empty.");
        }

        T value = _array[_head];
        _array[_head] = default;
        _head = (_head + 1) % _array.Length; 
        _size--;
        return value;
    }
    
   
    public T Peek()
    {
        if (_size == 0)
        {
            throw new InvalidOperationException("Queue is empty.");
        }

        return _array[_head];
    }

    
    public void Clear()
    {
        Array.Clear(_array, 0, _array.Length);
        _head = 0;
        _tail = 0;
        _size = 0;
    }

  
    public T[] ToArray()
    {
        T[] result = new T[_size];
        if (_size > 0)
        {
            if (_head < _tail)
            {
                Array.Copy(_array, _head, result, 0, _size);
            }
            else
            {
                Array.Copy(_array, _head, result, 0, _array.Length - _head);
                Array.Copy(_array, 0, result, _array.Length - _head, _tail);
            }
        }
        return result;
    }

    private void SetCapacity(int capacity)
    {
        T[] newarray = new T[capacity];
        if (_size > 0)
        {
            if (_head < _tail)
            {
                Array.Copy(_array, _head, newarray, 0, _size);
            }
            else
            {
                Array.Copy(_array, _head, newarray, 0, _array.Length - _head);
                Array.Copy(_array, 0, newarray, _array.Length - _head, _tail);
            }
        }

        _array = newarray;
        _head = 0;
        _tail = (_size == capacity) ? 0 : _size;
    }
}
