using System;
using System.Collections.Generic;

namespace LeetCode_104
{
    /// <summary>
    /// 104. 二叉树的最大深度
    /// https://leetcode-cn.com/problems/maximum-depth-of-binary-tree
    /// </summary>
    public class Solution
    {
        static void Main(string[] args)
        {
           
        }

        /// <summary>
        /// 每层扫荡，检查有没有子节点，
        /// 如果有就继续扫荡，直到没有子节点为止
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int MaxDepth(TreeNode root)
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

                    if (node.left != null) queue.Enqueue(node.left);
                    if (node.right != null) queue.Enqueue(node.right);
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
