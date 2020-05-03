using System;
using System.Collections.Generic;

namespace LeetCode_105
{
    /// <summary>
    /// 105. 从前序与中序遍历序列构造二叉树
    /// https://leetcode-cn.com/problems/construct-binary-tree-from-preorder-and-inorder-traversal
    /// </summary>
    public class Solution
    {
        static void Main(string[] args)
        {
            var sol = new Solution();
            int[] preorder = new int[] { 3, 9, 20, 15, 7 };
            int[] inorder = new int[] { 9, 3, 15, 20, 7 };

            var newTree = sol.BuildTree(preorder, inorder);

            Console.ReadLine();
        }

        /// <summary>
        /// 递归
        ///     前序遍历：父 -> 左 -> 右，那么第1个元素是根节点
        ///     中序遍历：左 -> 父 -> 右，那么前序遍历的第1个元素把中序遍历的数组分成左右子树
        /// </summary>
        /// <param name="preorder"></param>
        /// <param name="inorder"></param>
        /// <returns></returns>
        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            this._PreOrder = preorder;

            for (int i = 0; i < inorder.Length; i++)
                dict[inorder[i]] = i;

            return Helper(0, inorder.Length);
        }

        private int[] _PreOrder;
        private int preIndex = 0;
        private Dictionary<int, int> dict = new Dictionary<int, int>();


        private TreeNode Helper(int leftIndex, int rightIndex)
        {
            // recursion terminator
            if (leftIndex == rightIndex) return null;

            // process current logic
            int rootVal = _PreOrder[preIndex];
            TreeNode root = new TreeNode(rootVal);
            int index = dict[rootVal];
            preIndex++;

            // drill down
            root.left = Helper(leftIndex, index); // 构造左子树
            root.right = Helper(index + 1, rightIndex);  // 构造右子树

            return root;
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
