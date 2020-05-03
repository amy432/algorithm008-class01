using System;
using System.Collections.Generic;

namespace LeetCode_22
{
    /// <summary>
    /// 22. 括号生成
    /// https://leetcode-cn.com/problems/generate-parentheses/
    /// </summary>
    public class Solution
    {
        static void Main(string[] args)
        {
            var sol = new Solution();

            var result = sol.GenerateParenthesis(3);

            foreach(var s in result)
                Console.WriteLine(s);

            Console.ReadLine();
        }

        private List<string> result;

        /// <summary>
        /// 方法1 ：递归
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public IList<string> GenerateParenthesis(int n)
        {
            result = new List<string>();
            Generate(0,0, n, "");
            return result;
        }

        /// <summary>
        /// 括号的合法性：
        ///      left：随时可以加，只要别超标
        ///       right: 左个数 > 右个数
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="n"></param>
        /// <param name="s"></param>
        private void Generate(int left, int right, int n, string s)
        {
            // terminator
            if (left == n && right == n)
            {
                result.Add(s);
                return;
            }

            // process current logic: 加左括号、加右括号            

            // drill down
            if (left < n) Generate(left + 1, right, n, s + "(");

            if (left > right) Generate(left, right + 1, n, s + ")");
        }
    }
}
