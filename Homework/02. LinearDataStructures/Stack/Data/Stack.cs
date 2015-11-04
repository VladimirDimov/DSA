using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack.Data
{
    public class Stack<T>
    {
        private T[] stack;
        private int index;

        public Stack(int size = 16)
        {
            this.stack = new T[size];
            this.index = 0;
        }

        public int Count()
        {
            return this.index;
        }

        public T Peek()
        {
            if (this.Count() == 0)
            {
                throw new InvalidOperationException("The stack is empty!");
            }

            return this.stack[index];
        }

        public T Pop()
        {
            if (this.Count() == 0)
            {
                throw new InvalidOperationException("The stack is empty!");
            }

            var returnValue = this.stack[index - 1];

            if (this.index > 0)
            {
                this.index--;
            }

            return returnValue;
        }

        public void Push(T value)
        {
            UpdateSize();
            this.stack[index++] = value;
        }

        private void UpdateSize()
        {
            if (this.index == this.stack.Length)
            {
                var doubleStack = new T[this.stack.Length * 2];

                for (int i = 0; i < this.stack.Length; i++)
                {
                    doubleStack[i] = this.stack[i];
                }

                this.stack = doubleStack;
            }
        }
    }
}
