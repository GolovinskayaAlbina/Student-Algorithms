using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sorting.HeapSort;

namespace Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            Heap heap = Heap.Create(4, 1, 3, 2, 16, 9, 10, 14, 8, 7);
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(heap.ExtractMaximum());
            }
            Console.Read();
        }
    }
}
