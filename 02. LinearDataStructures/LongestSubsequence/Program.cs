namespace LongestSubsequence
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            var sequence = new int[] { 1, 1, 2, 4, 4, 4, 5, 1, 3, 3, 1, 1 };
            var longestSubSequence = GetLongestSubsequence(sequence);

            Console.WriteLine(string.Join(", ", longestSubSequence));
        }

        private static List<int> GetLongestSubsequence(int[] sequence)
        {
            var allSubsequences = new List<List<int>>();
            var currentSubSeq = new List<int>();
            var longestSubSeq = new List<int>();
            int? prevNumber = null;

            for (int i = 0; i < sequence.Length; i++)
            {
                var currentNum = sequence[i];

                if (currentNum == prevNumber || prevNumber == null)
                {
                    currentSubSeq.Add(currentNum);
                }
                else
                {
                    if (longestSubSeq.Count < currentSubSeq.Count)
                    {
                        longestSubSeq = new List<int>(currentSubSeq);
                    }

                    currentSubSeq = new List<int>() { currentNum };
                }

                prevNumber = currentNum;
            }

            // Update the longest subsequence in case it's at the end of the input sequence
            if (longestSubSeq.Count < currentSubSeq.Count)
            {
                longestSubSeq = new List<int>(currentSubSeq);
            }

            return longestSubSeq;
        }
    }
}
