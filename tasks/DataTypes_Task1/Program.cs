using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataTypesTask1
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var initialDeposit = decimal.Parse(GetStringFromConsole("Введите начальный вклад (положительное число): "));
                var years = uint.Parse(GetStringFromConsole("Введите количество лет (положительное целое число): "));
                var interestRate = decimal.Parse(GetStringFromConsole("Введите годовую процентную ставку (положительное число): "));

                var calculations = new Dictionary<uint, decimal>(GetCalculationsDictionary(initialDeposit, years, interestRate));

                OutputCalculations(calculations);
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Ошибка ввода числа.\n{ex.Message}");
            }
            catch (OverflowException ex)
            {
                Console.WriteLine($"Ошибка ввода неотрицательного числа.\n{ex.Message}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
        /// <summary>
        /// Выводит расчеты в надлежащем виде.
        /// </summary>
        /// <param name="calculations">Словарь "год" - "сумма накоплений".</param>
        public static void OutputCalculations(Dictionary<uint, decimal> calculations)
        {
            // Изменение языка и региона для вывода вещественного с точкой, а не с запятой.
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-us");

            foreach (var pair in calculations)
            {
                Console.WriteLine($"Год {pair.Key}: {Decimal.Round(pair.Value, 2)} руб.");
            }
        }

        /// <summary>
        /// Расчитывает сумму накоплений за каждый год.
        /// </summary>
        /// <param name="initialDeposit">Начальный вклад.</param>
        /// <param name="years">Количество лет.</param>
        /// <param name="interestRate">Годовая процентная ставка.</param>
        /// <returns>Словарь, где ключ - год, значение - сумма накоплений.</returns>
        public static Dictionary<uint, decimal> GetCalculationsDictionary(decimal initialDeposit, uint years, decimal interestRate)
        {
            decimal lowerLimit = 1;

            CheckNumber(initialDeposit, lowerLimit);
            CheckNumber(years, lowerLimit);
            CheckNumber(interestRate, lowerLimit);

            Dictionary<uint, decimal> result = new Dictionary<uint, decimal>();
            const decimal MaxPercent = 100;

            decimal proportion = interestRate / MaxPercent;

            for (uint i = 0; i < years; i++)
            {
                initialDeposit += initialDeposit * proportion;
                result.Add((i+1), initialDeposit);
            }

            return result;
        }

        /// <summary>
        /// Проверяет соблюдение границ числа.
        /// </summary>
        /// <param name="number">Проверяемое число.</param>
        /// <param name="lowerLimit">Нижняя граница.</param>
        /// <exception cref="ArgumentException">Выбрасывается при выходе за установленные границы.</exception>
        public static void CheckNumber(decimal number, decimal lowerLimit)
        {
            if (number < lowerLimit)
                throw new ArgumentException($"\nОжидался ввод неотрицательного числа. Получено: {number}.");
        }

        /// <summary>
        /// Реализует интерактив.
        /// </summary>
        /// <param name="message">Сообщение для пользователя.</param>
        /// <returns>Строка ввода для дальнейшего преобразования в нужный тип.</returns>
        public static string GetStringFromConsole(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }
    }
}
