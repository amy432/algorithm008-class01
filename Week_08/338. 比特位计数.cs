using System;

namespace LeetCode_338
{
    /// <summary>
    /// 338.  比特位计数
    /// https://leetcode-cn.com/problems/counting-bits/
    /// </summary>
    public class Solution
    {
        static void Main(string[] args)
        {
            var sol = new Solution();

            var result = sol.CountBits(10);

            foreach(var i in result)
                Console.WriteLine(i);

            Console.ReadLine();
        }

        public int[] CountBits(int num)
        {
            int[] dp = new int[num + 1];

            for(int i = 1; i <= num; i++)
            {
                dp[i] = dp[i & (i - 1)] + 1;
            }

            return dp;
        }
    }
}
