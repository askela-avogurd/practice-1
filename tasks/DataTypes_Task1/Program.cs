using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypes_Task1
{
    public class Program
    {
        static void Main(string[] args)
        {
            var initial_deposit = decimal.Parse(GetStringFromConsole("Введите начальный вклад (положительное число): "));
            var years = int.Parse(GetStringFromConsole("Введите количество лет (положительное целое число): "));
            var interest_rate = decimal.Parse(GetStringFromConsole("Введите годовую процентную ставку (положительное число): "));

            Console.WriteLine(GetStringOfCalculations(initial_deposit, years, interest_rate));
        }

        /// <summary>
        /// Выводит список накоплений на экран.
        /// </summary>
        static string GetStringOfCalculations(decimal initial_deposit, int years, decimal interest_rate)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-us");
            var sums = new List<decimal>(GetAccumulatedSumsList(initial_deposit, years, interest_rate));
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < years; i++)
            {
                result.Append($"Год {i + 1}: {Decimal.Round(sums[i], 2)} руб.\n");
            }

            return result.ToString();
        }

        /// <summary>
        /// Формирует список накоплений.
        /// </summary>
        static IEnumerable<decimal> GetAccumulatedSumsList(decimal initial_deposit, int years, decimal interest_rate)
        {
            const decimal MaxPercent = 100;
            decimal proportion = interest_rate / MaxPercent;
            for (int i = 0; i < years; i++)
            {
                initial_deposit += initial_deposit * proportion;
                yield return initial_deposit;
            }
        }

        /// <summary>
        /// Реализует интерактив.
        /// </summary>
        /// <remarks>
        /// Выводит сообщение и считывает строку для преобразования потом в нужный тип данных.
        /// </remarks>
        static string GetStringFromConsole(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }
    }
}
