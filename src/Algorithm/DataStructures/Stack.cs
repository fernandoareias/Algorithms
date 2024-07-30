namespace Algorithm;

public class Stack<T> where T : notnull
{
    private const int _defaultCapacity = 10;
    private int _size = 0;
    
    public virtual int Count
    {
        get
        {
            return _size;
        }
    }
    private T[] _array { get; set; }

    public Stack()
    {
        _array = new T[_defaultCapacity];
        _size = 0; 
    }
    
    public Stack(int capacity)
    {
        if (capacity < _defaultCapacity)
            capacity = _defaultCapacity;  
        _array = new T[capacity];
        _size = 0;
    }
    
    
    public void Push(T value)
    {
        if (_size == _array.Length)
        {
            var newArray = new T[2 * _array.Length];
            Array.Copy(_array, newArray, _size);
            _array = newArray;
        }
        
        _array[_size++] = value;
    }

    public T Pop()
    {
        if (_size == 0)
            throw new InvalidOperationException("Stack is empty.");
        
        var value = _array[--_size];
        _array[_size] = default; 
        return value;
        
    }
    
    public T Peek()
    {
        if (_size == 0)
            throw new InvalidOperationException("Stack is empty.");

        return _array[_size - 1];
    }

    public void Clear()
    {
        Array.Clear(_array, 0, _size);
        _size = 0;
    }

    public virtual T?[] ToArray()
    {
        if (_size == 0)
            return Array.Empty<T>();
 
        var objArray = new T[_size];
        int i = 0;
        while (i < _size)
        {
            objArray[i] = _array[_size - i - 1];
            i++;
        }
        return objArray;
    }
}