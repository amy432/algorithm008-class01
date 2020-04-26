using System;
using System.Collections.Generic;

namespace LeetCode_589
{
    /// <summary>
    /// 589. N叉树的前序遍历
    /// https://leetcode-cn.com/problems/n-ary-tree-preorder-traversal/
    /// </summary>
    public class Solution
    {
        static void Main(string[] args)
        {
            
        }

        /// <summary>
        /// 用栈实现迭代        
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> Preorder(Node root)
        {
            var result = new List<int>();
            if (root == null) return result;

            Stack<Node> stack = new Stack<Node>();
            stack.Push(root);

            while (stack.Count > 0)
            {
                Node treeNode = stack.Pop();
                result.Add(treeNode.val);

                if(treeNode.children!=null)
                {
                    // 栈是后进先出的，所以子节点应该是从右->左入栈
                    for(int i = treeNode.children.Count - 1; i >= 0; i--)                    
                        stack.Push(treeNode.children[i]);                    
                }
            }
            return result;
        }
    }


    // Definition for a Node.
    public class Node
    {
        public int val;
        public IList<Node> children;

        public Node() { }

        public Node(int _val)
        {
            val = _val;
        }

        public Node(int _val, IList<Node> _children)
        {
            val = _val;
            children = _children;
        }
    }

}
