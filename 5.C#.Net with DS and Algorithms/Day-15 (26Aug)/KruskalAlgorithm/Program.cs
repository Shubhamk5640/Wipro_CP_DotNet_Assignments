using System;
using System.Collections.Generic;

namespace KruskalAlgorithm
{

    public class Edge : IComparable<Edge>
    {
        public int Source { get; set; }
        public int Destination { get; set; }
        public int Weight { get; set; }

        public int CompareTo(Edge other)
        {
            return this.Weight.CompareTo(other.Weight);
        }
    }

    public class Graph
    {
        public int Vertices { get; set; }
        public List<Edge> Edges { get; set; }

        public Graph(int vertices)
        {
            Vertices = vertices;
            Edges = new List<Edge>();
        }

        public void AddEdge(int source, int destination, int weight)
        {
            Edges.Add(new Edge() { Source = source, Destination = destination, Weight = weight });
        }

        private int Find(int[] parent, int i)
        {
            if (parent[i] != i)
                parent[i] = Find(parent, parent[i]);
            return parent[i];
        }

        private void Union(int[] parent, int[] rank, int x, int y)
        {
            int xroot = Find(parent, x);
            int yroot = Find(parent, y);

            if (rank[xroot] < rank[yroot])
                parent[xroot] = yroot;
            else if (rank[xroot] > rank[yroot])
                parent[yroot] = xroot;
            else
            {
                parent[yroot] = xroot;
                rank[xroot]++;
            }
        }

        // Kruskal's algorithm to find the MST
        public void KruskalMST()
        {
            List<Edge> result = new List<Edge>();
            int[] parent = new int[Vertices];
            int[] rank = new int[Vertices];


            for (int v = 0; v < Vertices; ++v)
            {
                parent[v] = v;
                rank[v] = 0;
            }

            Edges.Sort();

            int e = 0;
            int i = 0;


            while (e < Vertices - 1 && i < Edges.Count)
            {
                Edge nextEdge = Edges[i++];
                int x = Find(parent, nextEdge.Source);
                int y = Find(parent, nextEdge.Destination);

                if (x != y)
                {
                    result.Add(nextEdge);
                    e++;
                    Union(parent, rank, x, y);
                }
            }

            Console.WriteLine("Edges in the Minimum Spanning Tree:");
            foreach (var edge in result)
            {
                Console.WriteLine($"{edge.Source} -- {edge.Destination} == {edge.Weight}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int vertices = 4;
            Graph graph = new Graph(vertices);

            // Add edges to the graph
            graph.AddEdge(0, 1, 10);
            graph.AddEdge(0, 2, 6);
            graph.AddEdge(0, 3, 5);
            graph.AddEdge(1, 3, 15);
            graph.AddEdge(2, 3, 4);

            // Execute Kruskal's algorithm
            graph.KruskalMST();
        }
    }
}