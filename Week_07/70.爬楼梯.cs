using System;

namespace LeetCode_70
{
    public class Solution
    {
        // 70. 爬楼梯
        // https://leetcode-cn.com/problems/climbing-stairs/
        public static void Main(string[] args)
        {
            var sol = new Solution();
            int n = 30;
            int result = sol.ClimbStairs(n);

            Console.WriteLine(result);
            Console.ReadLine();
        }

        ///// <summary>
        ///// 方法1：动态规划
        ///// </summary>
        ///// <param name="n"></param>
        ///// <returns></returns>
        //public int ClimbStairs(int n)
        //{            
        //    if (n <= 1)
        //        return 1;

        //    var dp = new int[n + 1];

        //    dp[0] = 1;
        //    dp[1] = 1;

        //    int step = 2;
        //    while (step <= n)
        //    {
        //        dp[step] = dp[step - 1] + dp[step - 2];
        //        step++;
        //    }

        //    return dp[n];
        //}

        /// <summary>
        /// 方法2：动态规划。压缩存储空间
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int ClimbStairs(int n)
        {
            if (n <= 1)
                return 1;

            int a = 1, b = 1,result = 0;
            
            int step = 2;
            while (step <= n)
            {
                result = a + b;
                a = b;
                b = result;

                step++;
            }

            return result;
        }


    }
}
