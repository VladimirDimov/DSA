namespace GirlsGoneWild
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            //var reader = new StreamReader("../../input/1.txt");
            //Console.SetIn(reader);

            var numberOfShirts = int.Parse(Console.ReadLine());
            var scirts = Console.ReadLine().ToCharArray().OrderBy(x => x).ToArray();
            int girlsNumber = int.Parse(Console.ReadLine());

            if (numberOfShirts < girlsNumber || scirts.Length < girlsNumber)
            {
                Console.WriteLine(0);
                return;
            }

            int[] shirts = new int[numberOfShirts];

            for (int i = 0; i < numberOfShirts; i++)
            {
                shirts[i] = i;
            }

            int n = numberOfShirts;
            var shirtsCombinations = new List<int[]>();
            GenerateCombinationsNoRepetitions(shirts, n, girlsNumber, new int[girlsNumber], shirtsCombinations);

            var scirtsCombinations = new List<char[]>();
            GenerateCombinationsOfScirts(scirts, scirts.Length, girlsNumber, new int[girlsNumber], scirtsCombinations);

            var toPrint = new SortedSet<string>();
            for (int sh = 0; sh < shirtsCombinations.Count; sh++)
            {
                for (int sc = 0; sc < scirtsCombinations.Count; sc++)
                {
                    CombinateBetweenGirls(shirtsCombinations[sh], scirtsCombinations[sc], toPrint);
                }
            }

            Console.WriteLine(toPrint.Count);
            Console.WriteLine(string.Join(Environment.NewLine, toPrint));
        }

        /*shirts - 0, 1...*/
        private static void CombinateBetweenGirls(int[] shirts, char[] scirts, SortedSet<string> toPrint)
        {
            var scirtsPermutations = new List<char[]>();
            PermuteRep(scirts, scirts.Length, scirtsPermutations);

            foreach (var permutation in scirtsPermutations)
            {
                var currentSolution = new string[shirts.Length];
                for (int i = 0; i < shirts.Length; i++)
                {
                    currentSolution[i] = string.Format("{0}{1}", shirts[i], permutation[i]);
                }
                toPrint.Add(string.Join("-", currentSolution));
            }
        }

        static void GenerateCombinationsNoRepetitions(int[] objects, int n, int k, int[] currentIndexPositions, List<int[]> result, int index = 0, int start = 0)
        {
            if (index >= k)
            {
                result.Add(currentIndexPositions.Select(x => objects[x]).ToArray());
            }
            else
            {
                for (int i = start; i < n; i++)
                {
                    currentIndexPositions[index] = i;
                    GenerateCombinationsNoRepetitions(objects, n, k, currentIndexPositions, result, index + 1, i + 1);
                }
            }
        }

        static void GenerateCombinationsOfScirts(char[] objects, int n, int k, int[] currentIndexPositions, List<char[]> result, int index = 0, int start = 0)
        {
            if (index >= k)
            {
                var currentCombination = currentIndexPositions.Select(x => objects[x]).ToArray();
                if (result.Count == 0 || !AreEqualArrays(currentCombination, result[result.Count - 1]))
                {
                    result.Add(currentCombination);
                }
            }
            else
            {
                var lastObj = '#';
                for (int i = start; i < n; i++)
                {
                    var currentObj = objects[i];

                    if (currentObj == lastObj)
                    {
                        continue;
                    }

                    lastObj = currentObj;
                    currentIndexPositions[index] = i;
                    GenerateCombinationsOfScirts(objects, n, k, currentIndexPositions, result, index + 1, i + 1);
                }
            }
        }

        static bool AreEqualArrays<T>(T[] arr1, T[] arr2)
        {
            for (int i = 0; i < arr1.Length; i++)
            {
                if (!arr1[i].Equals(arr2[i]))
                {
                    return false;
                }
            }

            return true;
        }

        static void PermuteRep<T>(T[] inputArray, int n, List<T[]> result, int start = 0)
        {
            var arrayToAdd = new T[n];
            Array.Copy(inputArray, arrayToAdd, n);
            result.Add(arrayToAdd);

            for (int left = n - 2; left >= start; left--)
            {
                for (int right = left + 1; right < n; right++)
                {
                    if (!inputArray[left].Equals(inputArray[right]))
                    {
                        Swap(ref inputArray[left], ref inputArray[right]);
                        PermuteRep(inputArray, n, result, left + 1);
                    }
                }

                // Undo all modifications done by the
                // previous recursive calls and swaps
                var firstElement = inputArray[left];
                for (int i = left; i < n - 1; i++)
                {
                    inputArray[i] = inputArray[i + 1];
                }
                inputArray[n - 1] = firstElement;
            }
        }

        static void Swap<T>(ref T first, ref T second)
        {
            T oldFirst = first;
            first = second;
            second = oldFirst;
        }
    }
}
