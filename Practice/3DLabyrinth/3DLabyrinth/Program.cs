namespace _3DLabyrinth
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        static List<int[]> directions = new List<int[]>
        {
            new int[] {0,1,0},
            new int[] {0,0,1},
            new int[] {0,-1,0},
            new int[] {0,0,-1}
        };
        static int bestSteps = int.MaxValue;
        static int L, R, C;
        static int[, ,] bestByIndex;

        static void Main()
        {
            //var reader = new StreamReader("../../input/1.txt");
            //Console.SetIn(reader);

            var position = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();

            var lrc = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();

            L = lrc[0]; R = lrc[1]; C = lrc[2];

            var cube = new char[lrc[0], lrc[1], lrc[2]];
            for (int l = 0; l < L; l++)
            {
                for (int r = 0; r < R; r++)
                {
                    var line = Console.ReadLine();

                    for (int c = 0; c < C; c++)
                    {
                        cube[l, r, c] = line[c];
                    }
                }
            }

            bestByIndex = new int[L, R, C];
            InitializeBestByIndex(bestByIndex);

            FindShortestWay(cube, position);
            Console.WriteLine(bestSteps);
        }

        // L R C
        static void FindShortestWay(char[, ,] cube, int[] position, int steps = 0)
        {
            if (!IsInHorizontalRange(position))
            {
                return;
            }

            if (position[0] < 0 || position[0] >= L)
            {
                if (bestSteps > steps)
                {
                    bestSteps = steps;
                }

                return;
            }

            if (bestByIndex[position[0], position[1], position[2]] <= steps)
            {
                return;
            }
            else
            {
                bestByIndex[position[0], position[1], position[2]] = steps;
            }

            var positionValue = GetPosition(cube, position);

            if (positionValue == '#')
            {
                return;
            }
            else if (positionValue == '.')
            {
                foreach (var direction in directions)
                {
                    var toPosition = Offset(position, direction);
                    FindShortestWay(cube, toPosition, steps + 1);
                }

                return;
            }
            else if (positionValue == 'U')
            {
                var toPosition = Offset(position, new int[] { 1, 0, 0 });
                FindShortestWay(cube, toPosition, steps + 1);
            }
            else if (positionValue == 'D')
            {
                var toPosition = Offset(position, new int[] { -1, 0, 0 });
                FindShortestWay(cube, toPosition, steps + 1);
            }
            else
            {
                throw new ArgumentException(string.Format("Invalid cube char value: {0}!", positionValue));
            }
        }

        static char GetPosition(char[, ,] cube, int[] position)
        {
            return cube[position[0], position[1], position[2]];
        }

        static int[] Offset(int[] position, int[] direction)
        {
            var offset = new int[3];
            for (int i = 0; i < 3; i++)
            {
                offset[i] = position[i] + direction[i];
            }

            return offset;
        }

        static bool[, ,] CopyArray(bool[, ,] arr)
        {
            var copy = new bool[L, R, C];

            for (int l = 0; l < L; l++)
            {
                for (int r = 0; r < R; r++)
                {
                    for (int c = 0; c < C; c++)
                    {
                        copy[l, r, c] = arr[l, r, c];
                    }
                }
            }

            return copy;
        }

        static bool IsInHorizontalRange(int[] position)
        {
            if (position[1] < 0 || position[1] >= R)
            {
                return false;
            }

            if (position[2] < 0 || position[2] >= C)
            {
                return false;
            }

            return true;
        }

        static void InitializeBestByIndex(int[, ,] arr)
        {
            for (int l = 0; l < L; l++)
            {
                for (int r = 0; r < R; r++)
                {
                    for (int c = 0; c < C; c++)
                    {
                        arr[l, r, c] = int.MaxValue;
                    }
                }
            }
        }
    }
}
