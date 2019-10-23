using System;
using System.Diagnostics;

namespace Sorting
{
    public static class Sorting<T>
        where T : IComparable
	{ 	
		static public void BubbleSort(T[] items)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            bool swapped;

            do
            {
                swapped = false;
                for (int i = 1; i < items.Length; i++)
                {
                    if (items[i - 1].CompareTo(items[i]) > 0)
                    {
                        T temp = items[i];
                        items[i] = items[i - 1];
                        items[i - 1] = temp;
                        swapped = true;
                    }
                }
            } while (swapped != false);

            sw.Stop();
            Console.WriteLine(sw.Elapsed);
        }
	}
}	