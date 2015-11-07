namespace LargestAreaOfEmptyCells
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class MatrixSet
    {
        private char[,] matrix;
        private bool[,] visited;

        public MatrixSet(char[,] matrix)
        {
            this.matrix = matrix;
            this.visited = (bool[,])Array.CreateInstance(typeof(bool), this.matrix.GetLength(0), this.matrix.GetLength(0));
        }

        public char[,] Matrix
        {
            get
            {
                return this.matrix;
            }
        }

        public int Rows
        {
            get { return this.matrix.GetLength(0); }
        }

        public int Cols
        {
            get { return this.matrix.GetLength(1); }
        }

        public bool[,] Visited
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
            this.visited[position.Row, position.Col] = true;
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

            if (this[position] == '1' || this.IsVisisted(position))
            {
                return false;
            }

            return true;
        }

        public bool IsVisisted(Position position)
        {
            return this.visited[position.Row, position.Col];
        }

        public void Print()
        {
            for (int row = 0; row < this.matrix.GetLength(0); row++)
            {
                for (int col = 0; col < this.matrix.GetLength(1); col++)
                {
                    Console.Write("{0, 3}", this.matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
