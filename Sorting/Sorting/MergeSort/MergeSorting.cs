using System;
using Sorting.Utilities;

namespace Sorting.MergeSort
{
    class MergeSorting<T> where T: IComparable, new()
    {
        private readonly T _maxValue;

        public MergeSorting()
        {
            _maxValue = (new T()).MaxValue();
        }

        public void Sort(T[] array)
        {
            MergeSort(array, 0, array.Length - 1);
        }

        private void MergeSort(T[] array, int start, int end)
        {
            if (start >= end)
            {
                return;
            }
            int middle = (start + end) / 2;
            MergeSort(array, start, middle);
            MergeSort(array, middle + 1, end);
            Merge(array, start, middle + 1, end);
        }

        private void Merge(T[] array, int start, int middle, int end)
        {
            int leftArrayLength = middle - start + 1;
            int rightArrayLength = end - middle + 2;

            T[] leftArray = new T[leftArrayLength];
            T[] rightArray = new T[rightArrayLength];

            for (int i = 0; i < leftArrayLength-1; i++)
            {
                leftArray[i] = array[start + i];
            }
            leftArray[leftArrayLength - 1] = _maxValue;

            for (int i = 0; i < rightArrayLength - 1; i++)
            {
                rightArray[i] = array[middle + i];
            }
            rightArray[rightArrayLength - 1] = _maxValue;

            int leftIndex = 0;
            int rightIndex = 0;

            for (int i = start; i <= end; i++)
            {
                if (leftArray[leftIndex].CompareTo(rightArray[rightIndex]) < 1)
                {
                    array[i] = leftArray[leftIndex];
                    leftIndex += 1;
                }
                else
                {
                    array[i] = rightArray[rightIndex];
                    rightIndex += 1;
                }
            }
        }
    }
}
