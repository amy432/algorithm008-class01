using System;

namespace LeetCode_860
{
    public class Solution
    {
        /// <summary>
        /// 860. 柠檬水找零
        /// https://leetcode-cn.com/problems/lemonade-change/
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int[] bills = new int[] { 5, 5, 5, 10, 20 };

            var sol = new Solution();

            var result = sol.LemonadeChange(bills);

            Console.WriteLine(result);

            Console.ReadLine();
        }

        public bool LemonadeChange(int[] bills)
        {
            if (bills == null || bills.Length == 0) return true;

            int five = 0, ten = 0;
            for (int i = 0; i < bills.Length; i++)
            {
                switch (bills[i])
                {
                    case 5:
                        five++;
                        break;
                    case 10:
                        if (five == 0)
                            return false;

                        five--;
                        ten++;
                        break;
                    case 20:
                        if (five > 0 && ten > 0)
                        {
                            five--;
                            ten--;
                        }
                        else if (five >= 3)
                        {
                            five -= 3;
                        }
                        else
                        {
                            return false;
                        }
                        break;
                }
            }

            return true;
        }
    }
}
