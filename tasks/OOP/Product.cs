using System;

namespace OOP
{
    public class Product
    {
        private string _name { get; set; }
        private string _manufacturer { get; set; }
        private double _cost { get; set; }
        private double _expirationDate { get; set; }
        private DateTime _productionDate { get; set; }
        /// <summary>
        /// Конструктор со всеми параметрами.
        /// </summary>
        /// <param name="name">Название</param>
        /// <param name="manufacturer">Производитель</param>
        /// <param name="cost">Цена</param>
        /// <param name="expirationDate">Срок годности</param>
        /// <param name="productionDate">Дата производства</param>
        public Product(string name, string manufacturer, double cost, double expirationDate, DateTime productionDate)
        {
            _name = name;
            _manufacturer = manufacturer;
            _cost = cost;
            _expirationDate = expirationDate;
            _productionDate = productionDate;
        }
        /// <summary>
        /// Возвращает информацию об объекте строкой.
        /// </summary>
        public override string ToString()
        {
            return "Название: " + _name + "\n" +
                "Производитель: " + _manufacturer + "\n" +
                "Цена: " + _cost + " руб.\n" +
                "Срок годности: " + _expirationDate + " мес.\n" +
                "Дата производства: " + _productionDate.ToShortDateString() + "\n";
        }
    }
}