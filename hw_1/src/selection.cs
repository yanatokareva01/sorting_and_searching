using System;
using System.Diagnostics;

namespace Sorting
{
    public static class Sorting<T>
        where T : IComparable
	{ 	
		static public void SelectionSort(T[] items)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            for (int i = 0; i < items.Length - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < items.Length; j++)
                    if (items[j].CompareTo(items[min]) < 0)
                        min = j;
                T temp = items[i];
                items[i] = items[min];
                items[min] = temp;
            }

            sw.Stop();
            Console.WriteLine(sw.Elapsed);
        }
	}
}