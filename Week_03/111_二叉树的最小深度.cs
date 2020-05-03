using System;
using System.Collections.Generic;

namespace LeetCode_111
{
    /// <summary>
    /// 111. 二叉树的最小深度
    /// https://leetcode-cn.com/problems/minimum-depth-of-binary-tree/
    /// </summary>
    public class Solution
    {
        static void Main(string[] args)
        {

        }

        /// <summary>
        /// 每层扫荡，检查是否存在叶子节点，第一次出现叶子节点的地方就是最小深度
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int MinDepth(TreeNode root)
        {
            if (root == null) return 0;

            int level = 0;

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                level++;
                int levelLength = queue.Count;
                for(int i = 0; i < levelLength; i++)
                {
                    TreeNode node = queue.Dequeue();

                    if (node.left == null && node.right == null)
                        return level;
                    else
                    {
                        if (node.left != null) queue.Enqueue(node.left);
                        if (node.right != null) queue.Enqueue(node.right);
                    }
                }
            }

            return level;
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
}
