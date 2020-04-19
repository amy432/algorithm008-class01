using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_641
{
    public class MyCircularDeque
    {
        
        private int capacity;
        private int[] arr;
        private int front; // 指向队列头部第1个有效数据的位置
        private int rear; // 指向队列尾部的下一个位置。

        // front == rear 时，队列为空
        // (rear + 1) % capacity == front，队列为满

        /** Initialize your data structure here. Set the size of the deque to be k. */
        public MyCircularDeque(int k)
        {
            capacity = k + 1;
            arr = new int[capacity];
        }

        /** Adds an item at the front of Deque. Return true if the operation is successful. */
        public bool InsertFront(int value)
        {
            if (IsFull()) return false;

            // 从头部入队时，front向后移动一位，当front为0时，需要防止数组越界            
            front = (front - 1 + capacity) % capacity;
            arr[front] = value;
            return true;
        }

        /** Adds an item at the rear of Deque. Return true if the operation is successful. */
        public bool InsertLast(int value)
        {
            if (IsFull()) return false;

            arr[rear] = value;
            rear = (rear + 1) % capacity;           
            return true;
        }

        /** Deletes an item from the front of Deque. Return true if the operation is successful. */
        public bool DeleteFront()
        {
            if (IsEmpty()) return false;

            // 从头部出队时，front指针向前移动一格
            front = (front + 1) % capacity;
            return true;
        }

        /** Deletes an item from the rear of Deque. Return true if the operation is successful. */
        public bool DeleteLast()
        {
            if (IsEmpty()) return false;

            // 从尾部出队时，rear指针向后移动一格
            rear = (rear - 1 + capacity) % capacity;
            return true;
        }

        /** Get the front item from the deque. */
        public int GetFront()
        {
            if (IsEmpty()) return -1;

            return arr[front];
        }

        /** Get the last item from the deque. */
        public int GetRear()
        {

            if (IsEmpty()) return -1;
           
            return arr[(rear -1 +capacity)%capacity];
        }

        /** Checks whether the circular deque is empty or not. */
        public bool IsEmpty()
        {
            return front == rear;
        }

        /** Checks whether the circular deque is full or not. */
        public bool IsFull()
        {
            return (rear + 1) % capacity == front;
        }
    }

}
