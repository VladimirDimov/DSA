using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    class Program
    {
        static void Main()
        {
            var test = new HashTable<int, string>();
            test.Add(1, "a");
            test.Add(2, "b");
            test.Add(1, "c");
            test.Add(2, "d");
        }
    }
}
