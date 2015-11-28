using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GirlsGoneWild
{
    class Program
    {
        static void Main()
        {
            //Console.SetIn(new StreamReader("../../input/test.004.in.txt"));

            var shirtsNumber = int.Parse(Console.ReadLine());
            var skirts = Console.ReadLine();
            var girlsNumber = int.Parse(Console.ReadLine());

            var skirtsVariations = new List<List<char>>();
            CombinateSkirts<char>(girlsNumber, skirts.ToCharArray().ToList(), new List<char>(), skirtsVariations);

            var shirtsVariations = new List<List<int>>();
            CombinateSkirts(girlsNumber, shirtsNumber, new List<int>(), shirtsVariations);

            var charsAndInts = CombinateTwoLists(skirtsVariations, shirtsVariations);

            var result = new List<SortedSet<string>>();
            foreach (var values in charsAndInts)
            {
                CombinateBetweenGirls(values, new SortedSet<string>(), result, new HashSet<int>(), new HashSet<int>());
            }

            var output = new SortedSet<string>();

            foreach (var item in result)
            {
                output.Add(string.Join("-", item));
            }

            //Console.WriteLine(string.Join(Environment.NewLine, result.Select(x => string.Join("", x))));

            Console.WriteLine(output.Count);
            Console.WriteLine(string.Join(Environment.NewLine, output));
        }

        public static void CombinateSkirts<T>(int k, List<T> set, List<T> combination, List<List<T>> result, int left = 0)
        {
            if (combination.Count == k)
            {
                result.Add(combination);
                return;
            }

            for (int i = left; i < set.Count; i++)
            {
                var currentCombination = new List<T>(combination);
                currentCombination.Add(set[i]);
                CombinateSkirts(k, set, currentCombination, result, i + 1);
            }
        }

        public static void CombinateSkirts(int k, int sequenceLength, List<int> combination, List<List<int>> result, int left = 0)
        {
            if (combination.Count == k)
            {
                result.Add(combination);
                return;
            }

            for (int i = left; i < sequenceLength; i++)
            {
                var currentCombination = new List<int>(combination);
                currentCombination.Add(i);
                CombinateSkirts(k, sequenceLength, currentCombination, result, i + 1);
            }
        }

        static void CombinateBetweenGirls(string[] values, SortedSet<string> currentCombo, List<SortedSet<string>> result, HashSet<int> passedIndexesI, HashSet<int> passedIndexesJ, int leftI = 0)
        {
            var girlsNumber = values[0].Length;

            if (currentCombo.Count == girlsNumber)
            {
                result.Add(currentCombo);
                return;
            }

            for (int i = 0; i < girlsNumber; i++)
            {
                if (passedIndexesI.Contains(i))
                {
                    continue;
                }

                for (int j = i; j < girlsNumber; j++)
                {
                    if (passedIndexesJ.Contains(j))
                    {
                        continue;
                    }

                    var newPassedIndexesI = new HashSet<int>(passedIndexesI);
                    var newPassedIndexesJ = new HashSet<int>(passedIndexesJ);
                    newPassedIndexesI.Add(i);
                    newPassedIndexesJ.Add(j);

                    var newCombo = new SortedSet<string>(currentCombo);
                    newCombo.Add(values[1][j].ToString() + values[0][i].ToString());
                    
                    CombinateBetweenGirls(
                        values,
                        newCombo,
                        result,
                        newPassedIndexesI,
                        newPassedIndexesJ);
                }
            }
        }

        static List<string[]> CombinateTwoLists(List<List<char>> chars, List<List<int>> ints)
        {
            var result = new List<string[]>();

            for (int i = 0; i < chars.Count; i++)
            {
                for (int j = 0; j < ints.Count; j++)
                {
                    result.Add(new string[] { string.Join("", chars[i]), string.Join("", ints[j]) });
                }
            }

            return result;
        }
    }
}
