namespace AllPaths
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Labyrinth
    {
        private char[,] matrix;

        public Labyrinth(char[,] matrix)
        {
            this.matrix = matrix;
        }

        public char[,] Matrix
        {
            get
            {
                return this.matrix;
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
            this[position] = 'v';
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

            return true;
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
