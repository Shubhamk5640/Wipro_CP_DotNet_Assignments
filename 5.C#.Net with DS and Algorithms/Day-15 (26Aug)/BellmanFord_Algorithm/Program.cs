using System;

namespace BellmanFord_Algorithm
{
    class Program
    {
        // Number of vertices in the graph
        private static int numVertices = 5;

        // Function that implements Bellman-Ford algorithm for a graph represented
        // using adjacency matrix representation
        public static void BellmanFord(int[,] graph, int startNode)
        {
            int[] dist = new int[numVertices]; // The output array dist[i] will hold the shortest distance from startNode to i

            // Step 1: Initialize distances from startNode to all other vertices as INFINITE
            for (int i = 0; i < numVertices; i++)
            {
                dist[i] = int.MaxValue;
            }
            dist[startNode] = 0;

            // Step 2: Relax all edges |V| - 1 times
            for (int count = 0; count < numVertices - 1; count++)
            {
                for (int u = 0; u < numVertices; u++)
                {
                    for (int v = 0; v < numVertices; v++)
                    {
                        if (graph[u, v] != 0 && dist[u] != int.MaxValue && dist[u] + graph[u, v] < dist[v])
                        {
                            dist[v] = dist[u] + graph[u, v];
                        }
                    }
                }
            }

            // Step 3: Check for negative-weight cycles.
            for (int u = 0; u < numVertices; u++)
            {
                for (int v = 0; v < numVertices; v++)
                {
                    if (graph[u, v] != 0 && dist[u] != int.MaxValue && dist[u] + graph[u, v] < dist[v])
                    {
                        Console.WriteLine("Graph contains a negative-weight cycle");
                        return;
                    }
                }
            }

            // Print the constructed distance array
            PrintSolution(dist, startNode);
        }

        // A utility function to print the constructed distance array
        private static void PrintSolution(int[] dist, int startNode)
        {

            Console.WriteLine("Vertex\t\tDistance from Source Node " + startNode);
            for (int i = 0; i < numVertices; i++)
            {
                Console.WriteLine(i + "\t\t" + dist[i]);
            }
        }

        // Main function
        static void Main(string[] args)
        {
            // Graph represented as an adjacency matrix
            int[,] graph = new int[,]
            {
                { 0, 10, 0, 30, 100 },
                { 10, 0, 50, 0, 0 },
                { 0, 50, 0, 20, 10 },
                { 30, 0, 20, 0, 60 },
                { 100, 0, 10, 60, 0 }
            };

            // Call Bellman-Ford algorithm with the start node as 0
            BellmanFord(graph, 0);

            // Pause the console to view results
            Console.ReadLine();
        }
    }
}