namespace SortingHomework.Searching
{
    using System;
    using System.Collections.Generic;

    public static class BinarySearcher<T>
        where T : IComparable<T>
    {
        public static bool BinarySearchRecursive(IList<T> input, T key, int min, int max)
        {
            if (min > max)
            {
                return false;
            }
            else
            {
                int mid = (min + max) / 2;
                if (key.Equals(input[mid]))
                {
                    return true;
                }
                else if (key.CompareTo(input[mid]) < 0)
                {
                    return BinarySearchRecursive(input, key, min, mid - 1);
                }
                else
                {
                    return BinarySearchRecursive(input, key, mid + 1, max);
                }
            }
        }
    }
}
