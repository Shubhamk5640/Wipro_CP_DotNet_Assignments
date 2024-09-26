using System;

namespace BalancedBinaryTreeCheck
{
    public class BinaryTree
    {
        public TreeNode Root;

        public BinaryTree()
        {
            Root = null;
        }

        public void Insert(int value)
        {
            if (Root == null)
            {
                Root = new TreeNode(value);
            }
            else
            {
                InsertRec(Root, value);
            }
        }

        private void InsertRec(TreeNode node, int value)
        {
            if (value < node.Value)
            {
                if (node.Left == null)
                {
                    node.Left = new TreeNode(value);
                }
                else
                {
                    InsertRec(node.Left, value);
                }
            }
            else
            {
                if (node.Right == null)
                {
                    node.Right = new TreeNode(value);
                }
                else
                {
                    InsertRec(node.Right, value);
                }
            }
        }

        public void PrintInsertedValues(TreeNode node)
        {
            if (node == null) return;

            Console.Write(node.Value + " ");
            PrintInsertedValues(node.Left);
            PrintInsertedValues(node.Right);
        }

        public bool IsBalanced(TreeNode node)
        {
            return CheckHeight(node) != -1;
        }

        private int CheckHeight(TreeNode node)
        {
            if (node == null) return 0;

            int leftHeight = CheckHeight(node.Left);
            if (leftHeight == -1) return -1;

            int rightHeight = CheckHeight(node.Right);
            if (rightHeight == -1) return -1;

            if (Math.Abs(leftHeight - rightHeight) > 1)
            {
                return -1;
            }
            else
            {
                return Math.Max(leftHeight, rightHeight) + 1;
            }
        }
    }
}