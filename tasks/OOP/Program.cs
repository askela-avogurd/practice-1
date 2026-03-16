using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public class Program
    {
        public class Product
        {
            private string _name { get; set; }
            private string _manufacturer { get; set; }
            private double _cost { get; set; }
            private double _expirationDate { get; set; }
            private DateTime _productionDate { get; set; }

            public Product(string name, string manufacturer, double cost, double expirationDate, DateTime productionDate)
            {
                _name = name;
                _manufacturer = manufacturer;
                _cost = cost;
                _expirationDate = expirationDate;
                _productionDate = productionDate;
            }

            public override string ToString()
            {
                return "Название: " + _name + "\n" +
                    "Производитель: " + _manufacturer + "\n" +
                    "Цена: " + _cost + " руб.\n" +
                    "Срок годности: " + _expirationDate + " мес.\n" +
                    "Дата производства: " + _productionDate.ToShortDateString() + "\n";
            }
        }

        static void Main(string[] args)
        {
            bool correctInput = false;
            string name, manufacturer;
            double cost = -1, expirationDate = -1;
            DateTime productionDate = new DateTime();

            Console.Write("Введите название товара: ");
            name = Console.ReadLine();
            Console.Write("Введите производителя товара: ");
            manufacturer = Console.ReadLine();

            while (!correctInput)
            {
                Console.Write("Введите цену в рублях (используйте запятую для нецелого числа): ");
                try
                {
                    cost = double.Parse(Console.ReadLine());
                    if (cost < 0)
                    {
                        throw new ArgumentException("Число должно быть неотрицательным!");
                    }
                    correctInput = true;
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Некорректный ввод вещественного числа!");
                }
            }

            correctInput = false;
            while (!correctInput)
            {
                Console.Write("Введите срок годности в месяцах: ");
                try
                {
                    expirationDate = double.Parse(Console.ReadLine());
                    if (expirationDate < 0)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                    correctInput = true;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Некорректный ввод вещественного числа!");
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine("Число должно быть неотрицательным!");
                }
            }

            correctInput = false;
            while (!correctInput)
            {
                Console.Write("Введите дату в формате DD.MM.YYYY, для записи используйте только целые числа и знак \".\": ");
                string[] dateValues = Console.ReadLine().Split('.');

                try
                {
                    productionDate = new DateTime(int.Parse(dateValues[2]), int.Parse(dateValues[1]), int.Parse(dateValues[0]));
                    if (DateTime.Compare(productionDate, DateTime.Now) == 1)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                    correctInput = true;
                }
                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine("Некорректная запись даты! Используйте символ \".\" для разделения величин.");
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Некорректный ввод целых чисел!");
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine("Введенная дата производства недопустима!");
                }
            }
            Console.WriteLine();

            Product product1 = new Product(name, manufacturer, cost, expirationDate, productionDate);
            Console.Write(product1.ToString());
        } 
    }
} 
