using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataTypesTask1.Program;

namespace DataTypesTask2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var n = int.Parse(GetStringFromConsole("Введите длину диагонали будущего ромба (положительное нечетное целое число): "));

                var indexes = GetRhombusIndexes(n);

                var space = char.Parse(GetStringFromConsole("Введите символ-заполнитель (например, пробел): "));
                var edgeSymbol = char.Parse(GetStringFromConsole("Введите символ, обозначающий границы фигуры (например, Х): "));

                var diamondOfStringArray = GetDiamondByStringArray(indexes, space, edgeSymbol);

                DisplayDiamond(diamondOfStringArray);
            }
            catch (FormatException ex) when (ex.StackTrace.Contains("StringToNumber"))
            {
                Console.WriteLine($"Ошибка ввода числа. {ex.Message}");
            }
            catch (FormatException ex) when (ex.StackTrace.Contains("Char.Parse"))
            {
                Console.WriteLine($"Ошибка ввода символа. {ex.Message}");
            }
            catch (OverflowException ex)
            {
                Console.WriteLine($"Ошибка ввода неотрицательного числа. {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Формирует "карту" индексов для ромба.
        /// </summary>
        /// <param name="n">Длина диагонали ромба.</param>
        /// <returns>Зубчатый массив с индексами предполагаемых "границ" ромба.</returns>
        /// <exception cref="ArgumentException">Выбрасывается при при четном или неположительном n.</exception>
        public static int[][] GetRhombusIndexes(int n)
        {
            if (n % 2 == 0 || n < 1)
                throw new ArgumentException("Ожидалось положительное нечетное число.", nameof(n));

            int rows = n, cols = 1;
            int[][] result = new int[rows][];

            var half = (int)n / 2;

            // Запись центральных позиций для первой и последней строки.
            result[0] = result[n - 1] = new int[cols];
            result[0][0] = result[n - 1][0] = half;

            // Весь остальной код - запись по две позиции для строк между первой и последней.
            cols++;

            var j = half + 1;

            for (int i = 1; i <= half; i++)
            {
                result[i] = result[n - 1 - i] = new int[] { (int)(j - 2*i), j };
                j++;
            }

            return result;
        }

        /// <summary>
        /// Формирует массив строк для отображения ромба.
        /// </summary>
        /// <param name="indexes">Массив индексов ромба.</param>
        /// <param name="n">Размер массива.</param>
        /// <param name="space">Символ-заполнитель.</param>
        /// <param name="edgeSymbol">Символ, обозначающий границу фигуры.</param>
        /// <returns>Массив строк длины n, изображающий ромб.</returns>
        /// <exception cref="ArgumentException">Выбрасывается при исходно пустом массиве.</exception>
        public static string[] GetDiamondByStringArray(int[][] indexes, char space, char edgeSymbol)
        {
            if (indexes.Length == 0)
                throw new ArgumentException("Ожидался непустой массив.", nameof(indexes));

            int n = indexes.Length;

            string[] result = new string[n];

            for (int i = 0; i < n; i++)
            {
                StringBuilder temp = new StringBuilder();

                temp.Append(space, (n - indexes[i].Length));

                for (int j = 0; j < indexes[i].Length; j++)
                    temp.Insert(indexes[i][j], edgeSymbol.ToString(), 1);

                result[i] = temp.ToString();
            }

            return result;
        }
        
        /// <summary>
        /// Выводит на экран ромб из массива строк.
        /// </summary>
        /// <param name="lines">Массив строк для ромба.</param>
        public static void DisplayDiamond(string[] lines)
        {
            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }
        }
    }
}
