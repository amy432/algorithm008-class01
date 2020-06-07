using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode_208
{
    class Program
    {
        static void Main(string[] args)
        {
            Trie trie = new Trie();

            trie.Insert("apple");
            Console.WriteLine(trie.Search("apple"));
            Console.WriteLine(trie.Search("app"));
            Console.WriteLine(trie.StartsWith("app"));
            trie.Insert("app");
            Console.WriteLine(trie.StartsWith("app"));

            Console.ReadLine();
        }
    }

    public class Trie
    {
        private class Node
        {
            /// <summary>
            /// 是否单词末尾节点
            /// </summary>
            public bool isTail = false;

            public Dictionary<char, Node> nextNode;
            public Node(bool isTail)
            {
                this.isTail = isTail;
                this.nextNode = new Dictionary<char, Node>();
            }
            public Node() : this(false)
            {
            }
        }

        /// <summary>
        /// 根节点
        /// </summary>
        private Node rootNode;
        private int size;
        private int maxLength;


        /** Initialize your data structure here. */
        public Trie()
        {
            this.rootNode = new Node();
            this.size = 0;
            this.maxLength = 0;
        }

        /** Inserts a word into the trie. */
        public void Insert(string word)
        {
            // 从根节点开始
            Node cur = this.rootNode;

            // 循环便利单词
            foreach (char c in word.ToCharArray())
            {
                if (!cur.nextNode.ContainsKey(c))
                {
                    cur.nextNode.Add(c, new Node());
                }
                cur = cur.nextNode[c];
            }

            cur.isTail = true;
            if (word.Length > this.maxLength)
                this.maxLength = word.Length;

            size++;
        }

        /** Returns if the word is in the trie. */
        public bool Search(string word)
        {
            Node cur = FindLastNode(word);

            if (cur == null)
                return false;           

            return cur.isTail;
        }

        /** Returns if there is any word in the trie that starts with the given prefix. */
        public bool StartsWith(string prefix)
        {
            Node cur = FindLastNode(prefix);

            if (cur == null)
                return false;

            return true;
        }   
        
        private Node FindLastNode(string word)
        {
            Node cur = this.rootNode;

            if (word.Length == 0)
            {
                if (cur.isTail)
                {
                    return cur;
                }
                else
                {
                    return null;
                }
            }
        

            if (word.Length > this.maxLength)
                return null;

            foreach (char c in word.ToCharArray())
            {
                if (!cur.nextNode.ContainsKey(c))
                    return null;

                cur = cur.nextNode[c];
            }

            return cur;
        }
    }
}