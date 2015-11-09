namespace PassableAndNonPassableCells
{
    public class Position
    {
        public Position(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row { get; set; }

        public int Col { get; set; }

        public override string ToString()
        {
            return string.Format("[{0}, {1}]", this.Row, this.Col);
        }
    }
}
