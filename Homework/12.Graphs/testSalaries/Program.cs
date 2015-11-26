using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testSalaries
{
    class Program
    {
        static void Main()
        {
            var graph = new Graph<int>();
            var linkedList = new LinkedList<Node<int>>();
            var numberOfEmployees = int.Parse(Console.ReadLine());

            // Create empty nodes
            for (int i = 0; i < numberOfEmployees; i++)
            {
                graph.AddNode(i);
            }

            // connect the nodes
            for (int row = 0; row < numberOfEmployees; row++)
            {
                var line = Console.ReadLine();
                for (int col = 0; col < numberOfEmployees; col++)
                {
                    if (line[col] == 'Y')
                    {
                        graph.Nodes[row]
                            .AddConnection(graph.Nodes[col], 1, false);
                    }
                }
            }

            foreach (var node in graph.Nodes)
            {
                linkedList.AddLast(node.Value);
            }

            ulong sallaryCounter = 0;
            while (linkedList.Count != 0)
            {
                var smallest = linkedList.FirstOrDefault(n => n.Connections.Count(c => !c.Visited) == 0);
                var smallestSalary = smallest.Salary != 0 ? smallest.Salary : 1;
                sallaryCounter += smallestSalary;
                foreach (var parent in smallest.Parents)
                {
                    parent.Salary += smallestSalary;
                }

                smallest.CleanConnectionsFromParents();
                linkedList.Remove(smallest);
            }

            Console.WriteLine(sallaryCounter);
        }
    }

    public class Node<T> : IComparable
    {
        private List<Edge<T>> connections;

        public Node(T name)
        {
            this.Name = name;
            this.connections = new List<Edge<T>>();
            this.Salary = 0;
            this.Parents = new List<Node<T>>();
        }

        public T Name { get; set; }

        public IList<Edge<T>> Connections
        {
            get { return this.connections; }
        }

        public int DistanceFromStart { get; set; }

        public ulong Salary { get; set; }

        public List<Node<T>> Parents { get; set; }

        public void AddConnection(Node<T> targetNode, int distance, bool twoWay)
        {
            if (targetNode == null)
            {
                throw new ArgumentNullException("targetNode");
            }

            if (targetNode == this)
            {
                throw new ArgumentException("Node may not connect to itself.");
            }

            if (distance <= 0)
            {
                throw new ArgumentException("Distance must be positive.");
            }

            this.connections.Add(new Edge<T>(targetNode, distance));
            if (twoWay)
            {
                targetNode.AddConnection(this, distance, false);
            }

            targetNode.Parents.Add(this);
        }

        public void CleanConnectionsFromParents()
        {
            foreach (var parent in this.Parents)
            {
                var parentConnections = parent.Connections
                    .Where(x => x.Target == this);
                foreach (var conn in parentConnections)
                {
                    conn.Visited = true;
                }
            }
        }

        public int CompareTo(object obj)
        {
            return this.Connections.Count(c => !c.Visited) -
                ((obj as Node<T>).Connections.Count(c => !c.Visited));
        }
    }

    public class Graph<T>
    {
        private Dictionary<T, Node<T>> nodes;

        public Graph()
        {
            this.nodes = new Dictionary<T, Node<T>>();
        }

        public IDictionary<T, Node<T>> Nodes
        {
            get { return this.nodes; }
        }

        public void AddNode(T name)
        {
            this.nodes.Add(name, new Node<T>(name));
        }

        public Node<T> GetFirstWithoutChildren()
        {
            var node = this.nodes
                .FirstOrDefault(n => n.Value.Connections.Count == 0).Value;
            return node;
        }

        public bool ContainsNode(T name)
        {
            return this.nodes.ContainsKey(name);
        }

        public void AddConnection(T fromNode, T toNode, int distance, bool twoWay)
        {
            this.nodes[fromNode].AddConnection(this.nodes[toNode], distance, twoWay);
        }
    }

    public class Edge<T>
    {
        internal Edge(Node<T> target, int distance)
        {
            this.Target = target;
            this.Distance = distance;
        }

        internal Node<T> Target { get; private set; }

        internal int Distance { get; private set; }

        public bool Visited { get; set; }
    }

}
