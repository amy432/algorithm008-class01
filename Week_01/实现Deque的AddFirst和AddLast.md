在C#的语法中，是没有Deque这种数据结构的。

参考了C#中ArrayList的思想，尝试了实现Deque中AddFirst和AddList的功能

```c#
public class MyDeque
{
    private int[] _items;

    public int Size { get; private set; } // 用于判断队列是否为空
        
    private const int _defaultCapacity = 4; // 默认初始队列长度为4

    private int head;
    private int tail;
       
    public MyDeque()
    {          
        head = tail = Size = 0;
        _items = new int[_defaultCapacity];
    }

    public bool AddFirst(int e)
    {
        if (this.Size == 0)
            _items[head] = e;
        else
        {
            if(head>0)
            {
                _items[head--] = e;
            }
            else
            {
                if (this.Size < _items.Length)
                {
                    Array.Copy(_items, head, _items, 1, this.Size);
                    _items[0] = e;                    
                }
                else
                {
                    int[] newArray = new int[_items.Length * 2];
                    newArray[0] = e;
                    Array.Copy(_items,head, newArray, 1, this.Size);
                    _items = newArray;
                }
                tail++;
            }
        }         
        this.Size++;
        return true;
    }

    public bool AddLast(int e)
    {
        if(tail == _items.Length - 1)
        {
            int[] newArray = new int[_items.Length * 2];
            Array.Copy(_items, head, newArray, 0, this.Size);
            _items = newArray;
        }

        if (this.Size > 0)            
           tail = tail + 1;            

        _items[tail] = e;
        this.Size++;
            
        return true;
    }

    public int GetFirst()
    {
        if (this.Size == 0)
            throw new Exception("队列为空");

        return _items[head];
    }

    public int GetLast()
    {
        if (this.Size == 0)
            throw new Exception("队列为空");

        return _items[tail];
    }

    public void Print()
    {
        Console.WriteLine($"队列长度：{this.Size}");
        var printArry = new int[this.Size];
        Array.Copy(_items, head, printArry, 0, this.Size);

        Console.WriteLine($"[{string.Join(',',printArry)}]");
    }       
}
```

测试：

```C#
MyDeque deq = new MyDeque();

Console.WriteLine($"AddLast(1):{deq.AddLast(1)}"); // true
Console.WriteLine($"AddLast(2):{deq.AddLast(2)}"); // true
Console.WriteLine($"AddFirst(2):{deq.AddFirst(3)}"); // true
deq.Print();  // 队列长度：3    [3,1,2]
Console.WriteLine($"AddLast(4):{deq.AddLast(4)}"); // true
Console.WriteLine($"AddFirst(5):{deq.AddFirst(5)}"); // true
deq.Print();   // 队列长度：5    [5,3,1,2,4]

Console.ReadLine();
```

