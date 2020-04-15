using System;

namespace LeetCode_88
{
    public class Solution
    {
        public static void Main(string[] args)
        {
            var sol = new Solution();

            int[] nums1 = new int[] { 1, 2, 3, 0, 0, 0 };
            int m = 3;
            int[] nums2 = new int[] { 2, 5, 6 };
            int n = 3;

            sol.Merge(nums1, m, nums2, n);

            foreach(var num in nums1)
                Console.WriteLine(num);

            Console.ReadLine();
        }

        // 两个数组都是有序的，
        // 使用3个指针分别指向nums1的有效值的下标、nums2的下标、nums1的下标
        // 分别对比两个数组的值，数值大的放在nums1的最后面，同时移动指针。
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int len1 = m - 1;
            int len2 = n - 1;
            int len = m + n - 1;

            while(len1>=0 && len2 >= 0)
            {
                nums1[len--] = nums1[len1] > nums2[len2] ? nums1[len1--] : nums2[len2--];
            }

            if (len2 >= 0)
                Array.Copy(nums2, nums1, len2 + 1);
           
        }
    }
}
