namespace PassableAndNonPassableCells
{
    using System.Collections.Generic;

    class Area
    {
        private List<Position> positions;

        public Area()
        {
            this.positions = new List<Position>();
        }

        public void AddPosition(Position position)
        {
            this.positions.Add(position);
        }

        public override string ToString()
        {
            return string.Join(", ", this.positions);
        }
    }
}
