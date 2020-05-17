using System;
using System.Collections.Generic;

namespace LeetCode_874
{
    /// <summary>
    /// 874. 模拟行走机器人
    /// https://leetcode-cn.com/problems/walking-robot-simulation/
    /// </summary>
    public class Solution
    {
        static void Main(string[] args)
        {
            var sol = new Solution();

            //int[] commands = new int[] { 4, -1, 3 };
            //int[][] obstacles = new int[0][];

            int[] commands = new int[] { 4, -1, 4, -2, 4 };
            int[][] obstacles = new int[][] { new int[]{2,4 } };            

            var result = sol.RobotSim(commands, obstacles);
            Console.WriteLine(result); 

            Console.ReadLine();
        }       

        public int RobotSim(int[] commands, int[][] obstacles)
        {            
            int[][] dire = new int[][] {
                   new int[]{ 0, 1 },
                   new int[]{ 1,0},
                   new int[]{0,-1},
                   new int[]{-1,0}};

            int max = 0,x=0,y=0,di=0;

            var obstacleSet = new HashSet<KeyValuePair<int,int>>();
            foreach(int[] obstacle in obstacles)
            {
                obstacleSet.Add(new KeyValuePair<int, int>(obstacle[0], obstacle[1]));
            }

            foreach(int cmd in commands)
            {
                if (cmd == -2) // 左转
                {
                    di = (di + 3) % 4;
                }
                else if (cmd == -1) // 右转
                {
                    di = (di + 1) % 4;
                }
                else
                {
                    for(int k = 0; k < cmd; k++)
                    {
                        int newX = x + dire[di][0];
                        int newY = y + dire[di][1];

                        if(obstacleSet.Contains(new KeyValuePair<int, int>(newX, newY)))
                        {
                            // 有障碍物
                            break;
                        }
                        else
                        {
                            x = newX;
                            y = newY;
                            max = Math.Max(max, x * x + y * y);
                        }
                    }
                }
            }

            return max;
        }
    }
}
