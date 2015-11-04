namespace Services
{
    using System.Collections;
    using System.Collections.Generic;

    public class OccurencesCounter
    {
        public static Dictionary<T, int> GetOccurences<T>(ICollection<T> collection)
        {
            var valuesOccurences = new Dictionary<T, int>();

            foreach (var val in collection)
            {
                if (valuesOccurences.ContainsKey(val))
                {
                    valuesOccurences[val]++;
                }
                else
                {
                    valuesOccurences[val] = 1;
                }
            }

            return valuesOccurences;
        }
    }
}
