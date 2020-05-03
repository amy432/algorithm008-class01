using System;
using System.Collections.Generic;

namespace LeetCode_102
{
    public class Solution
    {
        /// <summary>
        /// 102. 二叉树的层次遍历
        /// https://leetcode-cn.com/problems/binary-tree-level-order-traversal/
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        ///// <summary>
        ///// 方法 1：递归
        ///// </summary>
        ///// <param name="root"></param>
        ///// <returns></returns>
        //public IList<IList<int>> LevelOrder(TreeNode root)
        //{          
        //    if (root == null) return levels;
        //    Helper(root, 0);
        //    return levels;  
        //}

        //private List<IList<int>> levels = new List<IList<int>>();

        //private void Helper(TreeNode node,int level)
        //{
        //    if (levels.Count == level)
        //        levels.Add(new List<int>());

        //    levels[level].Add(node.val);

        //    if (node.left != null) Helper(node.left, level + 1);
        //    if (node.right != null) Helper(node.right, level + 1);
        //}


        /// <summary>
        /// 方法 2：迭代
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            var levels = new List<IList<int>>();
            if (root == null) return levels;

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int level = 0;
            while (queue.Count > 0)
            {
                levels.Add(new List<int>());

                int levelLength = queue.Count;

                for(int i = 0; i < levelLength; ++i)
                {
                    TreeNode node = queue.Dequeue();
                    levels[level].Add(node.val);

                    if (node.left != null) queue.Enqueue(node.left);
                    if (node.right != null) queue.Enqueue(node.right);
                }

                level++;
            }


            return levels;
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
