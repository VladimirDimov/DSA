namespace Queue.Data
{
    public class LinkedList<T>
    {
        private int numberOfItems;

        public LinkedList()
        {
            this.numberOfItems = 0;
        }

        public ListItem<T> FirstElement { get; set; }

        public ListItem<T> LastElement { get; set; }

        public int Length
        {
            get
            {
                return this.numberOfItems;
            }
        }

        public void AddFirst(ListItem<T> item)
        {
            item.NextItem = this.FirstElement;
            this.FirstElement = item;
        }

        public void AddLast(ListItem<T> item)
        {
            if (this.LastElement != null)
            {
                this.LastElement.NextItem = item;
                this.LastElement = item;
            }
            else
            {
                this.LastElement = item;
                this.FirstElement = item;
            }

            this.numberOfItems++;
        }

        public void RemoveFirst()
        {
            var elementToBeFirst = this.FirstElement.NextItem;
            this.FirstElement = elementToBeFirst;
            numberOfItems--;
        }
    }
}
