using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting.HeapSort
{
    class Heap
    {
        private int[] _heap = null;
        private int _heapLength;
        private Heap(int[] heap)
        {
            _heap = heap;
            _heapLength = _heap.Length;
        }

        public static Heap Create(params int[] array)
        {
            var heap = new Heap(array);
            heap.BuildMaxHeap();
            return heap;
        }

        public int Maximum
        {
            get
            {
                if (_heapLength == 0)
                {
                    throw new IndexOutOfRangeException();
                }
                return _heap[0];
            }
        }

        public int ExtractMaximum()
        {
            var maximum = Maximum;
            if (--_heapLength > 0)
            {
                _heap[0] = _heap[_heapLength];
                MaxHeapify(0);
            };
            return maximum;
        }

        private void BuildMaxHeap()
        {
            for (int i = _heap.Length - 1 / 2; i >= 0; i--)
                MaxHeapify(i);
        }

        private void MaxHeapify(int curIndex)
        {
            int largestIndex;
            int leftIndex = curIndex * 2 + 1;
            int rightIndex = curIndex * 2 + 2;

            if (leftIndex < _heapLength && _heap[leftIndex] > _heap[curIndex])
            {
                largestIndex = leftIndex;
            }
            else
            {
                largestIndex = curIndex;
            }
            if (rightIndex < _heapLength && _heap[rightIndex] > _heap[largestIndex])
            {
                largestIndex = rightIndex;
            }
            if (largestIndex != curIndex)
            {
                _heap.Swap(largestIndex, curIndex);
                MaxHeapify(largestIndex);
            }
        }
    }
}
