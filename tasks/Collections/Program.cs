using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    public class Program
    {
        static void Main(string[] args)
        {

            SmartStack<int> stack1 = new SmartStack<int>();
            //SmartStack<char> stack2 = new SmartStack<char>(new List<char> { 'h', 'e', 'l', 'l', 'o', '!'});
            //SmartStack<int[]> stack3 = new SmartStack<int[]>(6);

            stack1.Push(1);
            stack1.Push(2);
            stack1.Push(3);

            Console.WriteLine("Вывод по индексам:");
            for (int i = 0; i < stack1.Count; i++)
                Console.Write($"{stack1[i]} ");
            Console.WriteLine();

            stack1.PushRange(new HashSet<int> { 6, 7, 8, 9 });
            Console.WriteLine($"Pop: {stack1.Pop()}");
            Console.WriteLine($"Peek: {stack1.Peek()}");
            Console.WriteLine($"Stack contains item 1: {stack1.Contains(1)}");
            Console.WriteLine($"Stack contains item 9: {stack1.Contains(9)}");

            Console.WriteLine("Вывод через foreach:");
            foreach (int i in stack1)
                Console.Write($"{i} ");
            Console.WriteLine();
            int[] evens = stack1.Where(x => x % 2 == 0).ToArray();

            // Тестирование на ошибочных данных.
            SmartStack<int> test;
            try
            {
                test = new SmartStack<int>(-1);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine($"Ошибка 1:\n{e.Message}");
                test = new SmartStack<int>(10);

                test.Push(10);
                test.Push(9);
                foreach(int i in test)
                    Console.Write($"{i} ");
                Console.WriteLine();

                test[0] = 1;
                test[1] = 2;
                try
                {
                    test[10] = 5;
                }
                catch
                {
                    Console.WriteLine($"Ошибка 2:\n{e.Message}");
                    test.Push(3);
                    foreach (int i in test)
                        Console.Write($"{i} ");
                    Console.WriteLine();
                    try
                    {
                        int item = test[6];
                    }
                    catch
                    {
                        Console.WriteLine($"Ошибка 3:\n{e.Message}");
                        int item = test[2];

                        Console.WriteLine($"item = {item}");
                    }
                }
            }

            SmartStack<char> test2 = new SmartStack<char>();
            try
            {
                int item = test2.Pop();
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine($"Ошибка 4:\n{e.Message}");
            }

            try
            {
                int item = test2.Peek();
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine($"Ошибка 5:\n{e.Message}");
            }

            return;
        }
    }
}
