using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode_350
{
    public class Solution
    {
        /// <summary>
        /// 350. 两个数组的交集II
        /// https://leetcode-cn.com/problems/intersection-of-two-arrays-ii/
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var sol = new Solution();
            int[] nums1 = new int[] { 1, 2, 2, 1 };
            int[] nums2 = new int[] { 2,2 };

            var result = sol.Intersect(nums1, nums2);

            Console.WriteLine(string.Join(',',result));

            Console.ReadLine();
        }

        ///// <summary>
        ///// 方法1 ： 单指针法。       
        ///// </summary>
        ///// <param name="nums1"></param>
        ///// <param name="nums2"></param>
        ///// <returns></returns>
        //public int[] Intersect(int[] nums1, int[] nums2)
        //{
        //    if (nums1.Length == 0 || nums2.Length == 0) return new int[0];

        //    var list = new List<int>();

        //    int tail2 = nums2.Length - 1;

        //    foreach (int num in nums1)
        //    {
        //        for (int i = 0; i <= tail2; i++)
        //        {
        //            if (nums2[i] == num)
        //            {
        //                list.Add(num);
        //                nums2[i] = nums2[tail2--];
        //                break;
        //            }
        //        }
        //    }

        //    return list.ToArray();
        //}

        /// <summary>
        /// 方法2：哈希表
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public int[] Intersect(int[] nums1, int[] nums2)
        {
            if (nums1.Length == 0 || nums2.Length == 0) return new int[0];

            var result = new List<int>();
            var dict = new Dictionary<int, int>();

            foreach (var num in nums1)
                dict[num] = dict.ContainsKey(num) ? dict[num] + 1 : 1;

            foreach(var num in nums2)
            {
                if(dict.ContainsKey(num) && dict[num] > 0)
                {
                    result.Add(num);
                    dict[num]--;
                }
            }
            return result.ToArray();
        }
    }
}
