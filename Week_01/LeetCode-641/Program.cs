using System;

namespace LeetCode_641
{
    /// <summary>
    /// 641. 设计循环双端队列
    /// https://leetcode-cn.com/problems/design-circular-deque/
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            MyCircularDeque circularDeque = new MyCircularDeque(3); // 设置容量大小为3

            Console.WriteLine($"insertLast(1):{circularDeque.InsertLast(1)}"); // 返回 true
            Console.WriteLine($"insertLast(2):{circularDeque.InsertLast(2)}"); // 返回 true
            Console.WriteLine($"InsertFront(3):{circularDeque.InsertFront(3)}"); // 返回 true
            Console.WriteLine($"InsertFront(4):{circularDeque.InsertFront(4)}"); //  已经满了，返回 false

            Console.WriteLine($"GetRear():{circularDeque.GetRear()}"); // 返回 2
            Console.WriteLine($"IsFull():{circularDeque.IsFull()}"); // 返回 true
            Console.WriteLine($"DeleteLast():{circularDeque.DeleteLast()}"); // 返回 true
            Console.WriteLine($"InsertFront(4):{circularDeque.InsertFront(4)}"); // 返回 true
            Console.WriteLine($"GetFront():{circularDeque.GetFront()}"); // 返回 4
            

            Console.ReadLine();
        }
    }
}
