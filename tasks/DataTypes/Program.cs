using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write(CreateDiamond(21));
        }

        // Задание 2
        static string CreateDiamond(int n)
        {
            int half = (int)n / 2 + 1;

            StringBuilder upperHalf = new StringBuilder();
            StringBuilder lowerHalf = new StringBuilder();

            for (int i = 1; i < half; i++)
            {
                StringBuilder halfLine = new StringBuilder();
                for (int j = 1; j < half; j++)
                {
                    halfLine.Append((i + j == half) ? 'X' : ' ');
                }
                string reversedHalf = new string(halfLine.ToString().Reverse().ToArray());
                StringBuilder singleLine = new StringBuilder($"{halfLine}{reversedHalf.ToString().Substring(1)}\n");
                upperHalf.Append(singleLine);
                if (i != half - 1)
                    lowerHalf.Insert(0, singleLine);
            }
            // Удаляется последний перенос строки
            lowerHalf.Remove(lowerHalf.Length - 1, 1);

            // Возвращается строка из двух половинок ромба
            return upperHalf.ToString() + lowerHalf.ToString();
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

