namespace Graphs
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        static void Main()
        {
            var reader = new StreamReader("../../input/2.txt");
            Console.SetIn(reader);

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

                if (minDist > dist)
                {
                    minDist = dist;
                }
            }

            Console.WriteLine(minDist);
        }
    }
}
