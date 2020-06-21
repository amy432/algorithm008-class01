using System;

namespace LeetCode_387
{
    /// <summary>
    /// 387. 字符串中的第一个唯一字符
    /// https://leetcode-cn.com/problems/first-unique-character-in-a-string/
    /// </summary>
    public class Solution
    {
        static void Main(string[] args)
        {
            var sol = new Solution();

            Console.WriteLine(sol.FirstUniqChar("leetcode"));

            Console.WriteLine(sol.FirstUniqChar("loveleetcode"));

            Console.ReadLine();
        }

        public int FirstUniqChar(string s)
        {
            int[] chars = new int[26];

            foreach(char c in s.ToCharArray())
            {
                chars[c-'a']++;
            }

            for(int i=0;i<s.Length;i++)
            {
                if (chars[s[i]-'a'] == 1)
                    return i;
            }

            return -1;
        }
    }
}
