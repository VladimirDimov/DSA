namespace Services
{
    using System.Collections.Generic;

    public static class OddNumberOccurencesExtractor
    {
        public static ICollection<T> Apply<T>(T[] input)
        {
            var result = new List<T>();
            var uniqueOccurences = OccurencesCounter.GetOccurences<T>(input);

            foreach (var keyValue in uniqueOccurences)
            {
                if (keyValue.Value % 2 != 0)
                {
                    result.Add(keyValue.Key);
                }
            }

            return result;
        }
    }
}
