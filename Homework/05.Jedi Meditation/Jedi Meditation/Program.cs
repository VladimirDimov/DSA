namespace Jedi_Meditation
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            //Console.SetIn(new StreamReader("../../test.txt"));
            var a = Console.ReadLine();
            var jedis = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var jediCollection = new StringBuilder[3] { new StringBuilder(), new StringBuilder(), new StringBuilder() };

            int counter = 0;
            foreach (var jedi in jedis)
            {
                counter++;
                if (jedi[0] == 'm')
                {
                    jediCollection[0].Append(jedi);
                    jediCollection[0].Append(' ');
                }
                else if (jedi[0] == 'k')
                {
                    jediCollection[1].Append(jedi);
                    jediCollection[1].Append(' ');
                }
                else
                {
                    jediCollection[2].Append(jedi);
                    jediCollection[2].Append(' ');
                }
            }

            Console.WriteLine(string.Join("", jediCollection.Select(x => x.ToString())).Trim());
        }
    }
}
