using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HorseMatrix
{
    class Program
    {
        static BigInteger[,] board;
        static BigInteger bestPath = ulong.MaxValue;
        static int size;
        static int[] startPosition;

        static List<int[]> movements = new List<int[]>
        {
            new int[]{-2, 1},
            new int[]{-2, -1},
            new int[]{-1, -2},
            new int[]{-1, 2},
            new int[]{1, 2},
            new int[]{1, -2},
            new int[]{2, 1},
            new int[]{2, -1},
        };

        static void Main()
        {
            //var reader = new StreamReader("../../input/3.txt");
            //Console.SetIn(reader);

            size = int.Parse(Console.ReadLine());
            board = new BigInteger[size, size];
            int[] position = new int[2];
            int[] targetPosition = new int[2];

            if (size <= 2)
            {
                Console.WriteLine("No");
                return;
            }

            for (int row = 0; row < size; row++)
            {
                var line = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int col = 0; col < size; col++)
                {
                    var val = line[col];
                    BigInteger numericVal = ulong.MaxValue;

                    if (val == "x")
                    {
                        numericVal = -1;
                    }
                    else if (val == "s")
                    {
                        position = new int[] { row, col };
                        startPosition = new int[] { row, col };
                    }
                    else if (val == "e")
                    {
                        numericVal = -2;
                        targetPosition = new int[] { row, col };
                    }

                    board[row, col] = numericVal;
                }
            }

            FindPaths(board, position);

            if (bestPath != ulong.MaxValue)
            {
                Console.WriteLine(bestPath);
            }
            else
            {
                Console.WriteLine("No");
            }
        }

        private static void FindPaths(BigInteger[,] board, int[] position, int step = 0)
        {
            if (!IsInRange(position))
            {
                return;
            }

            var val = GetPosition(position);
            if (val < 0)
            {
                if (val == -2)
                {
                    if (bestPath > step)
                    {
                        bestPath = step;
                    }
                }

                return;
            }
            else
            {
                if (val <= step)
                {
                    return;
                }
                else
                {
                    SetPosition(position, step);
                    step++;

                    foreach (var movement in movements)
                    {
                        var toPosition = new int[2];
                        toPosition[0] = position[0] + movement[0];
                        toPosition[1] = position[1] + movement[1];
                        FindPaths(board, toPosition, step);
                    }
                }
            }
        }

        private static BigInteger GetPosition(int[] position)
        {
            return board[position[0], position[1]];
        }

        private static BigInteger SetPosition(int[] position, BigInteger val)
        {
            return board[position[0], position[1]] = val;
        }

        static bool IsInRange(int[] position)
        {
            foreach (var coord in position)
            {
                if (coord < 0 || size <= coord)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
