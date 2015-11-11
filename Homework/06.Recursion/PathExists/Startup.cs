namespace AllPaths
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Startup
    {
        private static bool pathFound = false;

        static void Main()
        {
            var matrixA = new char[6, 6]
            {
                {'0','0','0','x','0','x'},
                {'0','x','0','0','0','x'},
                {'0','0','x','x','0','0'},
                {'0','x','0','0','0','0'},
                {'0','0','0','x','x','0'},
                {'0','0','0','x','x','0'}
            };

            var matrixB = new char[6, 6]
            {
                {'0','0','0','0','0','0'},
                {'0','x','0','x','0','x'},
                {'0','x','0','x','0','x'},
                {'0','x','0','x','x','0'},
                {'0','x','0','x','0','0'},
                {'0','0','0','x','0','0'}
            };

            var matrixC = CreateEmptyMatrix(92, 92);

            var matrix = matrixB; // Change the matrix

            var labirynth = new Labyrinth(matrix);
            var startPosition = new Position(0, 0);
            var targetPosition = new Position(matrix.GetLength(0) - 1, matrix.GetLength(1) - 1);


            PathAvailable(startPosition, targetPosition, labirynth);

            Console.WriteLine("Path available: {0}", pathFound);
        }        

        private static void PathAvailable(Position position, Position target, Labyrinth labyrinth)
        {
            if (position == target)
            {
                pathFound = true;
            }

            labyrinth.Visit(position);

            var possibleDirections = GetPossibleDirections(position, labyrinth);

            foreach (var direction in possibleDirections)
            {
                if (labyrinth.CanMoveTo(direction) && !pathFound)
                {
                   PathAvailable(direction, target, labyrinth);
                }
            }
        }

        private static List<Position> GetPossibleDirections(Position position, Labyrinth labyrinth)
        {
            var possibleDirections = new List<Position>();
            var left = position.Left;
            var right = position.Right;
            var down = position.Down;
            var up = position.Up;

            if (labyrinth.CanMoveTo(left))
            {
                possibleDirections.Add(left);
            }
            if (labyrinth.CanMoveTo(right))
            {
                possibleDirections.Add(right);
            }
            if (labyrinth.CanMoveTo(down))
            {
                possibleDirections.Add(down);
            }
            if (labyrinth.CanMoveTo(up))
            {
                possibleDirections.Add(up);
            }

            return possibleDirections;
        }

        private static char[,] CreateEmptyMatrix(int rows, int cols)
        {
            var matrix = new char[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = '0';
                }
            }

            return matrix;
        }
    }
}
