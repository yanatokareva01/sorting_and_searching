using System;
using System.Diagnostics;

namespace Sorting
{
    public static class Sorting<T>
        where T : IComparable
	{ 	
		static public void BinaryInsertionSort(T[] items)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            for (int i = 1; i < items.Length; i++)
            {
                if (items[i-1].CompareTo(items[i]) > 0)
                {
                    T curr = items[i];
                    int left = 0;
                    int right = i - 1;
                    int middle;
                    do
                    {
                        middle = (left + right) / 2;
                        if (items[middle].CompareTo(curr) > 0)
                            right = middle - 1;
                        else
                            left = middle + 1;
                    } while (right >= left);

                    for (int j = i - 1; j >= left; j--)
                    {
                        items[j + 1] = items[j];
                    }
                    items[left] = curr;
                } 
            }

            sw.Stop();
            Console.WriteLine(sw.Elapsed);
        }
	}
}