namespace AllPaths
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Labyrinth
    {
        private char[,] matrix;
        private HashSet<Position> visited;

        public Labyrinth(char[,] matrix)
        {
            this.CopyMatrix(matrix);
            this.visited = new HashSet<Position>();
        }

        public Labyrinth(char[,] matrix, HashSet<Position> visited)
        {
            this.CopyMatrix(matrix);
            this.visited = visited;
        }

        public char[,] Matrix
        {
            get
            {
                return this.matrix;
            }
        }

        public HashSet<Position> Visited
        {
            get
            {
                return this.visited;
            }
        }

        public char this[Position position]
        {
            get
            {
                return this.matrix[position.Row, position.Col];
            }

            private set
            {
                this.matrix[position.Row, position.Col] = value;
            }
        }

        public void Visit(Position position)
        {
            this.visited.Add(position);
        }

        public bool CanMoveTo(Position position)
        {
            if (position.Row < 0 || position.Row >= this.matrix.GetLength(0))
            {
                return false;
            }

            if (position.Col < 0 || position.Col >= this.matrix.GetLength(1))
            {
                return false;
            }

            if (this[position] != '0')
            {
                return false;
            }

            if (this.IsVisited(position))
            {
                return false;
            }

            return true;
        }

        public void PrintVisited()
        {
            foreach (var position in this.visited)
            {
                this[position] = 'v';
            }

            for (int row = 0; row < this.matrix.GetLength(0); row++)
            {
                for (int col = 0; col < this.matrix.GetLength(1); col++)
                {
                    Console.Write("{0, 3}", this.matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        private bool IsVisited(Position position)
        {
            var isVisited = this.visited.Contains<Position>(position);
            return isVisited;
        }

        private void CopyMatrix(char[,] matrix)
        {
            this.matrix = new char[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    this.matrix[i, j] = matrix[i, j];
                }
            }
        }
    }
}
