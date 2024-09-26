using BFS_Traversal;
using System;

namespace BFS_Traversal
{
    class Program
    {
        static void Main()
        {
            var graph = new Graph();


            graph.AddEdge(1, 2);
            graph.AddEdge(1, 3);
            graph.AddEdge(2, 4);
            graph.AddEdge(2, 5);
            graph.AddEdge(3, 6);
            graph.AddEdge(3, 7);
            graph.AddEdge(4, 8);
            graph.AddEdge(5, 9);


            graph.BFS(1);
        }
    }
}