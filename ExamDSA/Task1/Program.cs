namespace Task1
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Wintellect.PowerCollections;

    class Program
    {
        const string AddCommand = "add";
        const string RemoveCommand = "remove";
        const string FindCommand = "find";
        const string PowerCommand = "power";

        static Dictionary<string, Unit> byName = new Dictionary<string, Unit>();
        static MultiDictionary<string, Unit> byType = new MultiDictionary<string, Unit>(false);
        static OrderedBag<Unit> byPower = new OrderedBag<Unit>();
        static StringBuilder builder = new StringBuilder();

        static void Main()
        {
            //var reader = new StreamReader("../../input/2.txt");
            //Console.SetIn(reader);

            string input = null;
            while ((input = Console.ReadLine()) != "end")
            {
                var parameters = input
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim())
                    .ToArray();

                if (parameters[0].ToLower() == AddCommand)
                {
                    builder.AppendLine(ExecuteAddCommand(parameters));
                }
                else if (parameters[0].ToLower() == RemoveCommand)
                {
                    builder.AppendLine(ExecuteRemoveCommand(parameters));
                }
                else if (parameters[0].ToLower() == FindCommand)
                {
                    builder.AppendLine(ExecuteFindCommand(parameters));
                }
                else if (parameters[0].ToLower() == PowerCommand)
                {
                    builder.AppendLine(ExecutePowerCommand(parameters));
                }
            }

            Console.WriteLine(builder.ToString());
        }

        private static string ExecuteFindCommand(string[] parameters)
        {
            List<string> result = new List<string>();
            if (byType.ContainsKey(parameters[1]))
            {
                    result = byType[parameters[1]]
                   .OrderByDescending(x => x.Attack)
                   .ThenBy(x => x.Name)
                   .Take(10)
                   .Select(x => x.ToString())
                   .ToList();

            }

            return string.Format("RESULT: {0}", string.Join(", ", result));
        }

        private static string ExecuteRemoveCommand(string[] parameters)
        {
            if (!byName.ContainsKey(parameters[1]))
            {
                return string.Format("FAIL: {0} could not be found!", parameters[1]);
            }

            var unitToRemove = byName[parameters[1]];
            byName.Remove(unitToRemove.Name);
            byPower.Remove(unitToRemove);
            byType.Remove(unitToRemove.Type, unitToRemove);

            return string.Format("SUCCESS: {0} removed!", unitToRemove.Name);
        }

        private static string ExecutePowerCommand(string[] parameters)
        {
            var numberOfUnits = Math.Min(int.Parse(parameters[1]), byPower.Count);

            string result = string.Join(", ", byPower.Take(numberOfUnits));

            return string.Format("RESULT: {0}", result);
        }

        private static string ExecuteAddCommand(string[] parameters)
        {
            var name = parameters[1];
            var type = parameters[2];
            var attack = int.Parse(parameters[3]);

            if (byName.ContainsKey(name))
            {
                return string.Format("FAIL: {0} already exists!", name);
            }

            var unitToAdd = new Unit(name, type, attack);

            byName.Add(name, unitToAdd);
            byType.Add(type, unitToAdd);
            byPower.Add(unitToAdd);

            return string.Format("SUCCESS: {0} added!", name);
        }
    }

    class Unit : IComparable
    {
        public Unit(string name, string type, int attack)
        {
            this.Name = name;
            this.Type = type;
            this.Attack = attack;
        }

        public string Name { get; set; }

        public string Type { get; set; }

        public int Attack { get; set; }

        public int CompareTo(object obj)
        {
            if (this.Attack < (obj as Unit).Attack)
            {
                return 1;
            }
            else if (this.Attack > (obj as Unit).Attack)
            {
                return -1;
            }
            else
            {
                return this.Name.CompareTo((obj as Unit).Name);
            }
        }

        public override string ToString()
        {
            return string.Format("{0}[{1}]({2})", this.Name, this.Type, this.Attack);
        }
    }
}
