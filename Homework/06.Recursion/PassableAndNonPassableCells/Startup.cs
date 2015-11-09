// *We are given a matrix of passable and non-passable cells.
// Write a recursive program for finding all areas of passable cells in the matrix.
namespace PassableAndNonPassableCells
{
    class Startup
    {
        static void Main()
        {
            var matrixData = new char[,]
            {
                {'p','p','n','n','n','n','n','n','n','n','n','n','n','n','n',},
                {'p','p','n','n','n','n','n','n','n','n','n','n','n','n','n',},
                {'p','p','n','n','n','n','n','n','n','n','n','n','n','n','n',},
                {'n','n','n','n','n','n','n','n','n','n','n','n','n','n','n',},
                {'n','n','n','n','n','n','p','n','n','n','n','n','n','n','n',},
                {'n','n','n','n','n','p','p','p','n','n','n','n','n','n','n',},
                {'n','n','n','n','p','p','p','p','p','n','n','n','n','n','n',},
                {'n','n','n','p','p','p','p','p','p','p','n','n','n','n','n',},
                {'n','n','n','n','p','p','p','p','p','n','n','n','n','n','n',},
                {'n','n','n','n','n','p','p','p','n','n','n','n','n','n','n',},
                {'n','n','n','n','n','n','p','n','n','n','n','n','n','n','n',},
                {'n','n','n','n','n','n','n','n','n','n','n','n','n','n','n',},
                {'n','n','n','n','n','n','n','n','n','n','n','n','n','n','n',},
                {'n','n','n','n','n','n','n','n','n','n','n','n','n','n','n',},
                {'n','n','n','n','n','n','n','n','n','n','n','n','n','n','n',},
                {'n','n','n','n','n','n','n','n','n','n','n','n','n','n','n',},
                {'n','n','n','n','n','n','n','n','n','n','n','n','n','n','n',},
                {'n','n','n','n','n','n','n','n','n','n','n','n','n','n','n',},
                {'n','n','n','n','n','n','n','n','n','n','n','n','n','n','n',}
            };

            var matrix = new Matrix(matrixData);

            foreach (var area in matrix.PassableAreas)
            {
                System.Console.WriteLine("Passable area: {0}",area);
            }
        }
    }
}
