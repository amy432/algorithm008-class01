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
        ///// 方法1：递归
        ///// </summary>
        ///// <param name="n"></param>
        ///// <returns></returns>
        //public int ClimbStairs(int n)
        //{
        //    if (n == 1) return 1;
        //    if (n == 2) return 2;

        //    return ClimbStairs(n - 1) + ClimbStairs(n - 2);
        //}

        /// <summary>
        /// 方法 2：对方法1 的优化
        ///     只需保存最后3个值，不断往前累加即可
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int ClimbStairs(int n)
        {
            if (n == 1) return 1;
            if (n == 2) return 2;

            int result = 0;
            int a = 1;
            int b = 2;

            for(int i = 3; i <= n; i++)
            {
                result = a + b;
                a = b;
                b = result;
            }


            return result;
        }
    }
}
