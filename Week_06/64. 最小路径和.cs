using System;
using System.Text.RegularExpressions;

namespace LeetCode_64
{
    /// <summary>
    /// 64. 最小路径和
    /// https://leetcode-cn.com/problems/minimum-path-sum/
    /// </summary>
    public class Solution
    {
        static void Main(string[] args)
        {
            var sol = new Solution();

            //// 返回 7
            //int[][] grid = new int[3][]
            //{
            //    new int[]{ 1, 3, 1 },
            //    new int[]{ 1,5,1 },
            //    new int[]{ 4, 2, 1 }
            //};

            // 返回 8
            int[][] grid = new int[3][]
            {
                new int[]{ 1,2},
                new int[]{ 5,6},
                new int[]{ 1,1 }
            };

            var result = sol.MinPathSum(grid);
            Console.WriteLine(result);

            Console.ReadLine();
        }

        ///// <summary>
        ///// 方法 1 ：暴力解法
        ///// 时间复杂度：O(2 ^ m+n)
        ///// 空间复杂度：O(m+n)
        ///// </summary>
        ///// <param name="grid"></param>
        ///// <returns></returns>
        //public int MinPathSum(int[][] grid)
        //{
        //    return Calculate(grid, 0, 0);
        //}

        //private int Calculate(int[][] grid,int i,int j)
        //{
        //    if (i == grid.Length || j == grid[0].Length)
        //        return int.MaxValue;

        //    if (i == grid.Length - 1 && j == grid[0].Length - 1)
        //        return grid[i][j];

        //    return grid[i][j] + Math.Min(Calculate(grid, i + 1, j), Calculate(grid, i, j + 1));
        //}

        ///// <summary>
        ///// 方法 2：动态规划
        ///// 时间复杂度：O(mn)
        ///// 空间复杂度：O(mn)
        ///// </summary>
        ///// <param name="grid"></param>
        ///// <returns></returns>
        //public int MinPathSum(int[][] grid)
        //{
        //    int lastRowIndex = grid.Length-1;
        //    int lastColIndex = grid[0].Length-1;

        //    int[,] dp = new int[lastRowIndex+1, lastColIndex+1];

        //    for(int i = lastRowIndex; i >= 0; i--)
        //    {
        //        for(int j = lastColIndex; j >= 0; j--)
        //        {
        //            if (i == lastRowIndex && j != lastColIndex)
        //                dp[i, j] = grid[i][j] + dp[i, j + 1];
        //            else if (i != lastRowIndex && j == lastColIndex)
        //                dp[i, j] = grid[i][j] + dp[i + 1, j];
        //            else if (i != lastRowIndex && j != lastColIndex)
        //                dp[i, j] = grid[i][j] + Math.Min(dp[i + 1, j], dp[i, j + 1]);
        //            else
        //                dp[i, j] = grid[i][j];
        //        }
        //    }
        //    return dp[0, 0];
        //}

        /// <summary>
        /// 方法 3：动态规划优化
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MinPathSum(int[][] grid)
        {
            int lastRowIndex = grid.Length - 1;
            int lastColIndex = grid[0].Length - 1;

            for(int i = lastRowIndex; i >= 0; i--)
            {
                for(int j = lastColIndex; j >= 0; j--)
                {
                    if (i == lastRowIndex && j != lastColIndex)
                        grid[i][j] = grid[i][j] + grid[i][j + 1];
                    else if(i!=lastRowIndex && j==lastColIndex)
                        grid[i][j] = grid[i][j] + grid[i+1][j];
                    else if(i!= lastRowIndex && j!=lastColIndex)
                        grid[i][j] = grid[i][j] + Math.Min(grid[i][j + 1],grid[i + 1][j]);                   

                }
            }
            return grid[0][0];
        }
    }
}
