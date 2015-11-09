namespace AllPaths
{
    using System;

    class Position : IComparable
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

        public int CompareTo(object obj)
        {
            var otherPosition = obj as Position;

            if (otherPosition == null)
            {
                throw new ArgumentException("Invalid other position!");
            }

            if (this.Row != otherPosition.Row)
            {
                return this.Row - otherPosition.Row;
            }
            else
            {
                return this.Col - otherPosition.Col;
            }
        }

        // We override this operators in order to be able to check later in list of visited 
        // positions if the current position is in the list
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

        public override int GetHashCode()
        {
            var hash = this.Row.GetHashCode() << 16 | this.Col.GetHashCode();
            return hash;
        }

        public override string ToString()
        {
            return string.Format("[{0}, {1}]", this.Row, this.Col);
        }
    }
}
