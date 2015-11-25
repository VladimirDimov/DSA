namespace MinimumEditDistance
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class MEDCalculator
    {
        private decimal deleteCost;
        private decimal insertCost;
        private decimal replaceCost;

        public MEDCalculator(decimal insertCost, decimal deleteCost, decimal replaceCost)
        {
            this.insertCost = insertCost;
            this.deleteCost = deleteCost;
            this.replaceCost = replaceCost;
        }

        public decimal Calculate(string target, string input)
        {
            var distance_table = new double[input.Length + 1, target.Length + 1];

            for (int k = 0; k <= input.Length; k++)
            {
                distance_table[k, 0] = k * 0.7;
            }

            for (int k = 0; k <= target.Length; k++)
            {
                distance_table[0, k] = k * 0.7;
            }

            for (int k = 1; k <= input.Length; k++)
            {
                for (int d = 1; d <= target.Length; d++)
                {
                    if (input[k - 1] == target[d - 1])//if the letters are same 
                        distance_table[k, d] = distance_table[k - 1, d - 1];
                    else //if not add 1 to its neighborhoods and assign minumun of its neighborhoods 
                    {
                        distance_table[k, d] = Math.Min(Math.Min(distance_table[k - 1, d - 1] + 1,
                          distance_table[k - 1, d] + 0.7), distance_table[k, d - 1] + 0.7);
                    }
                }

            }
            //create table
            //Compute Distance
            decimal totalCost = 0;
            int i = input.Length, j = target.Length;

            while (true)
            {
                if (i == 0 && j == 0)
                {
                    return totalCost;
                }
                else if (i == 0 && j > 0)
                {
                    totalCost += deleteCost;//delete
                    j--;
                }
                else if (i > 0 && j == 0)
                {
                    totalCost += insertCost;//insert
                    i--;
                }
                else
                {
                    if (distance_table[i - 1, j - 1] <= distance_table[i - 1, j] &&
                            distance_table[i - 1, j - 1] <= distance_table[i, j - 1])
                    {
                        if (distance_table[i - 1, j - 1] == distance_table[i, j])
                            totalCost += 0; //match
                        else
                            totalCost += replaceCost; //replace

                        i--;
                        j--;
                    }

                    else if (distance_table[i - 1, j] < distance_table[i, j - 1])
                    {
                        totalCost += insertCost; //insert
                        i--;

                    }
                    else if (distance_table[i, j - 1] < distance_table[i - 1, j])
                    {
                        totalCost += deleteCost; //delete
                        j--;
                    }
                }
            }
        }
    }
}
