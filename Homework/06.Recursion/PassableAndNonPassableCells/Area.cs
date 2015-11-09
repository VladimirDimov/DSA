namespace PassableAndNonPassableCells
{
    using System.Collections.Generic;

    class Area
    {
        private List<Position> positions;

        public Area()
        {
        }

        public void AddPosition(Position position)
        {
            this.positions.Add(position);
        }
    }
}
