using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicArray
{
    class DynamicArray
    {
		private int[] items; // физический массив
		private int size = 0; // число для размера динамического массива и индекс ячейки для вставки нового значения
		public DynamicArray(int length) // конструкторы по умолчанию и с параметром
		{
			items = new int[length];
		}
		public DynamicArray()
		{
			items = new int[0];
		}
		public void Print() // для вывода массива
		{
			for (int i = 0; i < size; i++)
			{
				Console.Write(items[i] + " ");
			}
		}
		public int GetCount()
		{
			return size;
		}
		public int Get(int index) // нахождение элемента по индексу
		{
			if (index >= size || index < 0)
			{
				throw new Exception("Индекс находится за пределами массива.");
			}
			return items[index];
		}
		public int Find(int key) // нахождение элемента по ключу
		{
			for (int i = 0; i < size; i++)
			{
				if (items[i] == key)
				{
					return i;
				}
			}
			return -1;
		}
		public int FindLast(int key) // нахождение последнего элемента по ключу
		{
			for (int i = size - 1; i >= 0; i--)
			{
				if (items[i] == key) return i;
			}
			return -1;
		}
		private void IncreaseArray() // увеличивает размер фактического массива в два раза
		{
			int newCount = size * 2;
			if (size == 0)
			{
				newCount = 4;
			}
			var newArray = new int[newCount];
			for (int i = 0; i < size; i++)
			{
				newArray[i] = items[i];
			}
			items = newArray;
		}
		public void PushBack(int item) // добавляет элемент в конец
		{
			if (size == items.Length)
			{
				IncreaseArray();
			}
			items[size] = item;
			size++;
		}
		public void Insert(int index, int item) // добавление элемента по индексу
		{
			if (index < 0 || index > size)
			{
				throw new Exception("Выход за пределами массива");
			}

			if (size == items.Length)
			{
				IncreaseArray();
			}
			// сдвигаем все элементы вправо до нужного индекса
			for (int i = size - 1; i >= index; i--)
			{
				items[i + 1] = items[i];
			}

			items[index] = item;
			size++;
		}
		public void PushFront(int item) // добавление элемента в начало
		{
			Insert(0, item);
		}
		public void PushBackRange(int[] array) // добавляет элементы переданного массива в конец
		{
			for (int i = 0; i < array.Length; i++)
			{
				PushBack(array[i]);
			}
		}
		public void InsertRange(int index, int[] array) //добавляет элементы переданного массива с указанного индекса
		{
			for (int i = 0; i < array.Length; i++)
			{
				Insert(index, array[i]);
				index++;
			}
		}
		public void PopBack() // удаление последнего элемента
		{
			if (size == 0)
			{
				throw new Exception("Массив пустой.");
			}
			size--;
		}
		public void RemoveByIndex(int index) // удаление элемента на произвольном месте
		{
			if (size == 0)
			{
				throw new Exception("Массив пустой!");
			}
			if (index < 0 || index >= size)
			{
				throw new Exception("Выход за пределами массива");
			}
			for (int i = index + 1; i < size; i++)
			{
				items[i - 1] = items[i];
			}
			size--;
		}
		public void PopFront() // удаление первого элемента
		{
			RemoveByIndex(0);
		}
		public bool Remove(int item) // удаляет первое вхождение указанного элемента из массива
		{
			for (int i = 0; i < size; i++)
			{
				if (items[i] == item)
				{
					RemoveByIndex(i);
					return true;
				}
			}
			return false;
		}
		public int RemoveAll(int item) // удаляет все вхождения указанного элемента
		{
			int count = 0;
			for (int i = 0; i < size;)
            {
				if (items[i] == item)
				{
					RemoveByIndex(i);
					count++;
				}
				if (items[i] != item) i++;
			}
			return count;
		}
	}
}
