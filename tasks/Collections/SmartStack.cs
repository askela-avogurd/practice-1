using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
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
            for (int i = 0; i < Count; i++)
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
            for (int i = 0; i < items.Length; i++)
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
