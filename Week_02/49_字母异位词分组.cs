using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode_49
{
    /// <summary>
    /// 49.字母异位词分组
    /// </summary>
    public class Solution
    {
        static void Main(string[] args)
        {
            var sol = new Solution();
            var strs = new string[] { "eat", "tea", "tan", "ate", "nat", "bat" };

            var result = sol.GroupAnagrams(strs);

            foreach(var words in result)
            {
                Console.WriteLine(string.Join(',',words));
            }

            Console.ReadLine();
        }

        /// <summary>
        /// 将字符串中的字符排序，如果排序后相同的，放在一个组
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            if (strs == null || strs.Length == 0) return new List<string>[0];

            var dict = new Dictionary<string, List<string>>();
            foreach (var s in strs)
            {               
                string key = string.Concat(s.OrderBy(ch => ch));
                if (!dict.ContainsKey(key))
                    dict.Add(key, new List<string>());
                dict[key].Add(s);
            }

            return dict.Values.ToArray();
        }       
    }
}
