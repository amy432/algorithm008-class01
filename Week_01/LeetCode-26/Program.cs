using System;

namespace LeetCode_26
{
    // 26. 删除排序数组中的重复项
    // https://leetcode-cn.com/problems/remove-duplicates-from-sorted-array/
    public class Solution
    {
        public static void Main(string[] args)
        {
            int[] nums = new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };

            var sol = new Solution();
            int result = sol.RemoveDuplicates(nums);

            Console.WriteLine($"长度：{result}");

            for(int i=0;i<result;i++)
                Console.WriteLine(nums[i]);

            Console.ReadLine();
        }
         
        // 由于数组是已经有序的，那么重复项是一定相邻的。
        public int RemoveDuplicates(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;

            int len = 0;
            for(int i = 1; i < nums.Length; i++)
            {
                if(nums[i]!=nums[len])
                {
                    nums[++len] = nums[i];                    
                }
            }

            return len + 1;
        }
    }
}
