namespace Graphs
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

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
