using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskWinsRiskLooses
{
    class Program
    {
        static List<int[]> forbiddenNumbers = new List<int[]>();
        static int minPath = 20;

        static void Main()
        {
            var reader = new StreamReader("../../input/1.txt");
            Console.SetIn(reader);

            var startPosition = Console.ReadLine()
                .ToArray()
                .Select(x => (int)char.GetNumericValue(x))
                .ToArray();

            var targetPosition = Console.ReadLine()
                .ToArray()
                .Select(x => (int)char.GetNumericValue(x))
                .ToArray();

            var numberOfForbiddenPositions = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfForbiddenPositions; i++)
            {
                forbiddenNumbers.Add(
                    Console.ReadLine()
                    .ToArray()
                    .Select(x => (int)char.GetNumericValue(x))
                    .ToArray());
            }

            var vectors = new List<int[]>
                {
                    new int[]{0, 0, 0, 0, 1 },
                    new int[]{0, 0, 0, 1, 0 },
                    new int[]{0, 0, 1, 0, 0 },
                    new int[]{0, 1, 0, 0, 0 },
                    new int[]{1, 0, 0, 0, 0 },
                    new int[]{0, 0, 0, 0, 4 },
                    new int[]{0, 0, 0, 4, 0 },
                    new int[]{0, 0, 4, 0, 0 },
                    new int[]{0, 4, 0, 0, 0 },
                    new int[]{4, 0, 0, 0, 0 },
                };

            var path = new int?[10, 10, 10, 10, 10];
            path[targetPosition[0], targetPosition[1], targetPosition[2], targetPosition[3], targetPosition[4]] = -2;
            foreach (var position in forbiddenNumbers)
            {
                SetPosition(path, position, -1);
            }
            SetPosition(path, startPosition, int.MaxValue);

            FindPath(startPosition, path, vectors);
            Console.WriteLine(minPath);
        }

        static void FindPath(int[] position, int?[,,,,] path, List<int[]> vectors, int nextPositionStepValue = 0)
        {
            if (nextPositionStepValue >= minPath)
            {
                return;
            }
            var currentPositionValue = GetPosition(path, position);
            if (currentPositionValue == null)
            {
                SetPosition(path, position, int.MaxValue);
                currentPositionValue = int.MaxValue;
            }

            if (currentPositionValue == -2)
            {
                if (minPath > nextPositionStepValue)
                {
                    minPath = nextPositionStepValue;
                }
                return;
            }
            else if (currentPositionValue <= nextPositionStepValue || 
                currentPositionValue == -1)
            {
                return;
            }

            // Setting current min steps
            // if is visitted already
            SetPosition(path, position, nextPositionStepValue);
            currentPositionValue = nextPositionStepValue;

            foreach (var vector in vectors)
            {
                var nextPosition = new int[5];
                for (int i = 0; i < 5; i++)
                {
                    nextPosition[i] = (vector[i] + position[i]) % 10;
                }

                FindPath(nextPosition, path, vectors, (int)currentPositionValue + 1);
            }
        }

        static void SetPosition(int?[,,,,] path, int[] position, int? value)
        {
            path[position[0], position[1], position[2], position[3], position[4]] = value;
        }

        static int? GetPosition(int?[,,,,] path, int[] position)
        {
            return path[position[0], position[1], position[2], position[3], position[4]];
        }
    }
}
