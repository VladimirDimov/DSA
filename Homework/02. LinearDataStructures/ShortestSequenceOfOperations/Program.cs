//  We are given numbers N and M and the following operations:

//  N = N+1
//  N = N+2
//  N = N*2

//  Write a program that finds the shortest sequence of operations from the list above that starts from N and finishes in M.

//  Hint: use a queue.
//  Example: N = 5, M = 16
//  Sequence: 5 → 7 → 8 → 16
namespace ShortestSequenceOfOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private static Stack<int> shortestResult;

        static void Main()
        {
            var left = 5;
            var right = 16;
            var initialQueue = new Stack<int>();
            initialQueue.Push(left);
            GetShortestsSequence(left, right, initialQueue);

            Console.WriteLine(string.Join(", ", shortestResult.OrderBy(x => x)));
        }

        private static void GetShortestsSequence(int left, int right, Stack<int> result)
        {
            if (shortestResult != null && result.Count >= shortestResult.Count)
            {
                return;
            }
            if (result.Peek() == right)
            {
                if (shortestResult == null || result.Count < shortestResult.Count)
                {
                    shortestResult = result;
                    return;
                }
            }

            var arr1 = new Stack<int>(result);
            arr1.Push(left + 1);
            if (result.Peek() <= right)
            {
                GetShortestsSequence(left + 1, right, arr1);
            }

            var arr2 = new Stack<int>(result);
            arr2.Push(left + 2);
            if (result.Peek() <= right)
            {
                GetShortestsSequence(left + 2, right, arr2);
            }

            var arr3 = new Stack<int>(result);
            arr3.Push(left * 2);
            if (result.Peek() <= right)
            {
                GetShortestsSequence(left * 2, right, arr3);
            }
        }
    }
}
