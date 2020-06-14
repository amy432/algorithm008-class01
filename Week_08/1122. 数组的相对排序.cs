using System;

namespace LeetCode_1122
{
    /// <summary>
    /// 1122. 数组的相对排序
    /// https://leetcode-cn.com/problems/relative-sort-array/
    /// </summary>
    public class Solution
    {
        static void Main(string[] args)
        {
            var sol = new Solution();

            int[] arr1 = new int[] { 2, 3, 1, 3, 2, 4, 6, 7, 9, 2, 19 };
            int[] arr2 = new int[] { 2, 1, 4, 3, 9, 6 };

            var result = sol.RelativeSortArray(arr1, arr2);

            Console.WriteLine(string.Join(',',result));

            Console.ReadLine();
        }

        /// <summary>
        /// 计数排序
        /// </summary>
        /// <param name="arr1"></param>
        /// <param name="arr2"></param>
        /// <returns></returns>
        public int[] RelativeSortArray(int[] arr1, int[] arr2)
        {
            int[] countArray = new int[1001];
            int[] result = new int[arr1.Length];
            int k = 0;

            for (int i = 0; i < arr1.Length; i++)
                countArray[arr1[i]]++;

            for(int i = 0; i < arr2.Length; i++)
            {
                while (countArray[arr2[i]] > 0)
                {
                    result[k++] = arr2[i];
                    countArray[arr2[i]]--;
                }
            }

            for(int i = 0; i < countArray.Length; i++)
            {
                while (countArray[i] > 0)
                {
                    result[k++] = countArray[i];
                    countArray[i]--;
                }
            }

            return result;
        }
    }
}
