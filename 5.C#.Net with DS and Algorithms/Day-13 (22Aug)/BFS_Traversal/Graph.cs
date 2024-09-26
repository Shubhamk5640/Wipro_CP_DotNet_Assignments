using System;
using System.Collections.Generic;

namespace BFS_Traversal
{
    public class Graph
    {
        private readonly Dictionary<int, List<int>> _adjacencyList;

        public Graph()
        {
            _adjacencyList = new Dictionary<int, List<int>>();
        }

        public void AddEdge(int source, int destination)
        {
            if (!_adjacencyList.ContainsKey(source))
            {
                _adjacencyList[source] = new List<int>();
            }
            if (!_adjacencyList.ContainsKey(destination))
            {
                _adjacencyList[destination] = new List<int>();
            }

            _adjacencyList[source].Add(destination);
            _adjacencyList[destination].Add(source); // For undirected graph, add this line
        }

        public void BFS(int startNode)
        {
            var visited = new HashSet<int>();
            var queue = new Queue<int>();

            visited.Add(startNode);
            queue.Enqueue(startNode);



            Console.WriteLine("BFS Traversal from Node 1:");

            while (queue.Count > 0)
            {
                int currentNode = queue.Dequeue();
                Console.Write(currentNode + " ");

                foreach (var neighbor in _adjacencyList[currentNode])
                {
                    if (!visited.Contains(neighbor))
                    {
                        visited.Add(neighbor);
                        queue.Enqueue(neighbor);
                    }
                }
            }
            Console.WriteLine();
        }
    }
}