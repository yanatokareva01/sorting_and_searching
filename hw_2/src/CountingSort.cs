using System;
using System.Diagnostics;

namespace Sorting
{
    public static class Sorts<T>
        where T : IComparable
    {
	static public void CountingSort(int[] items, int k)
        {
            int[] arr = new int[k + 1];
            int[] sorted = new int[items.Length];
            foreach (var a in items)
                arr[a]++;

            for (int i = 1; i < arr.Length; i++)
            {
                arr[i] = arr[i] + arr[i - 1];
            }

            for (int i = items.Length - 1; i >= 0; i--)
            {
                sorted[arr[items[i]] - 1] = items[i];
                arr[items[i]]--;
            }
        }
    }
}
