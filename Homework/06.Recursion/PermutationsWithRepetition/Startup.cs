namespace PermutationsWithRepetition
{
    class Startup
    {
        static void Main()
        {
            var multiset = new int[] { 1, 3, 5, 5 };

            PermutationsGenerator.Generate(multiset);
        }        
    }
}
