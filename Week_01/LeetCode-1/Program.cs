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

            int[] nums = { 3, 2, 4 };
            int target = 6;

            var result = sol.TwoSum(nums, target);

            Console.WriteLine($"[{result[0]},{result[1]}]");

            Console.ReadLine();
        }

        // 把原数组存放在一个Dictionary中，
        // 查找 target - nums[i] 的值是否存在于这个Dictionary里面
        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> dist = new Dictionary<int, int>();
            for(int i = 0; i < nums.Length; i++)
            {
                if (!dist.ContainsKey(nums[i]))
                    dist.Add(nums[i], i);
            }

            for(int i = 0; i < nums.Length; i++)
            {
                if(dist.ContainsKey(target - nums[i]))
                {
                    int val = dist[target - nums[i]];
                    if (val != i)
                    {
                        return new int[] { i, val };
                    }
                }
            }

            throw new Exception("no such numbers");
        }
    }
}
