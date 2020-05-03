using System;

namespace LeetCode_50
{
    /// <summary>
    /// 50. Pow(x,n)
    /// https://leetcode-cn.com/problems/powx-n/
    /// </summary>
    public class Solution
    {
        static void Main(string[] args)
        {
            var sol = new Solution();

            var result = sol.MyPow(2, -2);

            Console.WriteLine(result);

            Console.ReadLine();
        }

        ///// <summary>
        ///// 方法1：暴力法，直接for循环
        ///// </summary>
        ///// <param name="x"></param>
        ///// <param name="n"></param>
        ///// <returns></returns>
        //public double MyPow(double x, int n)
        //{
        //    // 如果 n<0 ,用 1/x 和 -n 代替x,和n
        //    if (n < 0)
        //    {
        //        x = 1 / x;
        //        n = -n;
        //    }

        //    double result = 1;

        //    for(int i = 0; i < n; i++)
        //    {
        //        result *= x;
        //    }

        //    return result;
        //}

        /// <summary>
        /// 分治
        /// </summary>
        /// <param name="x"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public double MyPow(double x, int n)
        {
            if (n < 0)
            {
                x = 1 / x;
                n = -n;
            }

            return fastPow(x, n);
        }

        public double fastPow(double x,int n)
        {
            if (n == 0) return 1;

            double half = fastPow(x, n / 2);
            if (n % 2 == 0)            
                return half * half;            
            else
                return half * half * x;
        }
    }
}
