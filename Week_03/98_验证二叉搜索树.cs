using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace LeetCode_98
{
    /// <summary>
    /// 98. 验证二叉搜索树
    /// https://leetcode-cn.com/problems/validate-binary-search-tree/
    /// </summary>
    public class Solution
    {
        static void Main(string[] args)
        {
            
        }

        ///// <summary>
        ///// 方法 1：递归
        ///// </summary>
        ///// <param name="root"></param>
        ///// <returns></returns>
        //public bool IsValidBST(TreeNode root)
        //{
        //    return Helper(root, null, null);
        //}

        //private bool Helper(TreeNode node, int? lower, int? upper)
        //{
        //    if (node == null) return true;

        //    int val = node.val;
        //    if (lower != null && val <= lower.Value) return false;
        //    if (upper != null && val >= upper.Value) return false;

        //    if (!Helper(node.right, val, upper)) return false;
        //    if (!Helper(node.left, lower, val)) return false;

        //    return true;
        //}     



        /// <summary>
        /// 方法 2：中序遍历
        ///      时间复杂度：O(n)
        ///      空间复杂度：O(n)
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsValidBST(TreeNode root)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();

            int inorder = -int.MaxValue;
            // 如果当树为[-int.MaxValue]时，与初始值对比会返回false
            bool first = true;

            while (stack.Count > 0 || root != null)
            {
                while (root != null)
                {
                    stack.Push(root);
                    root = root.left;
                }

                root = stack.Pop();
                if (!first && root.val <= inorder) return false;

                first = false;
                inorder = root.val;
                root = root.right;
            }

            return true;
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