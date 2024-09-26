using System;
using System.Collections.Generic;

class Program
{
    // Class to represent a graph edge
    public class Edge
    {
        public int Target { get; set; }
        public int Weight { get; set; }

        public Edge(int target, int weight)
        {
            Target = target;
            Weight = weight;
        }
    }

    // Class to represent a graph using adjacency list
    public class Graph
    {
        public int VerticesCount { get; set; }
        public List<Edge>[] AdjacencyList { get; set; }

        public Graph(int verticesCount)
        {
            VerticesCount = verticesCount;
            AdjacencyList = new List<Edge>[verticesCount];

            for (int i = 0; i < verticesCount; i++)
            {
                AdjacencyList[i] = new List<Edge>();
            }
        }

        public void AddEdge(int source, int target, int weight)
        {
            AdjacencyList[source].Add(new Edge(target, weight));
            // If the graph is undirected, also add the reverse edge
            // AdjacencyList[target].Add(new Edge(source, weight));
        }
    }

    public static int[] Dijkstra(Graph graph, int startVertex)
    {
        int verticesCount = graph.VerticesCount;
        int[] distances = new int[verticesCount];
        bool[] shortestPathTreeSet = new bool[verticesCount];

        // Initialize distances with infinity and shortestPathTreeSet as false
        for (int i = 0; i < verticesCount; i++)
        {
            distances[i] = int.MaxValue;
            shortestPathTreeSet[i] = false;
        }

        // Distance to the source vertex is always 0
        distances[startVertex] = 0;

        for (int i = 0; i < verticesCount - 1; i++)
        {
            int u = MinDistance(distances, shortestPathTreeSet, verticesCount);
            shortestPathTreeSet[u] = true;

            foreach (var edge in graph.AdjacencyList[u])
            {
                if (!shortestPathTreeSet[edge.Target] && distances[u] != int.MaxValue &&
                    distances[u] + edge.Weight < distances[edge.Target])
                {
                    distances[edge.Target] = distances[u] + edge.Weight;
                }
            }
        }

        return distances;
    }

    private static int MinDistance(int[] distances, bool[] shortestPathTreeSet, int verticesCount)
    {
        int min = int.MaxValue, minIndex = -1;

        for (int v = 0; v < verticesCount; v++)
        {
            if (!shortestPathTreeSet[v] && distances[v] <= min)
            {
                min = distances[v];
                minIndex = v;
            }
        }

        return minIndex;
    }

    public static void PrintDistances(int[] distances, int startVertex)
    {
        Console.WriteLine($"Distances from vertex {startVertex}:");

        for (int i = 0; i < distances.Length; i++)
        {
            Console.WriteLine($"Vertex {i} \t Distance {distances[i]}");
        }
    }

    static void Main(string[] args)
    {
        int verticesCount = 5;
        Graph graph = new Graph(verticesCount);

        graph.AddEdge(0, 1, 10);
        graph.AddEdge(0, 4, 5);
        graph.AddEdge(1, 2, 1);
        graph.AddEdge(1, 4, 2);
        graph.AddEdge(2, 3, 4);
        graph.AddEdge(3, 2, 6);
        graph.AddEdge(3, 0, 7);
        graph.AddEdge(4, 1, 3);
        graph.AddEdge(4, 2, 9);
        graph.AddEdge(4, 3, 2);

        int startVertex = 0;
        int[] distances = Dijkstra(graph, startVertex);

        PrintDistances(distances, startVertex);
    }
}