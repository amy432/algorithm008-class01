using System;

namespace LeetCode_33
{
    /// <summary>
    /// 33. 搜索旋转排序数组
    /// https://leetcode-cn.com/problems/search-in-rotated-sorted-array/
    /// </summary>
    public class Solution
    {
        static void Main(string[] args)
        {
            var sol = new Solution();

            //int[] nums = new int[] { 4, 5, 6, 7, 0, 1, 2 };
            //int target = 0;

            //int[] nums = new int[] { 4, 5, 6, 7, 0, 1, 2 };
            //int target = 3;

            //int[] nums = new int[] { 8, 9, 1, 2, 3, 4, 5, 6, 7 };
            //int target = 7;

            int[] nums = new int[] { 3, 4, 5, 6, 7, 8, 9, 1, 2 };
            int target = 2;

            int result = sol.Search(nums, target);

            Console.WriteLine(result);

            Console.ReadLine();
        }

        public int Search(int[] nums, int target)
        {
          
            if (nums.Length < 1)
                return -1;
            else if (nums.Length == 1)
                return nums[0] == target ? 0 : -1;
                

            int left = 0, right = nums.Length-1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (nums[mid] == target) return mid;

                if (nums[left] <= nums[mid])
                {
                    if (nums[left] <= target && target < nums[mid])
                        right = mid - 1;
                    else
                        left = mid + 1;                    
                }
                else
                {
                    if (nums[mid] < target && target <= nums[right])
                        left = mid + 1;
                    else
                        right = mid - 1;
                }
            }

            return -1;
        }
    }
}
