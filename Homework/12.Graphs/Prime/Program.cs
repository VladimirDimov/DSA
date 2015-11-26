using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prime
{
    class Program
    {
        static void Main()
        {
            var graph = new List<Edge>();
            graph.Add(new Edge("A", "B", 1));
            graph.Add(new Edge("A", "C", 2));
            graph.Add(new Edge("B", "D", 3));
            graph.Add(new Edge("B", "E", 5));
            graph.Add(new Edge("C", "E", 15));
            graph.Add(new Edge("D", "E", 4));
            graph.Add(new Edge("D", "F", 5));
            graph.Add(new Edge("E", "F", 2));

            var priority = new SortedSet<Edge>();
            var visitedNodes = new HashSet<string>();

            foreach (var edge in graph)
            {
                if (edge.StartNode == graph[0].StartNode)
                {
                    priority.Add(edge);
                }
            }

            var result = new List<Edge>();
            while (priority.Count != 0)
            {
                var minEdge = priority.Min;

                if (!visitedNodes.Contains(minEdge.EndNode))
                {
                    result.Add(minEdge);
                    minEdge.Visited = true;
                    visitedNodes.Add(minEdge.EndNode);
                    AddEdgesFromNode(graph, minEdge.EndNode, priority);
                }

                priority.Remove(minEdge);
            }

            foreach (var edge in result)
            {
                Console.WriteLine(edge);
            }
        }

        private static void AddEdgesFromNode(List<Edge> graph, string endNode, SortedSet<Edge> priority)
        {
            foreach (var edge in graph)
            {
                if (edge.StartNode == endNode)
                {
                    priority.Add(edge);
                }
            }
        }
    }

    public class Edge : IComparable
    {
        public Edge(string startNode, string targetNode, int weight)
        {
            this.StartNode = startNode;
            this.EndNode = targetNode;
            this.Weight = weight;
        }

        public string StartNode { get; private set; }

        public string EndNode { get; private set; }

        public int Weight { get; set; }

        public bool Visited { get; set; }

        public int CompareTo(object obj)
        {
            return this.Weight.CompareTo((obj as Edge).Weight);
        }

        public override string ToString()
        {
            return string.Format("{0} - {1} : {2}",
                this.StartNode, this.EndNode, this.Weight);
        }
    }
}
