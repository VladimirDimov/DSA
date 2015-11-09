using System.Collections.Generic;
namespace PassableAndNonPassableCells
{
    class Matrix
    {
        char[,] matrix;
        bool[,] visitedCells;
        List<Area> passableAreas;


        public Matrix(char[,] matrix)
        {
            this.matrix = matrix;
            this.visitedCells = new bool[matrix.GetLength(0), matrix.GetLength(1)];
            this.passableAreas = new List<Area>();

            this.GeneratePassableAreas();
        }

        public IList<Area> PassableAreas
        {
            get { return this.passableAreas; }
        }

        private void GeneratePassableAreas()
        {
            for (int row = 0; row < this.matrix.GetLength(0); row++)
            {
                for (int col = 0; col < this.matrix.GetLength(1); col++)
                {
                    if (!IsVisited(row, col) && this.matrix[row, col] == 'p')
                    {
                        var areaToAdd = new Area();
                        this.passableAreas.Add(areaToAdd);
                        GetPassablePositions(row, col, areaToAdd);
                    }
                }
            }
        }

        private void GetPassablePositions(int row, int col, Area result)
        {
            var currentCell = this.matrix[row, col];

            if (currentCell == 'p')
            {
                this.visitedCells[row, col] = true;
                result.AddPosition(new Position(row, col));
            }
            else
            {
                return;
            }

            var up = new { Row = row - 1, Col = col };
            var down = new { Row = row + 1, Col = col };
            var left = new { Row = row, Col = col - 1 };
            var right = new { Row = row, Col = col + 1 };

            if (IsInRange(up.Row, up.Col) && !IsVisited(up.Row, up.Col))
            {
                GetPassablePositions(up.Row, up.Col, result);
            }

            if (IsInRange(down.Row, down.Col) && !IsVisited(down.Row, down.Col))
            {
                GetPassablePositions(down.Row, down.Col, result);
            }

            if (IsInRange(left.Row, left.Col) && !IsVisited(left.Row, left.Col))
            {
                GetPassablePositions(left.Row, left.Col, result);
            }

            if (IsInRange(right.Row, right.Col) && !IsVisited(right.Row, right.Col))
            {
                GetPassablePositions(right.Row, right.Col, result);
            }
        }

        private bool IsInRange(int row, int col)
        {
            if (row < 0 || this.matrix.GetLength(0) - 1 < row)
            {
                return false;
            }

            if (col < 0 || this.matrix.GetLength(1) - 1 < col)
            {
                return false;
            }

            return true;
        }

        private bool IsVisited(int row, int col)
        {
            return this.visitedCells[row, col];
        }
    }
}
