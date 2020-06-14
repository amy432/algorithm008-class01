using System;
using System.Security.Cryptography.X509Certificates;

namespace LeetCode_231
{
    /// <summary>
    /// 231. 2的幂
    /// https://leetcode-cn.com/problems/power-of-two/
    /// </summary>
    public class Solution
    {
        static void Main(string[] args)
        {
            var sol = new Solution();

           
            Console.WriteLine(sol.IsPowerOfTwo(1));
            Console.WriteLine(sol.IsPowerOfTwo(16));
            Console.WriteLine(sol.IsPowerOfTwo(218));
            Console.WriteLine(sol.IsPowerOfTwo(-2147483648));
            Console.WriteLine(sol.IsPowerOfTwo(-9));


            Console.ReadLine();
        }

        ///// <summary>
        ///// 方法1：log n
        ///// </summary>
        ///// <param name="n"></param>
        ///// <returns></returns>
        //public bool IsPowerOfTwo(int n)
        //{
        //    if (n <= 0) return false;

        //    double l = Math.Log(n,2);


        //    return int.TryParse(l.ToString(), out int a);
        //}

        ///// <summary>
        ///// 方法2：mod 2
        ///// </summary>
        ///// <param name="n"></param>
        ///// <returns></returns>
        //public bool IsPowerOfTwo(int n)
        //{
        //    if (n <= 0) return false;

        //    while (n % 2 == 0)
        //        n /= 2;

        //    return n == 1;
        //}

        /// <summary>
        /// 方法3：位运算
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool IsPowerOfTwo(int n)
        {
            // 二进制位有且只有1个1

            if (n <= 0) return false;

            return (n & (n - 1)) == 0;
        }
    }
}
