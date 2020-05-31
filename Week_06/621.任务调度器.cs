using System;

namespace LeetCode_221
{
    /// <summary>
    /// 221.最大正方形
    /// https://leetcode-cn.com/problems/maximal-square/
    /// </summary>
    public class Solution
    {
        static void Main(string[] args)
        {
            var sol = new Solution();

            //char[][] matrix = new char[][]
            //{
            //    "10100".ToCharArray(),
            //    "10111".ToCharArray(),
            //    "11111".ToCharArray(),
            //    "10010".ToCharArray()
            //};

            char[][] matrix = new char[][]
            {
                "11111111".ToCharArray(),
                "11111110".ToCharArray(),
                "11111110".ToCharArray(),
                "11111000".ToCharArray(),
                "01111000".ToCharArray()
            };

            int result = sol.MaximalSquare(matrix);

            Console.WriteLine(result);
            Console.ReadLine();
        }

        ///// <summary>
        ///// 方法1：暴力法       
        ///// </summary>
        ///// <param name="matrix"></param>
        ///// <returns></returns>
        //public int MaximalSquare(char[][] matrix)
        //{            
        //    if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0)
        //        return 0;

        //    int maxSide = 0;

        //    int rows = matrix.Length;
        //    int cols = matrix[0].Length;

        //    for(int i = 0; i < rows; i++)
        //    {
        //        for(int j = 0; j < cols; j++)
        //        {
        //            // 不是1的略过
        //            if (matrix[i][j] != '1')
        //                continue;

        //            maxSide = Math.Max(maxSide, 1);

        //            // 计算可能的最大正方形边长
        //            int currentMaxSide = Math.Min(rows - i, cols - j);
        //            for(int k = 1; k < currentMaxSide; k++)
        //            {
        //                // 判断新增的一行一列是否均为 1
        //                bool flage = true;
        //                if (matrix[i + k][j + k] == '0')
        //                    break;

        //                for(int m = 0; m < k; m++)
        //                {
        //                    if(matrix[i+k][j+m]=='0' || matrix[i + m][j + k] == '0')
        //                    {
        //                        flage = false;
        //                        break;
        //                    }
        //                }

        //                if (!flage)
        //                    break;

        //                maxSide = Math.Max(maxSide, k + 1);
        //            }
                    
        //        }
        //    }

        //    return maxSide * maxSide;
        //}

        /// <summary>
        /// 方法2：动态规划
        /// 时间复杂度：O(mn)
        /// 空间复杂度：O(mn)
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public int MaximalSquare(char[][] matrix)
        {
            if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0)
                return 0;

            int maxSide = 0;
            int rows = matrix.Length;
            int cols = matrix[0].Length;
            int[,] dp = new int[rows, cols];
            for(int i = 0; i < rows; i++)
            {
                for(int j = 0; j < cols; j++)
                {
                    if (matrix[i][j] != '1')
                        continue;

                    dp[i, j] = 1;

                    if (i>0 && j>0 && matrix[i - 1][j] == '1' && matrix[i - 1][j - 1] == '1' && matrix[i][j - 1] == '1')
                    {
                        dp[i, j] = Math.Min(Math.Min(dp[i - 1, j], dp[i-1, j - 1]), dp[i, j-1])+1;
                    }
                   

                    maxSide = Math.Max(maxSide, dp[i,j]);
                }
            }
            return maxSide * maxSide;
        }
    }
}
