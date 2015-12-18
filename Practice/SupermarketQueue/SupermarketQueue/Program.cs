namespace SupermarketQueue
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using Wintellect.PowerCollections;

    class Program
    {
        const string OkMessage = "OK";
        const string ErrorMessage = "Error";

        static BigList<string> queue = new BigList<string>();
        static Dictionary<string, int> namesEncounters = new Dictionary<string, int>();

        static void Main()
        {
            //var reader = new StreamReader("../../input/1.txt");
            //Console.SetIn(reader);
            //var writer = new StreamWriter("../../ouput.txt",true);
            //Console.SetOut(writer);

            var builder = new StringBuilder();
            string line;
            while ((line = Console.ReadLine()) != "End")
            {
                var lineValues = line
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var command = lineValues[0];
                string message = null;
                switch (command)
                {
                    case "Insert":
                        message = ExecuteInsert(int.Parse(lineValues[1]), lineValues[2]);
                        break;
                    case "Append":
                        message = ExecuteAppend(lineValues[1]);
                        break;
                    case "Serve":
                        message = ExecuteServe(int.Parse(lineValues[1]));
                        break;
                    case "Find":
                        message = ExecuteFind(lineValues[1]).ToString();
                        break;
                    default:
                        break;
                }

                builder.AppendLine(message);
            }

            Console.WriteLine(builder.ToString());
        }

        static string ExecuteInsert(int atPosition, string personName)
        {
            if (atPosition >= 0 && atPosition <= queue.Count)
            {
                queue.Insert(atPosition, personName);
                AddNameToDictionary(personName);
                return OkMessage;
            }
            else
            {
                return ErrorMessage;
            }
        }

        static int ExecuteFind(string p)
        {
            if (namesEncounters.ContainsKey(p))
            {
                return namesEncounters[p];
            }
            else
            {
                return 0;
            }
        }

        static string ExecuteServe(int numberOfPeople)
        {
            if (queue.Count >= numberOfPeople)
            {
                var people = queue.GetRange(0, numberOfPeople);
                queue.RemoveRange(0, numberOfPeople);
                foreach (var name in people)
                {
                    RemoveNameFromDictionary(name);
                }

                return string.Join(" ", people);
            }
            else
            {
                return ErrorMessage;
            }
        }

        static string ExecuteAppend(string personName)
        {
            queue.Add(personName);
            AddNameToDictionary(personName);
            return OkMessage;
        }

        static void AddNameToDictionary(string name)
        {
            if (!namesEncounters.ContainsKey(name))
            {
                namesEncounters.Add(name, 1);
            }
            else
            {
                namesEncounters[name]++;
            }
        }

        static void RemoveNameFromDictionary(string name)
        {
            namesEncounters[name]--;
        }
    }
}
