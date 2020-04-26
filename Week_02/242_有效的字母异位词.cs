using System;
using System.Collections.Generic;

namespace LeetCode_242
{
    /// <summary>
    /// 242. 有效的字母异位词
    /// https://leetcode-cn.com/problems/valid-anagram/
    /// </summary>
    public class Solution
    {
        static void Main(string[] args)
        {
            var sol = new Solution();
            string s = "r￥a$t", t = "c$a￥r";

            Console.WriteLine(sol.IsAnagram(s,t));

            Console.ReadLine();

        }

        ///// <summary>
        ///// 方法1 ： 排序
        /////     把字符串转换成数组，然后进行排序，
        /////     如果排序后的数组相同，就返回true
        ///// </summary>
        ///// <param name="s"></param>
        ///// <param name="t"></param>
        ///// <returns></returns>
        //public bool IsAnagram(string s, string t)
        //{
        //    if (s.Length != t.Length) return false;            

        //    var sArray = s.ToCharArray();
        //    var tArray = t.ToCharArray();
        //    Array.Sort(sArray);
        //    Array.Sort(tArray);

        //    return Enumerable.SequenceEqual(sArray, tArray);
        //}

        ///// <summary>
        ///// 方法2 ：字母计数器
        /////    
        ///// </summary>
        ///// <param name="s"></param>
        ///// <param name="t"></param>
        ///// <returns></returns>
        //public bool IsAnagram(string s, string t)
        //{
        //    if (s.Length != t.Length) return false;

        //    int[] counter = new int[26];
        //    char[] sArray = s.ToCharArray();
        //    char[] tArray = t.ToCharArray();

        //    for(int i= 0;i < s.Length;i++)            
        //        counter[sArray[i] - 'a']++;

        //    for (int i = 0; i < t.Length; i++)
        //    {
        //        counter[tArray[i] - 'a']--;
        //        if (counter[tArray[i] - 'a'] < 0)
        //            return false;
        //    }

        //    return true;           
        //}

        /// <summary>
        /// 进阶：如果输入字符串包含 unicode 字符怎么办？
        ///    用一个字典（map）记录字符出现的次数
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length) return false;

            Dictionary<char, int> dicCounter = new Dictionary<char, int>();
            char[] sArray = s.ToCharArray();
            char[] tArray = t.ToCharArray();
            for (int i = 0; i < s.Length; i++)
            {
                if (!dicCounter.ContainsKey(sArray[i]))
                    dicCounter[sArray[i]] = 1;
                else
                    dicCounter[sArray[i]]++;
            }

            for (int i = 0; i < t.Length; i++)
            {
                if (!dicCounter.ContainsKey(tArray[i])) return false;

                dicCounter[tArray[i]]--;

                if (dicCounter[tArray[i]] < 0) return false;
            }

            return true;
        }
    }
}
