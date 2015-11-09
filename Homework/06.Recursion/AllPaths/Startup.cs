namespace AllPaths
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Startup
    {
        private static List<Labyrinth> foundPaths = new List<Labyrinth>();

        static void Main()
        {
            var startPosition = new Position(0, 0);
            var targetPosition = new Position(5, 5);

            Console.WriteLine("Start position: {0}", startPosition);
            Console.WriteLine("Start position: {0}", targetPosition);

            var matrix = new char[6, 6]
            {
                {'0','0','0','x','0','x'},
                {'0','x','0','0','0','x'},
                {'0','0','x','x','0','0'},
                {'0','x','0','0','0','0'},
                {'0','0','0','x','x','0'},
                {'0','0','0','x','x','0'}
            };

            var matrixReloaded = new char[6, 6]
            {
                {'0','0','0','0','0','0'},
                {'0','x','0','x','0','x'},
                {'0','x','0','x','0','x'},
                {'0','x','0','x','0','x'},
                {'0','x','0','x','0','x'},
                {'0','0','0','0','0','0'}
            };

            var labirynth = new Labyrinth(matrixReloaded);

            Console.WriteLine("Labyrinth:");
            Console.WriteLine(labirynth);

            GetAllPaths(startPosition, targetPosition, labirynth);

            foreach (var path in foundPaths)
            {
                path.PrintVisited();
                Console.WriteLine();
            }
        }

        private static void GetAllPaths(Position position, Position target, Labyrinth labyrinth)
        {
            labyrinth.Visit(position);

            if (position == target)
            {
                foundPaths.Add(labyrinth);
                return;
            }

            var possibleDirections = new List<Position>
            {
                position.Left,
                position.Right,
                position.Down,
                position.Up
            };

            foreach (var direction in possibleDirections)
            {
                if (labyrinth.CanMoveTo(direction))
                {
                    var newLabyrinth = new Labyrinth(labyrinth.Matrix, new HashSet<Position>(labyrinth.Visited));
                    GetAllPaths(direction, target, newLabyrinth);
                }
            }
        }
    }
}
