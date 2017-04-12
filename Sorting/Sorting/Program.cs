using System;
using Sorting.HeapSort;
using Sorting.MergeSort;
using Sorting.Utilities;

namespace Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            var heapSort = new HeapSorting<int>();
            int[] array1 = { 4, 1, 3, 2, 16, 9, 10, 14, 8, 7, 1 };
            heapSort.Sort(array1);

            Console.WriteLine(string.Join(", ", array1));

            var mergeSort = new MergeSorting<int>();
            int[] array2 = { 4, 1, 3, 2, 16, 9, 10, 14, 8, 7, 1 };
            mergeSort.Sort(array2);

            Console.WriteLine(string.Join(", ", array2));

            Console.Read();
        }
    }
}
