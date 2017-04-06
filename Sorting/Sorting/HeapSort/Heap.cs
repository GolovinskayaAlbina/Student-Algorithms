using System;
using System.Collections.Generic;
using Sorting.Utilities;

namespace Sorting.HeapSort
{
    class Heap<T> where T: IComparable, new()
    {
        private readonly T _minValue;
        private IList<T> _heap = null;
        private int _heapLength;
        private Heap(T[] heap, T minValue)
        {
            _heap = new List<T>(heap);
            _heapLength = _heap.Count;

            //for method InsertValue
            _minValue = minValue;
        }

        public static Heap<T> Create(params T[] array)
        {
            var heap = new Heap<T>(array, (new T()).MinValue());
            heap.BuildMaxHeap();
            return heap;
        }

        public T Maximum
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

        public T ExtractMaximum()
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
            for (int i = (_heapLength - 1) / 2; i >= 0; i--)
                MaxHeapify(i);
        }

        private void MaxHeapify(int curIndex)
        {
            int largestIndex;
            int leftIndex = curIndex * 2 + 1;
            int rightIndex = curIndex * 2 + 2;

            if (leftIndex < _heapLength && _heap[leftIndex].CompareTo(_heap[curIndex]) > 0)
            {
                largestIndex = leftIndex;
            }
            else
            {
                largestIndex = curIndex;
            }
            if (rightIndex < _heapLength && _heap[rightIndex].CompareTo(_heap[largestIndex]) > 0)
            {
                largestIndex = rightIndex;
            }
            if (largestIndex != curIndex)
            {
                _heap.Swap(largestIndex, curIndex);
                MaxHeapify(largestIndex);
            }
        }

        public void InsertValue(T value)
        {
            _heap.Insert(_heapLength, _minValue);
            IncreaseValue(_heapLength++, value);
        }

        public void IncreaseValue(int index, T newValue)
        {
            if (index >= _heapLength)
            {
                throw new IndexOutOfRangeException();
            }
            if (_heap[index].CompareTo(newValue) >= 0)
            {
                return; //could throw InvalidOperationException
            }

            _heap[index] = newValue;
            int parentIndex = ((index + 1) / 2) - 1;
            while (index > 0 && _heap[index].CompareTo(_heap[parentIndex]) > 0)
            {
                _heap.Swap(index, parentIndex);
                index = parentIndex;
                parentIndex = ((index + 1) / 2) - 1;
            }
         }

        public bool NotEmpty
        {
            get
            {
                return _heapLength > 0;
            }
        }

        public override string ToString()
        {
            return _heap.Join(_heapLength);
        }
    }
}
