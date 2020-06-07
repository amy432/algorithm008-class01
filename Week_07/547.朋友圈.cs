using System;

namespace LeetCode_547
{
    public class Solution
    {
        static void Main(string[] args)
        {
            var sol = new Solution();

            int[][] M = new int[][]
            {
               new int[] {1,1,0 },
               new int[] {1,1,0 },
               new int[] {0,0,1}
            };

            int result = sol.FindCircleNum(M);

            Console.WriteLine(result);

            Console.ReadLine();
        }

        public int FindCircleNum(int[][] M)
        {
            int n = M.Length;
            UnionFind uf = new UnionFind(n);
            for(int i = 0; i < n - 1; i++)
            {
                for(int j = i + 1; j < n; j++)
                {
                    if (M[i][j] == 1)
                        uf.Union(i, j);
                }
            }

            return uf.Count();
        }
    }

    public class UnionFind
    {
        private int count = 0;
        private int[] parent;

        public UnionFind(int n)
        {
            count = n;
            parent = new int[n];
            for (int i = 0; i < n; i++)
                parent[i] = i;
        }

        public int Find(int p)
        {
            while(p!=parent[p])
            {
                parent[p] = parent[parent[p]];
                p = parent[p];
            }

            return p;
        }

        public void Union(int p,int q)
        {
            int rootP = Find(p);
            int rootQ = Find(q);
            if (rootP == rootQ) return;
            parent[rootP] = rootQ;
            count--;
        }

        public int Count()
        {
            return count;
        }
    }
}
