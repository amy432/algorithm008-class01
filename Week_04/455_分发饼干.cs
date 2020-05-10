using System;

namespace LeetCode_455
{
    /// <summary>
    /// 455. 分发饼干
    /// https://leetcode-cn.com/problems/assign-cookies/
    /// </summary>
    public class Solution
    {
        static void Main(string[] args)
        {
            var sol = new Solution();
            int[] g = new int[] { 1, 2, 3 };
            int[] s = new int[] { 1, 1 };            

            int result = sol.FindContentChildren(g, s);
            Console.WriteLine(result);
            Console.ReadLine();
        }

        /// <summary>
        /// 贪心算法
        /// </summary>
        /// <param name="g">孩子</param>
        /// <param name="s">饼干</param>
        /// <returns></returns>
        public int FindContentChildren(int[] g, int[] s)
        {
            if (g == null || g.Length==0 || s == null || s.Length == 0) return 0;

            Array.Sort(g);
            Array.Sort(s);

            int children = 0;
            for(int j=0; children < g.Length && j < s.Length;j++)
            {
                if (g[children] <= s[j]) 
                    children++;                    
            }


            return children;
        }
    }
}
