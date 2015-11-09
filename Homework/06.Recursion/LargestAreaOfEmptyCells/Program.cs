using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LargestAreaOfEmptyCells
{
    class Program
    {
        static void Main()
        {
            int maxNumberOfLinkedZeroes = 0;

            var theMatrix = new char[,]
            {
                {'0','0','1','1','1','1','1','1','1','1','1','1','1','1','1',},
                {'0','0','1','1','1','1','1','1','1','1','1','1','1','1','1',},
                {'0','0','1','1','1','1','1','1','1','1','1','1','1','1','1',},
                {'1','1','1','1','1','1','1','1','1','1','1','1','1','1','1',},
                {'1','1','1','1','1','1','0','1','1','1','1','1','1','1','1',},
                {'1','1','1','1','1','0','0','0','1','1','1','1','1','1','1',},
                {'1','1','1','1','0','0','0','0','0','1','1','1','1','1','1',},
                {'1','1','1','0','0','0','0','0','0','0','1','1','1','1','1',},
                {'1','1','1','1','0','0','0','0','0','1','1','1','1','1','1',},
                {'1','1','1','1','1','0','0','0','1','1','1','1','1','1','1',},
                {'1','1','1','1','1','1','0','1','1','1','1','1','1','1','1',},
                {'1','1','1','1','1','1','1','1','1','1','1','1','1','1','1',},
                {'1','1','1','1','1','1','1','1','1','1','1','1','1','1','1',},
                {'1','1','1','1','1','1','1','1','1','1','1','1','1','1','1',},
                {'1','1','1','1','1','1','1','1','1','1','1','1','1','1','1',},
                {'1','1','1','1','1','1','1','1','1','1','1','1','1','1','1',},
                {'1','1','1','1','1','1','1','1','1','1','1','1','1','1','1',},
                {'1','1','1','1','1','1','1','1','1','1','1','1','1','1','1',},
                {'1','1','1','1','1','1','1','1','1','1','1','1','1','1','1',}
            };

            var matrixSet = new MatrixSet(theMatrix);

            for (int row = 0; row < matrixSet.Rows; row++)
            {
                for (int col = 0; col < matrixSet.Cols; col++)
                {
                    var currentPosition = new Position(row, col);

                    if (matrixSet[currentPosition] == '0' && !matrixSet.IsVisisted(currentPosition))
                    {
                        var numberOfLinkedZeroes = GetLinkedZeroes(currentPosition, matrixSet);

                        if (maxNumberOfLinkedZeroes < numberOfLinkedZeroes)
                        {
                            maxNumberOfLinkedZeroes = numberOfLinkedZeroes;
                        }
                    }
                }
            }

            Console.WriteLine("Largest area of empty cells: {0}", maxNumberOfLinkedZeroes);
        }

        private static int GetLinkedZeroes(Position position, MatrixSet matrixSet, int counter = 0)
        {
            counter++;
            matrixSet.Visit(position);

            var possibleDirections = GetPossibleDirections(position, matrixSet);

            foreach (var direction in possibleDirections)
            {
                if (!matrixSet.IsVisisted(direction))
                {
                    counter += GetLinkedZeroes(direction, matrixSet);
                }
            }

            return counter;
        }

        private static List<Position> GetPossibleDirections(Position position, MatrixSet matrixSet)
        {
            var possibleDirections = new List<Position>();
            var left = position.Left;
            var right = position.Right;
            var down = position.Down;
            var up = position.Up;

            if (matrixSet.CanMoveTo(left))
            {
                possibleDirections.Add(left);
            }
            if (matrixSet.CanMoveTo(right))
            {
                possibleDirections.Add(right);
            }
            if (matrixSet.CanMoveTo(down))
            {
                possibleDirections.Add(down);
            }
            if (matrixSet.CanMoveTo(up))
            {
                possibleDirections.Add(up);
            }

            return possibleDirections;
        }

        private static void PrintArray<T>(T[,] arr)
        {
            for (int row = 0; row < arr.GetLength(0); row++)
            {
                for (int col = 0; col < arr.GetLength(1); col++)
                {
                    Console.Write("{0, 5}", arr[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
