using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace LeetCode_236
{
    /// <summary>
    /// 236. 二叉树的最近公共祖先
    /// https://leetcode-cn.com/problems/lowest-common-ancestor-of-a-binary-tree/
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
        ///// <param name="p"></param>
        ///// <param name="q"></param>
        ///// <returns></returns>
        //public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        //{
        //    if (root == null || root.val == p.val || root.val == q.val) return root;

        //    TreeNode left = LowestCommonAncestor(root.left, p, q);
        //    TreeNode right = LowestCommonAncestor(root.right, p, q);

        //    // 如果左边没找到，则返回右节点，反之，返回左结点；
        //    if (left == null) return right;
        //    if (right == null) return left;

        //    // 如果左右都找这到了，说明当前节点就是最近公共祖先
        //    return root;
        //}

        /// <summary>
        /// 方法 2：递归优化
        ///    
        /// </summary>
        /// <param name="root"></param>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            IsAncestor(root, p, q);
            return res;
        }

        private TreeNode res;

        public bool IsAncestor(TreeNode head, TreeNode p, TreeNode q)
        {
            if (res != null || head == null)
                return false;

            bool left = IsAncestor(head.left, p, q);
            bool right = IsAncestor(head.right, p, q);
            bool mid = (head.val == p.val || head.val == q.val);
            if (mid ? (left || right) : (left && right))
                res = head;

            return left || right || mid;
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
