using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypes_Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
        // Задание 1
        static string GetStringOfCalculations(double initial_deposit, int years, double interest_rate)
        {
            double proportion = interest_rate / 100;
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < years; i++)
            {
                initial_deposit += initial_deposit * proportion;
                string changed_deposit = String.Format("{0:0.00}", initial_deposit);
                result.Append($"Год {i + 1}: {changed_deposit} руб.\n");
            }

            return result.ToString();
        }
    }
}
