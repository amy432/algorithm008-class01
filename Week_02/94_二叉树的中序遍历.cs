using System;
using System.Collections.Generic;

namespace LeetCode_94
{
    /// <summary>
    /// 94. 二叉树的中序遍历
    /// https://leetcode-cn.com/problems/binary-tree-inorder-traversal/
    /// </summary>
    public class Solution
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        ///// <summary>
        ///// 方法1：递归求解
        ///// </summary>
        ///// <param name="root"></param>
        ///// <returns></returns>
        //public IList<int> InorderTraversal(TreeNode root)
        //{
        //    var result = new List<int>();
        //    if (root == null) return result;

        //    result.AddRange(InorderTraversal(root.left));
        //    result.Add(root.val);           
        //    result.AddRange(InorderTraversal(root.right));

        //    return result;
        //}

        /// <summary>
        /// 方法2：迭代算法
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> InorderTraversal(TreeNode root)
        {
            var result = new List<int>();
            if (root == null) return result;

            Stack<TreeNode> stack = new Stack<TreeNode>();
            while (root != null || stack.Count > 0)
            {
                while (root != null) 
                {
                    stack.Push(root);
                    root = root.left; // 遍历左子树，把左子树都进栈
                }

                root = stack.Pop();
                result.Add(root.val);
                root = root.right; // 遍历右子树
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
