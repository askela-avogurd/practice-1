using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypes_Task2
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
    }
}
