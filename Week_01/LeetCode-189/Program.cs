using System;

namespace LeetCode_189
{
    // 189. 旋转数组
    // https://leetcode-cn.com/problems/rotate-array/
    public class Solution
    {
        public static void Main(string[] args)
        {
            int[] nums = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            int k = 3;

            var sol = new Solution();
            sol.Rotate(nums, k);

            foreach (var num in nums)
                Console.WriteLine(num);

            Console.WriteLine("Hello World!");
        }

        // 数组中的每个元素都会向后移动k个位置
        // 元素的新位置就是 (currentIndex + k) % nums.Length
        public void Rotate(int[] nums, int k)
        {
            if (k == 0 || nums == null || nums.Length==0) return;

            k = k % nums.Length;

            int count = 0;

            for(int start = 0; count < nums.Length; start++)
            {
                int current = start;
                int pre = nums[current];
                do
                {
                    int next = (current + k) % nums.Length;
                    int temp = nums[next];
                    nums[next] = pre;
                    pre = temp;
                    current = next;
                    count++;
                } while (current != start);
            }

           
        }       
    }
}
