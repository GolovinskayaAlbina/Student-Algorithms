using System;

namespace Sorting.HeapSort
{
    class HeapSorting<T> where T : IComparable, new()
    {
        public void Sort(T[] array)
        {
            var heap = Heap<T>.Create(array);
            int i = 0;
            while (heap.NotEmpty)
            {
                array[i++] = heap.ExtractMaximum();
            }
        }
    }
}
