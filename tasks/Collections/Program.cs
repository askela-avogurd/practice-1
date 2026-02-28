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

            // Тестирование на ошибочных данных
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

    public class SmartStack<T> : IEnumerable<T>
    {
        // Примечание: вершина стека - конец массива.
        private T[] _array = null;

        public int Count { get; private set; }
        public int Capacity => _array.Length;

        // Конструктор без параметров (создаётся массив ёмкостью 4 элемента).
        public SmartStack()
        {
            _array = new T[4];
            Count = 0;
        }
        // Конструктор с одним целочисленным параметром (создаётся массив указанной ёмкости).
        public SmartStack(int capacity)
        {
            if (capacity <= 0)
                throw new ArgumentOutOfRangeException(nameof(capacity));
            _array = new T[capacity];
            Count = 0;
        }
        // Конструктор, который в качестве параметра принимает коллекцию IEnumerable<T>.
        public SmartStack(IEnumerable<T> collection)
        {
            T[] items = collection.ToArray();
            Count = items.Count();
            _array = new T[Count];
            for (int i=0; i<Count; i++)
                _array[i] = items[i];
        }
        // Одиночный элемент добавляется в конец.
        public void Push(T item)
        {
            if (Count == _array.Length)
                Array.Resize(ref _array, Capacity * 2);
            _array[Count++] = item;
        }
        // Элементы коллекции также добавляются в конец.
        public void PushRange(IEnumerable<T> collection)
        {
            T[] items = collection.ToArray();
            if (Capacity < Count + items.Length)
                Array.Resize(ref _array, Math.Max(Capacity * 2, Count + items.Length));
            for (int i=0; i<items.Length; i++)
            {
                _array[Count++] = items[i];
            }
        }
        // Элемент извлекается с конца.
        public T Pop()
        {
            if (Count == 0)
                throw new InvalidOperationException("Стек пуст.");
            T item = _array[Count - 1];
            _array[--Count] = default(T);
            return item;
        }
        public T Peek()
        {
            if (Count == 0)
                throw new InvalidOperationException("Стек пуст.");
            return _array[Count - 1];
        }
        public bool Contains(T item) => Array.IndexOf(_array, item, 0, Count) >= 0;

        // Методы, реализующие интерфейсы IEnumerable<T> и IEnumerable.
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = Count - 1; i >= 0; i--)
                yield return _array[i];
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        // Индексатор.
        public T this[int depth]
        {
            get
            {
                if (depth < 0 || depth >= Count)
                    throw new ArgumentOutOfRangeException(nameof(depth));
                return _array[Count - depth - 1];
            }
            set
            {
                if (depth < 0 || depth >= Count)
                    throw new ArgumentOutOfRangeException(nameof(depth));
                _array[Count - depth - 1] = value;
            }
        }
    }
}
