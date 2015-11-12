#Combinatorics

## Combinations with repetitions
####input: 
	n = 3 
	k = 2 
	{A, B, C}

#### output:
	A A
	A B
	A C
	B B
	B C
	C C

####Code

    class Program
    {
        static void Main()
        {
            int n = 3;
            int k = 2;

            string[] objects = new string[3] { "A", "B", "C" };

            int[] arr = new int[k];

            List<string[]> result = new List<string[]>();
            GenerateCombinationsNoRepetitions(n, k, objects, new int[k], result);
        }

        static void GenerateCombinationsNoRepetitions<T>(int n, int k, T[] objects, int[] indexPositions, List<T[]> result, int index = 0, int start = 0)
        {
            if (index >= k)
            {
                var output = new T[k];
                result.Add(indexPositions.Select(x => objects[x]).ToArray());
            }
            else
            {
                for (int i = start; i < n; i++)
                {
                    indexPositions[index] = i;
                    GenerateCombinationsNoRepetitions(n, k, objects, indexPositions, result, index + 1, i);
                }
            }
        }
    }

##Combinations with no repetitions
####input:
	n = 5; k = 3; arr =  "A", "B", "C", "D", "E";
####output:
    A B C
    A B D
    A B E
    A C D
    A C E
    A D E
    B C D
    B C E
    B D E
    C D E

####Code:
    class Program
    {
        static void Main()
        {
            int n = 5;
            int k = 3;

            string[] objects = new string[] { "A", "B", "C", "D", "E" };

            List<string[]> result = new List<string[]>();
            GenerateCombinationsNoRepetitions(objects, n, k, new int[k], result);
        }

        static void GenerateCombinationsNoRepetitions(string[] objects, int n, int k, int[] currentIndexPositions, List<string[]> result, int index = 0, int start = 0)
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
    }

##Permutations with repetitions
####input:
	3, 5, 1, 5
####output:
    1 3 5 5
    1 5 3 5
    1 5 5 3
    3 1 5 5
    3 5 1 5
    3 5 5 1
    5 1 3 5
    5 1 5 3
    5 3 1 5
    5 3 5 1
    5 5 1 3
    5 5 3 1
####Code:
    class Program
    {
        static void Main()
        {
            var arr = new int[] { 3, 5, 1, 5 };
            Array.Sort(arr);

            List<int[]> result = new List<int[]>();
            PermuteRep(arr, arr.Length, result);
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

##Permutations with no repetitions
####input:
	A, B, C
####output:
    A B C
    A C B
    B A C
    B C A
    C B A
    C A B
####Code:
    class Program
    {
        static void Main()
        {
            string[] arr = { "A", "B", "C" };

            List<string[]> result = new List<string[]>();
            GeneratePermutations(arr, result);
        }

        static void GeneratePermutations<T>(T[] arr, List<T[]> result, int k = 0)
        {
            if (k >= arr.Length)
            {
                var arrToAdd = new T[arr.Length];
                Array.Copy(arr, arrToAdd, arr.Length);
                result.Add(arrToAdd);
            }
            else
            {
                GeneratePermutations(arr, result, k + 1);
                for (int i = k + 1; i < arr.Length; i++)
                {
                    Swap(ref arr[k], ref arr[i]);
                    GeneratePermutations(arr, result, k + 1);
                    Swap(ref arr[k], ref arr[i]);
                }
            }
        }

        static void Swap<T>(ref T first, ref T second)
        {
            T oldFirst = first;
            first = second;
            second = oldFirst;
        }
    }

##Variations with no repetitions
####input:
	n = 3; k = 2; array = "A", "B", "C"
####output:
    A B
    A C
    B A
    B C
    C A
    C B
####Code:
    class Program
    {

        static void Main()
        {
            int n = 3;
            int k = 2;

            string[] objects = new string[] { "A", "B", "C" };
            bool[] used = new bool[n];

            var result = new List<string[]>();
            GenerateVariationsNoRepetitions(objects, n, k, new int[k], new bool[n], result);
        }

        static void GenerateVariationsNoRepetitions(string[] objects, int n, int k, int[] currentVariation, bool[] used, List<string[]> result, int index = 0)
        {
            if (index >= k)
            {
                result.Add(currentVariation.Select(x => objects[x]).ToArray());
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    if (!used[i])
                    {
                        used[i] = true;
                        currentVariation[index] = i;
                        GenerateVariationsNoRepetitions(objects, n, k, currentVariation, used, result, index + 1);
                        used[i] = false;
                    }
                }
            }
        }
    }

## Variations with repetitions
####input:
	n=3; k=2; array = "A", "B", "C";
####output:
	A A
	A B
	A C
	B A
	B B
	B C
	C A
	C B
	C C
####Code:
    class Program
    {
        static void Main()
        {
            int n = 3;
            int k = 2;

            string[] objects = new string[] { "A", "B", "C" };

            List<string[]> result = new List<string[]>();
            GenerateVariationsWithRepetitions(n, k, objects, new int[k], result);
        }

        static void GenerateVariationsWithRepetitions<T>(int n, int k, T[] objects, int[] currentVariation, List<T[]> result, int index = 0)
        {
            if (index >= k)
            {
                result.Add(currentVariation.Select(x => objects[x]).ToArray());
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    currentVariation[index] = i;
                    GenerateVariationsWithRepetitions(n, k, objects, currentVariation, result, index + 1);
                }
            }
        }
    }
