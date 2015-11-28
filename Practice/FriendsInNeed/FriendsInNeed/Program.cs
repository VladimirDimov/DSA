using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendsInNeed
{
    class Program
    {
        static void Main()
        {
            var nodesConnectionsHospitals = Console.ReadLine()
                .Split(new char[] { ' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();
            var numberOfNodes = nodesConnectionsHospitals[0];
            var numberOfConnections = nodesConnectionsHospitals[1];
            var numberOfHospitals = nodesConnectionsHospitals[2];

            var graph = new Dictionary<int, Node>();

            var hospitals = Console.ReadLine()
                .Split()
                .Select(x => int.Parse(x));

            var hospitalsList = new List<Node>();
            foreach (var item in hospitals)
            {
                var hospitalToAdd = new Node(item, true);
                graph.Add(item, hospitalToAdd);
                hospitalsList.Add(hospitalToAdd);
            }

            for (int i = 0; i < numberOfConnections; i++)
            {
                var currentConnection = Console.ReadLine()
                    .Split()
                    .ToArray();

                var a = int.Parse(currentConnection[0]);
                var b = int.Parse(currentConnection[1]);
                var d = double.Parse(currentConnection[2]);

                if (!graph.ContainsKey(a))
                {
                    graph.Add(a, new Node(a, false));
                }
                if (!graph.ContainsKey(b))
                {
                    graph.Add(b, new Node(b, false));
                }

                graph[a].Connections.Add(new Connection(graph[b], d));
                graph[b].Connections.Add(new Connection(graph[a], d));
            }

            var minDistance = double.MaxValue;
            foreach (var h in hospitalsList)
            {
                DijkstraAlgorithm(graph, h);
                var currentDistance = graph
                    .Where(x => !x.Value.IsHospital)
                    .Select(x => x.Value.DijkstraDistance)
                    .Sum();

                if (minDistance > currentDistance)
                {
                    minDistance = currentDistance;
                }
            }

            Console.WriteLine(minDistance);
        }

        public static void DijkstraAlgorithm(Dictionary<int, Node> graph, Node source)
        {
            var queue = new PriorityQueue<Node>();

            foreach (var nodeName in graph)
            {
                graph[nodeName.Key].DijkstraDistance = double.PositiveInfinity;
            }

            source.DijkstraDistance = 0.0d;
            queue.Enqueue(source);

            while (queue.Count != 0)
            {
                var currentNode = queue.Dequeue();

                if (double.IsPositiveInfinity(currentNode.DijkstraDistance))
                {
                    break;
                }

                foreach (var connection in currentNode.Connections)
                {
                    var potDistance = currentNode.DijkstraDistance + connection.Distance;
                    if (potDistance < connection.Node.DijkstraDistance)
                    {
                        connection.Node.DijkstraDistance = potDistance;
                        queue.Enqueue(connection.Node);
                    }
                }
            }
        }

        public class Node : IComparable
        {
            public Node(int id, bool isHospital)
            {
                this.Id = id;
                this.IsHospital = isHospital;
                this.Connections = new List<Connection>();
            }

            public IList<Connection> Connections { get; set; }

            public bool IsHospital { get; set; }

            public int Id { get; private set; }

            public double DijkstraDistance { get; set; }

            public int CompareTo(object obj)
            {
                if (!(obj is Node))
                {
                    return -1;
                }

                return this.DijkstraDistance.CompareTo((obj as Node).DijkstraDistance);
            }
        }

        public class Connection
        {
            public Connection(Node node, double distance)
            {
                this.Node = node;
                this.Distance = distance;
            }

            public Node Node { get; set; }

            public double Distance { get; set; }
        }

        public class PriorityQueue<T> where T : IComparable
        {
            private T[] heap;
            private int index;

            public PriorityQueue()
            {
                this.heap = new T[16];
                this.index = 1;
            }

            public int Count
            {
                get
                {
                    return this.index - 1;
                }
            }

            public void Enqueue(T element)
            {
                if (this.index >= this.heap.Length)
                {
                    this.IncreaseArray();
                }

                this.heap[this.index] = element;

                int childIndex = this.index;
                int parentIndex = childIndex / 2;
                this.index++;

                while (parentIndex >= 1 && this.heap[childIndex].CompareTo(this.heap[parentIndex]) < 0)
                {
                    T swapValue = this.heap[parentIndex];
                    this.heap[parentIndex] = this.heap[childIndex];
                    this.heap[childIndex] = swapValue;

                    childIndex = parentIndex;
                    parentIndex = childIndex / 2;
                }
            }

            public T Dequeue()
            {
                T result = this.heap[1];

                this.heap[1] = this.heap[this.Count];
                this.index--;

                int rootIndex = 1;

                while (true)
                {
                    int leftChildIndex = rootIndex * 2;
                    int rightChildIndex = (rootIndex * 2) + 1;

                    if (leftChildIndex > this.index)
                    {
                        break;
                    }

                    int minChild;
                    if (rightChildIndex > this.index)
                    {
                        minChild = leftChildIndex;
                    }
                    else
                    {
                        if (this.heap[leftChildIndex].CompareTo(this.heap[rightChildIndex]) < 0)
                        {
                            minChild = leftChildIndex;
                        }
                        else
                        {
                            minChild = rightChildIndex;
                        }
                    }

                    if (this.heap[minChild].CompareTo(this.heap[rootIndex]) < 0)
                    {
                        T swapValue = this.heap[rootIndex];
                        this.heap[rootIndex] = this.heap[minChild];
                        this.heap[minChild] = swapValue;

                        rootIndex = minChild;
                    }
                    else
                    {
                        break;
                    }
                }

                return result;
            }

            public T Peek()
            {
                return this.heap[1];
            }

            private void IncreaseArray()
            {
                var copiedHeap = new T[this.heap.Length * 2];

                for (int i = 0; i < this.heap.Length; i++)
                {
                    copiedHeap[i] = this.heap[i];
                }

                this.heap = copiedHeap;
            }
        }
    }
}
