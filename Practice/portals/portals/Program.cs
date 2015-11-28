using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace portals
{
    class Program
    {
        static int maxSum = 0;
        static bool[,] globalVisisted;
        static void Main()
        {
            var reader = new StreamReader("../../input/1.txt");
            Console.SetIn(reader);

            var startPosArr = Console.ReadLine()
                .Split()
                .Select(x => int.Parse(x))
                .ToArray();

            var dimmensions = Console.ReadLine()
                .Split()
                .Select(x => int.Parse(x))
                .ToArray();

            var currow = startPosArr[0];
            var curcol = startPosArr[0];
            var rows = dimmensions[0];
            var cols = dimmensions[1];

            var matrix = new int[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                var curLine = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x != "#" ? int.Parse(x) : -1)
                    .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = curLine[col];
                }
            }

            FindMaxPath(matrix, currow, curcol, new bool[rows, cols]);

            Console.WriteLine(maxSum);
            PrintMatrix(globalVisisted);
        }

        private static void FindMaxPath(int[,] matrix, int currow, int curcol, bool[,] visited, int cursum = 0)
        {
            if (!IsInRange(matrix, currow, curcol) ||
                visited[currow, curcol] ||
                matrix[currow, curcol] == -1)
            {
                return;
            }

            var jump = matrix[currow, curcol];
            cursum += jump;
            visited[currow, curcol] = true;

            bool[,] copyOfVisited1 = GetCopyOfArray(visited);
            FindMaxPath(matrix, currow - jump, curcol, copyOfVisited1, cursum);

            bool[,] copyOfVisited2 = GetCopyOfArray(visited);
            FindMaxPath(matrix, currow + jump, curcol, copyOfVisited2, cursum);

            bool[,] copyOfVisited3 = GetCopyOfArray(visited);
            FindMaxPath(matrix, currow, curcol - jump, copyOfVisited3, cursum);

            bool[,] copyOfVisited4 = GetCopyOfArray(visited);
            FindMaxPath(matrix, currow, curcol + jump, copyOfVisited4, cursum);

            if (maxSum < cursum)
            {
                maxSum = cursum;
                globalVisisted = visited;
            }
        }

        static bool[,] GetCopyOfArray(bool[,] array)
        {
            var rows = array.GetLength(0);
            var cols = array.GetLength(1);
            var copyOfArray = new bool[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    copyOfArray[row, col] = array[row, col];
                }
            }

            return copyOfArray;
        }

        static void PrintMatrix(bool[,] arr)
        {
            for (int row = 0; row < arr.GetLength(0); row++)
            {
                for (int col = 0; col < arr.GetLength(1); col++)
                {
                    Console.Write(arr[row, col] ? 1 : 0);
                }

                Console.WriteLine();
            }
        }

        static bool AreUnpassable(int[,] matrix, int startRow, int startCol, int endRow, int endCol)
        {
            if (!IsInRange(matrix, endRow, endCol))
            {
                return false;
            }

            var rowIncrement = startRow - endRow;
            var colIncrement = startCol - endCol;

            for (int row = startRow; row <= endRow; row++)
            {
                for (int col = startCol; col <= endCol; col++)
                {
                    if (matrix[row, col] == -1)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        static bool IsInRange(int[,] matrix, int row, int col)
        {
            if (row < 0 || col < 0 || row >= matrix.GetLength(0) || col >= matrix.GetLength(1))
            {
                return false;
            }

            return true;
        }
    }
}