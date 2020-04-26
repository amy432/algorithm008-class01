using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode_347
{
    /// <summary>
    /// 347. 前k个高频元素
    /// https://leetcode-cn.com/problems/top-k-frequent-elements/
    /// </summary>
    public class Solution
    {
        public static void Main(string[] args)
        {
            var sol = new Solution();
            int[] nums = new int[] { 1, 1, 1, 2, 2, 3 };
            int k = 2;

            var result = sol.TopKFrequent(nums,k);

            Console.WriteLine(string.Join(',',result));

            Console.ReadLine();
        }

        /// <summary>
        /// 暴力解法
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] TopKFrequent(int[] nums, int k)
        {
            var dict = new Dictionary<int, int>();

            foreach (var num in nums)
            {
                if (dict.ContainsKey(num))
                    dict[num]++;
                else
                    dict[num] = 1;
            }

            return dict.OrderByDescending(t => t.Value).Take(k).Select(k => k.Key).ToArray();
        }

    }
}
