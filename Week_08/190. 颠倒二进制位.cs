using System;

namespace LeetCode_190
{
    /// <summary>
    /// 190. 颠倒二进制位
    /// https://leetcode-cn.com/problems/reverse-bits/
    /// </summary>
    public class Solution
    {
        static void Main(string[] args)
        {
            var sol = new Solution();

            uint n = Convert.ToUInt32("00000010100101000001111010011100", 2);
            
            uint target = Convert.ToUInt32("00111001011110000010100101000000",2);

            Console.WriteLine(sol.reverseBits(n) == target);


            Console.ReadLine();
        }

        public uint reverseBits(uint n)
        {
            uint result = 0;

            for(int i = 0; i < 32; i++)
            {
                result = (result << 1) | (n & 1);
                n >>= 1;
            }         

            return result;
        }
    }
}
