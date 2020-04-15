using System;
using System.Text;

namespace LeetCode_21
{
    // 21. 合并两个有序链表
    // https://leetcode-cn.com/problems/merge-two-sorted-lists/
    public class Solution
    {
        public static void Main(string[] args)
        {
            var sol = new Solution();
            ListNode l1 = sol.CreateListedLink(new int[] { 1, 4, 8 });
            ListNode l2 = sol.CreateListedLink(new int[] { 1, 2, 9 });
            ListNode newNode = sol.MergeTwoLists(l1, l2);
            sol.Print(newNode);

            Console.ReadLine();
        }

        // 创建一个哨兵 dummy ，方便返回结果
        // 用prev节点进行遍历
        //       如果l1的值小于l2,那么prev的next指向l1,l1向后移1步
        //       反之亦然
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            ListNode dummy = new ListNode(0);
            ListNode prev = dummy;

            while(l1!=null && l2 != null)
            {
                if(l1.val < l2.val)
                {
                    prev.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    prev.next = l2;
                    l2 = l2.next;
                }
                prev = prev.next;
            }

            prev.next = l1 == null ? l2 : l1;

            return dummy.next;
        }

        private ListNode CreateListedLink(int[] nums)
        {
            ListNode dummy = new ListNode(0);

            for(int i = nums.Length - 1; i >= 0; i--)
            {
                ListNode node = new ListNode(nums[i]);
                node.next = dummy.next;
                dummy.next = node;
            }

            return dummy.next;
        }

        private void Print(ListNode head)
        {
            ListNode p = head;

            StringBuilder sb = new StringBuilder();            

            while (p != null)
            {
                sb.Append(p.val);
                sb.Append(" ");
                p = p.next;
            }

            Console.WriteLine(sb.ToString());
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

}
