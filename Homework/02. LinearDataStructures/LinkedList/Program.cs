namespace LinkedList
{
    using LinkedList.Data;
    using System;

    class Program
    {
        static void Main()
        {
            var linkedList = new LinkedList<int>();

            var firstListItem = new ListItem<int>();
            firstListItem.Value = 1;

            linkedList.FirstElement = firstListItem;
        }
    }
}
