using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    static class Utility
    {
        public static void Swap(this int[] array, int firstIndex, int secontIndex)
        {
            int tmp = array[firstIndex];
            array[firstIndex] = array[secontIndex];
            array[secontIndex] = tmp;
        }
    }
}
