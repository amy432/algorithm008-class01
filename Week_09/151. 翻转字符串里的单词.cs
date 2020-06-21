using System;
using System.Text;

namespace LeetCode_151
{
    /// <summary>
    /// 151. 翻转字符串里的单词
    /// https://leetcode-cn.com/problems/reverse-words-in-a-string/
    /// </summary>
    public class Solution
    {
        static void Main(string[] args)
        {

            var sol = new Solution();

            Console.WriteLine(sol.ReverseWords("the sky is blue"));
            Console.WriteLine(sol.ReverseWords("  hello world!  "));
            Console.WriteLine(sol.ReverseWords("a good   example"));

            Console.ReadLine();
        }

        public string ReverseWords(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return "";

            var arry = s.Split(' ',StringSplitOptions.RemoveEmptyEntries);

            StringBuilder sb = new StringBuilder();

            for(int i=arry.Length-1;i>=0;i--)
            {
                sb.Append(arry[i]);

                if(i>0)
                   sb.Append(" ");
            }

            return sb.ToString();
        }
    }
}
