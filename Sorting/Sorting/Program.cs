using System;
using Sorting.HeapSort;

namespace Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            Heap<int> heap = Heap<int>.Create(4, 1, 3, 2, 16, 9, 10, 14, 8, 7);           
            heap.InsertValue(5);
            heap.InsertValue(5);
            heap.InsertValue(20);
            heap.InsertValue(0);
            Console.WriteLine(heap);

            while(heap.NotEmpty)
            {
                Console.WriteLine(heap.ExtractMaximum());
            }
            Console.WriteLine(heap);
            Console.Read();
        }
    }
}
