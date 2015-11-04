using System;
namespace Labyritnth
{
    class Program
    {
        public static int[,] paths;
        static void Main()
        {
            var labyrinth = new char[6, 6]
            {
                {'0','0','0','x','0','x'},
                {'0','x','0','x','0','x'},
                {'0','*','x','0','x','0'},
                {'0','x','0','0','0','0'},
                {'0','0','0','x','x','0'},
                {'0','0','0','x','0','x'}
            };

            paths = new int[6, 6];
            var startingPoint = GetStartPosition(labyrinth);
            paths = new int[labyrinth.GetLength(0), labyrinth.GetLength(1)];
            GetPaths(labyrinth, startingPoint[0], startingPoint[1]);

            var resultingArray = GetResultingArray(labyrinth, paths);

            PrintArray(resultingArray);
        }

        private static void PrintArray(string[,] arr)
        {
            for (int row = 0; row < arr.GetLength(0); row++)
            {
                for (int col = 0; col < arr.GetLength(1); col++)
                {
                    Console.Write("{0, 3}", arr[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static string[,] GetResultingArray(char[,] labyrinth, int[,] paths)
        {
            var rows = labyrinth.GetLength(0);
            var cols = labyrinth.GetLength(1);
            var result = new string[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (labyrinth[row, col] == 'x' || labyrinth[row, col] == '*')
                    {
                        result[row, col] = labyrinth[row, col].ToString();
                    }
                    else
                    {
                        if (paths[row, col] == 0)
                        {
                            result[row, col] = "u";
                        }
                        else
                        {
                            result[row, col] = paths[row, col].ToString();
                        }
                    }
                }
            }

            return result;
        }

        private static int[] GetStartPosition(char[,] labyrinth)
        {
            for (int row = 0; row < labyrinth.GetLength(0); row++)
            {
                for (int col = 0; col < labyrinth.GetLength(1); col++)
                {
                    if (labyrinth[row, col] == '*')
                    {
                        return new int[] { row, col };
                    }
                }
            }

            throw new ArgumentException("Missing starting point!");
        }

        private static void GetPaths(char[,] labirynth, int row, int col)
        {
            CheckPathsAroundPosition(row, col, labirynth);
        }

        private static void CheckPathsAroundPosition(int row, int col, char[,] labirynth)
        {
            int currentPositionLength = paths[row, col];

            // up
            UpadteOffset(row, col, labirynth, -1, 0);

            // down
            UpadteOffset(row, col, labirynth, 1, 0);

            // left
            UpadteOffset(row, col, labirynth, 0, -1);

            // right
            UpadteOffset(row, col, labirynth, 0, 1);
        }

        private static void UpadteOffset(int row, int col, char[,] labirynth, int rowOffset, int colOffset)
        {
            var targetRow = row + rowOffset;
            var targetCol = col + colOffset;

            if (targetRow >= 0 && targetRow < labirynth.GetLength(0) &&
                targetCol >= 0 && targetCol < labirynth.GetLength(1))
            {
                if (labirynth[targetRow, targetCol] == '0' && paths[targetRow, targetCol] == 0 || paths[targetRow, targetCol] > paths[row, col] + 1)
                {
                    paths[targetRow, targetCol] = paths[row, col] + 1;
                    CheckPathsAroundPosition(targetRow, targetCol, labirynth);
                }
            }
        }
    }
}
