using System;
using System.Collections.Generic;

namespace LeetCode_1
{
    public class Solution
    {
        // 1. 两数之和
        // https://leetcode-cn.com/problems/two-sum/ 
        public static void Main(string[] args)
        {
            var sol = new Solution();

            int[] nums = { 3, 2, 1, 4 };
            int target = 6;

            var result = sol.TwoSum(nums, target);

            Console.WriteLine($"[{result[0]},{result[1]}]");

            Console.ReadLine();
        }

        /// <summary>
        /// 用哈希求解
        ///    把已校验的num存在字典里面，
        ///    然后检查是否存在 target - num        
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>

        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for(int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                if (dict.ContainsKey(complement))
                    return new int[] { i, dict[complement] };

                dict[nums[i]] = i;
            }
           
            throw new Exception("no such numbers");
        }
    }
}
