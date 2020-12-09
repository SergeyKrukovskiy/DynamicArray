using System;

namespace DynamicArray
{
    class Program
    {
        static void Main(string[] args)
        {
            DynamicArray array = new DynamicArray(4);
            array.PushBack(2);
            array.PushFront(1);
            array.PushFront(1);
            Console.WriteLine(array.RemoveAll(1));
            Console.ReadLine();
        }
    }
}
