using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS_BST_Printer_Console
{
    class Node
    {
        public Node LeftNode { get; set; }
        public Node RightNode { get; set; }
        public int Time { get; set; }
    }
    class BinaryTree
    {
        public Node Root { get; set; }

        public bool Add(int value)
        {
            Node before = null, after = this.Root;

            while (after != null)
            {
                before = after;
                if (value < after.Time) //Is new node in left tree? 
                {
                    after = after.LeftNode;
                }
                else 
                {
                    after = after.RightNode;
                }
            }

            Node newNode = new Node();
            newNode.Time = value;

            if (this.Root == null)//Tree ise empty
                this.Root = newNode;
            else
            {
                if (value < before.Time)
                {
                    before.LeftNode = newNode;
                }
                else
                {
                    before.RightNode = newNode;
                }
            }

            return true;
        }

        public Node Find(int value)
        {
            return this.Find(value, this.Root);
        }

        public void Remove(int value)
        {
            Remove(this.Root, value);
        }

        private Node Remove(Node parent, int key)
        {
            if (parent == null) return parent;

            if (key < parent.Time) parent.LeftNode = Remove(parent.LeftNode, key);
            else if (key > parent.Time)
                parent.RightNode = Remove(parent.RightNode, key);

            // if value is same as parent's value, then this is the node to be deleted  
            else
            {
                // node with only one child or no child  
                if (parent.LeftNode == null)
                    return parent.RightNode;
                else if (parent.RightNode == null)
                    return parent.LeftNode;

                // node with two children: Get the inorder successor (smallest in the right subtree)  
                parent.Time = MinValue(parent.RightNode);

                // Delete the inorder successor  
                parent.RightNode = Remove(parent.RightNode, parent.Time);
            }

            return parent;
        }

        private int MinValue(Node node)
        {
            int minv = node.Time;

            while (node.LeftNode != null)
            {
                minv = node.LeftNode.Time;
                node = node.LeftNode;
            }

            return minv;
        }

        private Node Find(int value, Node parent)
        {
            if (parent != null)
            {
                if (value == parent.Time) return parent;
                if (value < parent.Time)
                    return Find(value, parent.LeftNode);
                else
                    return Find(value, parent.RightNode);
            }

            return null;
        }

        public int GetTreeDepth()
        {
            return this.GetTreeDepth(this.Root);
        }

        private int GetTreeDepth(Node parent)
        {
            return parent == null ? 0 : Math.Max(GetTreeDepth(parent.LeftNode), GetTreeDepth(parent.RightNode)) + 1;
        }

        public void TraversePreOrder(Node parent)
        {
            if (parent != null)
            {
                Console.Write(parent.Time + " ");
                TraversePreOrder(parent.LeftNode);
                TraversePreOrder(parent.RightNode);
            }
        }

        public void TraverseInOrder(Node parent)
        {
            if (parent != null)
            {
                TraverseInOrder(parent.LeftNode);
                Console.Write(parent.Time + " ");
                TraverseInOrder(parent.RightNode);
            }
        }

        public void TraversePostOrder(Node parent)
        {
            if (parent != null)
            {
                TraversePostOrder(parent.LeftNode);
                TraversePostOrder(parent.RightNode);
                Console.Write(parent.Time + " ");
            }
        }
    }
}
