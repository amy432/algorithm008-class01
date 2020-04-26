using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;

namespace LeetCode_429
{
    /// <summary>
    /// 429. N叉树的层序遍历
    /// https://leetcode-cn.com/problems/n-ary-tree-level-order-traversal/
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
        //public IList<IList<int>> LevelOrder(Node root)
        //{
        //    if (root != null) TraverseNode(root, 0);
        //    return result;
        //}

        //private List<IList<int>> result = new List<IList<int>>();

        //private void TraverseNode(Node node, int level)
        //{
        //    if (result.Count <= level) result.Add(new List<int>());

        //    result[level].Add(node.val);
        //    foreach (var child in node.children)
        //    {
        //        TraverseNode(child, level + 1);
        //    }
        //}

        ///// <summary>
        ///// 方法2：用两个List，
        /////     把每层的节点放在一个List中
        ///// </summary>
        ///// <param name="root"></param>
        ///// <returns></returns>
        //public IList<IList<int>> LevelOrder(Node root)
        //{
        //    var result = new List<IList<int>>();
        //    if (root == null) return result;

        //    var list = new List<Node>() { root };
        //    while (list.Count > 0)
        //    {
        //        var line = new List<int>();
        //        var levelNodes = new List<Node>();
        //        foreach(var node in list)
        //        {
        //            line.Add(node.val);
        //            if(node.children!=null) levelNodes.AddRange(node.children);
        //        }

        //        result.Add(line);
        //        list = levelNodes;
        //    }
        //    return result;
        //}

        /// <summary>
        /// 方法3 : 利用数组先进先出的特性进行求解
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList<int>> LevelOrder(Node root)
        {
            var result = new List<IList<int>>();
            if (root == null) return result;

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                int size = queue.Count;
                int[] line = new int[size];

                for(int i = 0; i < size; i++)
                {
                    var node = queue.Dequeue();
                    line[i] = node.val;
                    if (node.children != null)
                    {
                        foreach (var child in node.children)
                            queue.Enqueue(child);
                    }
                }

                result.Add(line);
            }
            return result;
        }
    }

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
