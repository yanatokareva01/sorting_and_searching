using System;
using System.Diagnostics;

namespace Sorting
{
    public static class Sorts<T>
        where T : IComparable
    {
		static public void QuickSort(T [] items)
		{
            Stopwatch sw = new Stopwatch();
            sw.Start();
            QuickSort(items, 0, items.Length-1);
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
        }

        static public void QuickSort(T [] items, int l, int r)
        { 
            if (l >= r)
                return;
            int m = Partition(items, l, r);
            QuickSort(items, l, m - 1);
            QuickSort(items, m + 1, r);
        }

        static int Partition(T[] items, int l, int r)
        {
            Random rnd = new Random();
            int k = rnd.Next(l, r);
            T temp = items[l];
            items[l] = items[k];
            items[k] = temp;
            T x = items[l];

            int j = l;
            for (int i = l + 1; i <= r; i++)
            {
                if (items[i].CompareTo(x) <= 0)
                {
                    j = j + 1;
                    T tmp = items[i];
                    items[i] = items[j];
                    items[j] = tmp;
                }
            }
            temp = items[l];
            items[l] = items[j];
            items[j] = temp;

            return j;
        }
	}
}