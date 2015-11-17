using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Precision
{
    class Program
    {
        static int Divide(string fraction, int a, int b)
        {
            a *= 10;
            int i;

            for (i = 0; i < 20; i++)
            {
                int digit = a / b;
                if (digit == fraction[i] - '0')
                {
                    break;
                }

                a = a % b * 10;
            }

            return i;
        }

        static void Main(string[] args)
        {
            int maxDenominator = int.Parse(Console.ReadLine());
            var fraction = Console.ReadLine().Split('.')[1];

            int bestNom = 0;
            int bestDen = 0;
            int precision = 1;
            for (int den = 0; den < maxDenominator; den++)
            {
                for (int nom = 0; nom < den; nom++)
                {
                    Console.WriteLine("{0}/{1} => {2}", nom, den, Divide(fraction, nom, den));
                }
            }
        }
    }
}
