using System;

namespace BalancedBinaryTreeCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();

            int[] valuesToInsert = { 10, 5, 15, 3, 7, 12, 18, 2, 4, 6, 8 };

            foreach (var value in valuesToInsert)
            {
                tree.Insert(value);
            }

            Console.WriteLine("Tree elements:");
            tree.PrintInsertedValues(tree.Root);

            Console.WriteLine("\n\nIs the binary tree balanced?");
            bool isBalanced = tree.IsBalanced(tree.Root);
            Console.WriteLine(isBalanced ? "Yes" : "No");
        }
    }
}