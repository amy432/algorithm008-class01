using System;
using System.Linq;

namespace LeetCode_91
{
    /// <summary>
    /// 91.解码方法
    /// https://leetcode-cn.com/problems/decode-ways
    /// </summary>
    public class Solution
    {
        static void Main(string[] args)
        {
            var sol = new Solution();

            string s = "271";
            var result = sol.NumDecodings(s);
            Console.WriteLine(result);

            Console.ReadLine();
        }

        ///// <summary>
        ///// 方法1 ：暴力解法（递归）
        ///// </summary>
        ///// <param name="s"></param>
        ///// <returns></returns>
        //public int NumDecodings(string s)
        //{
        //    if (string.IsNullOrWhiteSpace(s) || s.StartsWith("0")) return 0;

        //    int[] nums = s.ToCharArray().Select(c => c - '0').ToArray();

        //    return Recursion(nums, 0);            
        //}

        //private int Recursion(int[] nums,int currentIndex)
        //{
        //    if (nums[currentIndex] == 0)
        //        return 0;

        //    if (currentIndex == nums.Length - 1)
        //    {
        //        // 最后一个字母
        //        return 1;
        //    }            

        //    int nextSum = Recursion(nums, currentIndex + 1);
        //    int current = 0;

        //    if (currentIndex < nums.Length - 1)
        //    {
        //        if (nums[currentIndex] * 10 + nums[currentIndex + 1] <= 26)
        //        {
        //            if (currentIndex < nums.Length - 2)
        //                current = Recursion(nums, currentIndex + 2);
        //            else
        //                current = 1;
        //        }
        //    }
        //    return current + nextSum;
        //}

        ///// <summary>
        ///// 方法2：动态规划
        ///// 时间复杂度：O(n)
        ///// 空间复杂度：O(n)
        ///// </summary>
        ///// <param name="s"></param>
        ///// <returns></returns>
        //public int NumDecodings(string s)
        //{
        //    if (string.IsNullOrWhiteSpace(s) || s.StartsWith("0")) return 0;

        //    int[] nums = s.ToCharArray().Select(c => c - '0').ToArray();

        //    int lastIndex = nums.Length - 1;
        //    int[] dp = new int[nums.Length];

        //    if (nums[lastIndex] == 0)
        //        dp[lastIndex] = 0;
        //    else
        //        dp[lastIndex] = 1;

        //    for (int i = lastIndex - 1; i >= 0; i--)
        //    {
        //        if (nums[i] == 0)
        //        {
        //            dp[i] = 0;
        //            continue;
        //        }

        //        if (nums[i] * 10 + nums[i + 1] <= 26)
        //        {
        //            if (i < lastIndex - 1)
        //                dp[i] = dp[i + 1] + dp[i + 2];
        //            else
        //                dp[i] = 1 + dp[i + 1];
        //        }
        //        else
        //            dp[i] = dp[i + 1];
        //    }
        //    return dp[0];
        //}

        /// <summary>
        /// 方法 3：动态规划优化        
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int NumDecodings(string s)
        {
            if (string.IsNullOrWhiteSpace(s) || s.StartsWith("0")) return 0;
            int[] nums = s.ToCharArray().Select(c => c - '0').ToArray();

            int lastIndex = nums.Length - 1;
            int temp = 1;
            int result = 0;


            if (nums[lastIndex] > 0)
                result = 1;

            for (int i = lastIndex - 1; i >= 0; i--)
            {
                if (nums[i] == 0)
                {
                    temp = result;
                    result = 0;
                    continue;
                }

                if (nums[i] * 10 + nums[i + 1] <= 26)
                {
                    result += temp;
                    temp = result - temp;
                }
                else
                    temp = result;
            }

            return result;
        }
    }
}
