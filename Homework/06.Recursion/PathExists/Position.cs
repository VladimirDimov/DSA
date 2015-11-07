namespace AllPaths
{
    using System;

    class Position
    {
        public Position(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row { get; set; }

        public int Col { get; set; }

        public Position Left
        {
            get { return new Position(this.Row, this.Col - 1); }
        }

        public Position Right
        {
            get { return new Position(this.Row, this.Col + 1); }
        }

        public Position Down
        {
            get { return new Position(this.Row + 1, this.Col); }
        }

        public Position Up
        {
            get { return new Position(this.Row - 1, this.Col); }
        }

        public static bool operator ==(Position first, Position second)
        {
            return first.Row == second.Row && first.Col == second.Col;
        }

        public static bool operator !=(Position first, Position second)
        {
            return !(first == second);
        }

        public override bool Equals(object obj)
        {
            var otherPosition = obj as Position;
            return (this.Row == otherPosition.Row) && (this.Col == otherPosition.Col);
        }
    }
}
