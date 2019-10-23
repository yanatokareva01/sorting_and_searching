using System;
using System.Diagnostics;

namespace Sorting
{
    public static class Sorting<T>
        where T : IComparable
	{ 	
		static public void InsertionSort(T[] array)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i].CompareTo(array[i-1]) < 0)
                {
                    T curr = array[i];
                    int j = i;
                    while (j > 0 && curr.CompareTo(array[j - 1]) < 0)
                    {
                        array[j] = array[j - 1];
                        j--;
                    }
                    array[j] = curr;
                }
            }
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
        }
	}
}	