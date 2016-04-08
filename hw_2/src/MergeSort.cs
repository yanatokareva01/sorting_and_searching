using System;
using System.Diagnostics;

namespace Sorting
{
    public static class Sorts<T>
        where T : IComparable
    {
		static public void MergeSort (T [] items)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            MergeSort(items, 0, items.Length - 1);
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
        }

        static void MergeSort(T [] items, int start, int end)
        {
            if (end > start)
            {
                int mid = (start + end) / 2;
                MergeSort(items, start, mid);
                MergeSort(items, mid + 1, end);
                Merge(items, start, mid, end);
            }
        }

        static void Merge(T [] items, int start, int mid, int end)
        {
            T [] temp = new T[(end - start) + 1];

            int i = start;
            int j = mid + 1;
            int k = 0;

            while (i < mid + 1 && j < end + 1)
            {
                if (items[i].CompareTo(items[j]) <0)
                {
                    temp[k] = items[i];
                    i++;
                    k++;
                }
                else
                {
                    temp[k] = items[j];
                    j++;
                    k++;
                }
            }
            //fill in the rest
            while (i <= mid)
            {
                temp[k] = items[i];
                i++;
                k++;

            }
            while (j <= end)
            {
                temp[k] = items[j];
                j++;
                k++;
            }
            //now make array the sorted version
            i = start;
            k = 0;
            while (k < temp.Length && i <= end)
            {
                items[i] = temp[k];
                k++;
                i++;
            }
        }
	}
}