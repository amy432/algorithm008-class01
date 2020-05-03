using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode_169
{
    public class Solution
    {
        /// <summary>
        /// 169. 多数元素
        /// https://leetcode-cn.com/problems/majority-element/
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var sol = new Solution();
            int[] nums = new int[] { 2, 2, 1, 1, 1, 2, 2 };
            var result = sol.MajorityElement(nums);
            Console.WriteLine(result);

            Console.ReadLine();
        }

        ///// <summary>
        ///// 方法 1：暴力解法
        /////    双重for循环
        ///// </summary>
        ///// <param name="nums"></param>
        ///// <returns></returns>
        //public int MajorityElement(int[] nums)
        //{
        //    for(int i = 0; i < nums.Length; i++)
        //    {
        //        int count = 0;
        //        for(int j = 0; j < nums.Length; j++)
        //        {
        //            if(nums[j] == nums[i])
        //            {
        //                count++;

        //                if (count * 2 > nums.Length)
        //                    return nums[i];
        //            }
        //        }
        //    }

        //    throw new Exception("No majority element");
        //}

        ///// <summary>
        ///// 方法 2：哈希表
        /////     用一个哈希表记录每个元素出现的次数
        /////     抛出出现次数超过 `n/2`次的元素
        ///// </summary>
        ///// <param name="nums"></param>
        ///// <returns></returns>
        //public int MajorityElement(int[] nums)
        //{
        //    var dict = new Dictionary<int, int>();

        //    foreach (var num in nums)
        //    {
        //        if (dict.ContainsKey(num))
        //            dict[num]++;
        //        else
        //            dict[num] = 1;
        //    }

        //    foreach (var item in dict)
        //    {
        //        if (item.Value * 2 > nums.Length)
        //            return item.Key;
        //    }

        //    throw new Exception("No majority element");
        //}

        /// <summary>
        /// 方法 3：排序
        ///    把数组中的元素按照升序/降序排序
        ///    那么中间出现的元素总是“多数元素”
        ///    由于题目中的数据是一定会存在多数元素的，所以可以忽略不存在的情况
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MajorityElement(int[] nums)
        {
            Array.Sort(nums);
            return nums[nums.Length >> 1];
        }
    }
}
