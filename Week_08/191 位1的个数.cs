using System;

namespace LeetCode_191
{
    public class Solution
    {
        static void Main(string[] args)
        {
            var sol = new Solution();
         
            Console.WriteLine(sol.HammingWeight(Convert.ToUInt32("00000000000000000000000000001011", 2)));
            Console.WriteLine(sol.HammingWeight(Convert.ToUInt32("00000000000000000000000010000000", 2)));
            Console.WriteLine(sol.HammingWeight(Convert.ToUInt32("11111111111111111111111111111101", 2)));
            
            Console.ReadLine();


        }
       
        public int HammingWeight(uint n)
        {
            int count = 0;
            while (n != 0)
            {
                if ((n & 1) == 1)
                {
                    count++;
                }
                n = n >> 1;
            }
            return count;
        }
    }
}
