using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static void Main()
        {
            //var reader = new StreamReader("../../input/2.txt");
            //Console.SetIn(reader);

            var firstInputLineParams = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();

            var numberOfBuildings = firstInputLineParams[0];
            var numberOfStreets = firstInputLineParams[1];
            var numberOfHospitals = firstInputLineParams[2];

            var hospitals = new HashSet<int>();
            var readHospitals = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(x => int.Parse(x));

            foreach (var h in readHospitals)
            {
                hospitals.Add(h);
            }

            var graph = new Graph<int>();
            var connections = new List<int[]>();

            for (int i = 0; i < numberOfStreets; i++)
            {
                connections.Add(Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => int.Parse(x))
                    .ToArray());
            }

            // AddNodesToGraph
            foreach (var connection in connections)
            {
                var fromNode = connection[0];
                var toNode = connection[1];
                var distance = connection[2];

                if (!graph.ContainsNode(fromNode))
                {
                    graph.AddNode(fromNode);
                }

                if (!graph.ContainsNode(toNode))
                {
                    graph.AddNode(toNode);
                }

                graph.AddConnection(fromNode, toNode, distance, true);
            }

            var distanceCalc = new DistanceCalculator<int>();

            var minDist = int.MaxValue;
            foreach (var hospital in hospitals)
            {
                var dist = distanceCalc.CalculateDistances(graph, hospital)
                    .Where(x => !hospitals.Contains(x.Key))
                    .Sum(x => x.Value);

                minDist = Math.Min(minDist, dist);
            }

            Console.WriteLine(minDist);
        }
    }

    public class Node<T>
    {
        private List<Edge<T>> connections;

        public Node(T name)
        {
            this.Name = name;
            this.connections = new List<Edge<T>>();
        }

        public T Name { get; set; }

        public IEnumerable<Edge<T>> Connections
        {
            get { return this.connections; }
        }

        public int DistanceFromStart { get; set; }

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
    }

    public class DistanceCalculator<T>
    {
        public IDictionary<T, int> CalculateDistances(Graph<T> graph, T startingNode)
        {
            if (!graph.Nodes.Any(n => n.Key.Equals(startingNode)))
            {
                throw new ArgumentException("Starting node must be in graph.");
            }

            this.InitializeGraph(graph, startingNode);
            this.ProcessGraph(graph, startingNode);
            return this.ExtractDistances(graph);
        }

        private void InitializeGraph(Graph<T> graph, T startingNode)
        {
            foreach (Node<T> node in graph.Nodes.Values)
            {
                node.DistanceFromStart = int.MaxValue;
            }

            graph.Nodes[startingNode].DistanceFromStart = 0;
        }

        private void ProcessGraph(Graph<T> graph, T startingNode)
        {
            bool finished = false;
            var queue = graph.Nodes.Values.ToList();
            while (!finished)
            {
                var nextNode =
                    queue.OrderBy(n => n.DistanceFromStart)
                        .FirstOrDefault(n => n.DistanceFromStart != int.MaxValue);

                if (nextNode != null)
                {
                    this.ProcessNode(nextNode, queue);
                    queue.Remove(nextNode);
                }
                else
                {
                    finished = true;
                }
            }
        }

        private void ProcessNode(Node<T> node, List<Node<T>> queue)
        {
            var connections = node.Connections.Where(c => queue.Contains(c.Target));
            foreach (var connection in connections)
            {
                int distance = node.DistanceFromStart + connection.Distance;
                if (distance < connection.Target.DistanceFromStart)
                {
                    connection.Target.DistanceFromStart = distance;
                }
            }
        }

        private IDictionary<T, int> ExtractDistances(Graph<T> graph)
        {
            return graph.Nodes.ToDictionary(n => n.Key, n => n.Value.DistanceFromStart);
        }
    }

}
