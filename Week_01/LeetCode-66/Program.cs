using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode_66
{
    public class Solution
    {
        // 66. 加一
        // https://leetcode-cn.com/problems/plus-one/
        public static void Main(string[] args)
        {
            var sol = new Solution();

            int[] digits = "989".ToCharArray().Select(t => int.Parse(t.ToString())).ToArray();

            var newArry = sol.PlusOne(digits);

            Console.WriteLine(string.Join(",",newArry));

            Console.ReadLine();
        }

        // 如果元素 = 9 ，需要考虑进位
        // 元素<9，加一之后可以直接返回
        public int[] PlusOne(int[] digits)
        {
            for(int i = digits.Length - 1; i >= 0; i--)
            {
                if (digits[i] == 9)
                    digits[i] = 0;
                else
                {
                    digits[i]++;
                    return digits;
                }
            }

            digits = new int[digits.Length + 1];
            digits[0] = 1;
            return digits;
        }
    }
}
