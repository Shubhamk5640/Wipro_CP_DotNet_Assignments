using System;

namespace Floyd_Warshall_Algorithm
{
    class FloydWarshallAlgorithm
{
    // Define the number of vertices in the graph
    private static int numVertices = 4;

    // Function to implement the Floyd-Warshall algorithm
    public static void FloydWarshall(int[,] graph)
    {
        // dist will be the output matrix that will have the shortest
        // distances between every pair of vertices
        int[,] dist = new int[numVertices, numVertices];

        // Initialize the solution matrix same as the input graph matrix
        // or input graph representation
        for (int i = 0; i < numVertices; i++)
        {
            for (int j = 0; j < numVertices; j++)
            {
                dist[i, j] = graph[i, j];
            }
        }

        // Add all vertices one by one to the set of intermediate vertices.
        for (int k = 0; k < numVertices; k++)
        {
            for (int i = 0; i < numVertices; i++)
            {
                for (int j = 0; j < numVertices; j++)
                {
                    if (dist[i, k] != int.MaxValue && dist[k, j] != int.MaxValue &&
                        dist[i, k] + dist[k, j] < dist[i, j])
                    {
                        dist[i, j] = dist[i, k] + dist[k, j];
                    }
                }
            }
        }

        // Print the shortest distance matrix
        PrintSolution(dist);
    }

    // Utility function to print the solution
    private static void PrintSolution(int[,] dist)
    {
        for (int i = 0; i < numVertices; i++)
        {
            Console.WriteLine($"\nVertex\t\tDistance from Source Node {i}");
            for (int j = 0; j < numVertices; j++)
            {
                if (dist[i, j] == int.MaxValue)
                {
                    Console.WriteLine($"{j}\t\tInfinity");
                }
                else
                {
                    Console.WriteLine($"{j}\t\t{dist[i, j]}");
                }
            }
        }
    }

    // Main function to execute the Floyd-Warshall algorithm
    static void Main(string[] args)
    {
        // Define the graph as an adjacency matrix
        int[,] graph = {
            { 0, 3, int.MaxValue, 7 },
            { 8, 0, 2, int.MaxValue },
            { 5, int.MaxValue, 0, 1 },
            { 2, int.MaxValue, int.MaxValue, 0 }
        };

        // Execute the Floyd-Warshall algorithm
        FloydWarshall(graph);

        // Pause the console to view results
        Console.ReadLine();
    }
}
}