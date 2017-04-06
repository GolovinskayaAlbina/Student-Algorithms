﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
namespace Sorting.Utilities
{
    static class Extensions
    {
        public static int Left(this int index)
        {
            return index * 2 + 1;
        }
        public static int Right(this int index)
        {
            return index * 2 + 2;
        }
        public static int Parent(this int index)
        {
            return ((index + 1) / 2) - 1;
        }
        public static void Swap<T>(this IList<T> array, int firstIndex, int secontIndex)
        {
            T tmp = array[firstIndex];
            array[firstIndex] = array[secontIndex];
            array[secontIndex] = tmp;
        }

        public static string Join<T>(this IList<T> array, int count)
        {
            var cropped = new T[count];
            Array.Copy(array.ToArray(), cropped, count);
            return string.Join<T>(", ", cropped);
        }
        public static T MinValue<T>(this T value)
        {
            FieldInfo field = typeof(T).GetField("MinValue", BindingFlags.Public | BindingFlags.Static);
            if (field == null)
            {
                throw new InvalidOperationException();
            }
            return (T)field.GetValue(null);
        }
    }
}