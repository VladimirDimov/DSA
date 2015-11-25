namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SelectionSorter<T> : ISorter<T>
        where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            //pos_min is short for position of min
            int pos_min;
            T temp;

            for (int i = 0; i < collection.Count - 1; i++)
            {
                pos_min = i;//set pos_min to the current index of array

                for (int j = i + 1; j < collection.Count; j++)
                {
                    if (collection[j].CompareTo(collection[pos_min]) < 0)
                    {
                        //pos_min will keep track of the index that min is in, this is needed when a swap happens
                        pos_min = j;
                    }
                }

                //if pos_min no longer equals i than a smaller value must have been found, so a swap must occur
                if (pos_min != i)
                {
                    temp = collection[i];
                    collection[i] = collection[pos_min];
                    collection[pos_min] = temp;
                }
            }
        }
    }
}
