using System;
using System.Collections.Generic;

namespace LeetCode_42
{
    public class Solution
    {
        public static void Main(string[] args)
        {
            var sol = new Solution();

            int[] height = new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };

            int result = sol.Trap(height);

            Console.WriteLine(result);

            Console.ReadLine();
        }

        ///// <summary>
        ///// 方法1：暴力求解
        /////     遍历每个元素，分别找出每个元素左边和右边的最大值。
        ///// 时间复杂度：O(n^2)
        ///// 空间复杂度：O(1)
        ///// </summary>
        ///// <param name="height"></param>
        ///// <returns></returns>
        //public int Trap(int[] height)
        //{
        //    // 凹字形才行接到雨水，所以至少要3个柱子
        //    if (height == null || height.Length < 3) return 0;
        //    int ans = 0;
        //    //最两端的列不用考虑，因为一定不会有水。所以下标从 1 到 length - 2
        //    for (int i = 1; i < height.Length - 1; i++)
        //    {
        //        int max_left = 0, max_right = 0;
        //        for (int j = i; j >= 0; j--)
        //        {
        //            max_left = Math.Max(max_left, height[j]);
        //        }
        //        for (int j = i; j < height.Length; j++)
        //        {
        //            max_right = Math.Max(max_right, height[j]);
        //        }

        //        ans += Math.Min(max_left, max_right) - height[i];
        //    }

        //    return ans;
        //}

        ///// <summary>
        ///// 方法 2：动态编程
        /////    对方法1的优化
        /////    创建两个数组，left_max[]，right_max[],分别从左到右和从右到左遍历，获取各个下标的左右最大值
        /////    这样就不用每次都要查左边和右边的最大值了
        ///// 时间复杂度：O(n)
        ///// 空间复杂度：O(n)
        ///// </summary>
        ///// <param name="height"></param>
        ///// <returns></returns>
        //public int Trap(int[] height)
        //{
        //    if (height == null || height.Length < 3) return 0;

        //    int ans = 0;

        //    int[] left_max = new int[height.Length]; // 存放左边的最大值
        //    int[] right_max = new int[height.Length]; // 存放右边的最大值

        //    left_max[0] = height[0];
        //    for (int i = 1; i < height.Length; i++)
        //    {
        //        left_max[i] = Math.Max(height[i], left_max[i - 1]);
        //    }

        //    right_max[height.Length - 1] = height[height.Length - 1];
        //    for (int j = height.Length - 2; j >= 0; j--)
        //    {
        //        right_max[j] = Math.Max(height[j], right_max[j + 1]);
        //    }

        //    // 用方法1的思路求解，不需要每次都遍历
        //    for (int i = 1; i < height.Length - 1; i++)
        //    {
        //        ans += Math.Min(left_max[i], right_max[i]) - height[i];
        //    }

        //    return ans;
        //}

        ///// <summary>
        ///// 方法3 ： 双指针法
        /////     这是对方法2的优化。
        /////     用两个指针分别从队列的两端向中间靠拢
        /////     计算左右指针的最大值，如果 leftMax < rightMax ，那么用 leftMax 计算左边的蓄水量, 反之亦然。
        /////     直到两个指针相遇为止。
        ///// 时间复杂度：O(n)
        ///// 空间复杂度：O(1)
        ///// </summary>
        ///// <param name="height"></param>
        ///// <returns></returns>
        //public int Trap(int[] height)
        //{           
        //    if (height == null || height.Length < 3) return 0;

        //    int ans = 0;
        //    int leftIndex = 0, rightIndex = height.Length-1;
        //    int leftMax = 0, rightMax = 0;

        //    while (leftIndex < rightIndex)
        //    {
        //        leftMax = Math.Max(leftMax, height[leftIndex]);
        //        rightMax = Math.Max(rightMax, height[rightIndex]);

        //        if (leftMax < rightMax)
        //        {
        //            ans += leftMax - height[leftIndex];
        //            leftIndex++;
        //        }
        //        else
        //        {
        //            ans += rightMax - height[rightIndex];
        //            rightIndex--;
        //        }
        //    }

        //    return ans;
        //}

        /// <summary>
        /// 方法4：栈
        ///     柱子要组成凹字形才行接到雨水，
        ///     把柱子压入栈，用current标记当前的柱子的下标
        ///     如果current的柱子比栈顶的柱子高，那么就有可能可以蓄水，      
        /// 时间复杂度：O(n)
        /// 空间复杂度：O(n)
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public int Trap(int[] height)
        {
            if (height == null || height.Length < 3) return 0;

            int ans = 0;

            Stack<int> stack = new Stack<int>();
            int current = 0;
            while (current < height.Length)
            {
                // 只有凹字形才能蓄水，因此右边的柱子比栈中最后1个柱子高，才有需要进行比较
                while (stack.Count > 0 && height[current] > height[stack.Peek()])
                {
                    int h = height[stack.Pop()];
                    if (stack.Count == 0)
                        break;

                    // 两个柱子之间的距离
                    int distanct = current - stack.Peek() - 1;
                    // 取出两个柱子中矮的那个
                    int min = Math.Min(height[stack.Peek()], height[current]);
                    ans += distanct * (min - h);
                }

                stack.Push(current);
                current++;
            }
            return ans;
        }
    }
}
