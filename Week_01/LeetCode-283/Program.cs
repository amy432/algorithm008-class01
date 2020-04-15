using System;

namespace LeetCode_283
{
    public class Solution
    {
        // 283. 移动零
        // https://leetcode-cn.com/problems/move-zeroes/
        public static void Main(string[] args)
        {
            var sol = new Solution();
            int[] nums = new int[] {0,0, 1,2 };

            sol.MoveZeroes(nums);

            foreach (var num in nums)
                Console.WriteLine(num);

            Console.ReadLine();
        }

        // 用count标记非0元素的下标
        // 非0元素前移，并且count + 1
        public void MoveZeroes(int[] nums)
        {
            if (nums == null || nums.Length <= 1) return;

            int count = 0;
            for(int i = 0; i < nums.Length; i++)
            {
                if(nums[i]!=0)
                {
                    nums[count] = nums[i];
                    if (i != count)
                        nums[i] = 0; // 如果元素有前移，元素的原来位置用0替换。
                    count++;
                }                
            }            
        }
    }
}
