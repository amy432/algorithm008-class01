using System;
using System.Collections.Generic;

namespace LeetCode_144
{
    /// <summary>
    /// 144. 二叉树的前序遍历
    /// https://leetcode-cn.com/problems/binary-tree-preorder-traversal/
    /// </summary>
    public class Solution
    {
        static void Main(string[] args)
        {
            
        }

        ///// <summary>
        ///// 方法1：递归
        ///// </summary>
        ///// <param name="root"></param>
        ///// <returns></returns>
        //public IList<int> PreorderTraversal(TreeNode root)
        //{
        //    var result = new List<int>();
        //    if (root == null) return result;

        //    result.Add(root.val);
        //    result.AddRange(PreorderTraversal(root.left));
        //    result.AddRange(PreorderTraversal(root.right));

        //    return result;
        //}

        /// <summary>
        /// 方法2 ： 迭代
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> PreorderTraversal(TreeNode root)
        {
            var result = new List<int>();
            if (root == null) return result;

            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);

            while (stack.Count > 0)
            {
                TreeNode treeNode = stack.Pop();
                result.Add(treeNode.val);

                if (treeNode.right != null)
                    stack.Push(treeNode.right);

                if (treeNode.left != null)
                    stack.Push(treeNode.left);

            }
            return result;
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
