using System;

namespace LeetCode_200
{
    /// <summary>
    /// 200. 岛屿数量
    /// https://leetcode-cn.com/problems/number-of-islands/
    /// </summary>
    public class Solution
    {
        static void Main(string[] args)
        {
            var sol = new Solution();

            //var strArry = new string[]
            //{
            //    "11110",
            //    "11010",
            //    "11000",
            //    "00000"
            //};

            var strArry = new string[]
            {
                "11000",
                "11000",
                "00100",
                "00011"
            };

            char[][] grid = new char[strArry.Length][];

            for(int i = 0; i < strArry.Length; i++)
            {
                grid[i] = strArry[i].ToCharArray();
            }

            var result = sol.NumIslands(grid);

            Console.WriteLine(result);

            Console.ReadLine();
        }

        /// <summary>
        /// 深度优先搜索
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int NumIslands(char[][] grid)
        {
            if (grid == null || grid.Length == 0) return 0;

            int rowCount = grid.Length;
            int colCount = grid[0].Length;
            int landCount = 0;
            for(int row = 0; row < rowCount; ++row)
            {
                for(int col = 0; col < colCount; ++col)
                {
                    if (grid[row][col] == '1')
                    {
                        landCount++;
                        DFS(grid, row, col);
                    }
                }
            }

            return landCount;
        }

        private void DFS(char[][] grid,int r,int c)
        {
            int rowCount = grid.Length;
            int colCount = grid[0].Length;

            if (r < 0 || c < 0 || r >= rowCount || c >= colCount || grid[r][c] == '0') return;

            grid[r][c] = '0';
            DFS(grid, r - 1, c);
            DFS(grid, r + 1, c);
            DFS(grid, r, c - 1);
            DFS(grid, r, c + 1);
        }
    }
}
