using System;
using System.Diagnostics;

namespace Sorting
{
    public static class Sorts<T>
        where T : IComparable
	{
		public class MultyWayMergeSort
        {
            public int Ways { get; private set; }

            T[] items;

            public MultyWayMergeSort(int ways)
            {
                this.Ways = ways;
            }

            public void Sort(T [] items)
            {
                this.items = items;
                Sort(0, items.Length - 1);
            }

            void Sort (int start, int end)
            {
                if (start < end)
                {
                    int length = (int)Math.Ceiling((double)(end - start + 1) / Ways);

                    for (int i = 0; i < Ways - 1; i++)
                    {
                        int l, r;
                        l = start + length * i;
                        r = start + length * i + length - 1;
                        Sort(l, r);
                    }
                    Sort(start + length * (Ways - 1), end);

                    Merge(start, end, length);
                }
            }

            void Merge(int start, int end, int length)
            {
                T[] temp = new T[end - start + 1];
                // Creating lists for merging
                List<List<T>> merging = new List<List<T>>(Ways);
                List<T> tmp;
                int l, r;
                int j;

                for (int i = 0; i < Ways - 1 & i < temp.Length; i++)
                {
                    l = start + length * i;
                    r = start + length * i + length - 1;
                    tmp = new List<T>(length);
                    for (j = l; j < r + 1; j++)
                        tmp.Add(items[j]);
                    merging.Add(tmp);
                }
                if ((r = start + length * (Ways - 1)) <= end)
                {
                    tmp = new List<T>(end - r + 1);
                    for (j = r; j < end + 1; j++)
                        tmp.Add(items[j]);
                    merging.Add(tmp);
                }                
                
                j = 0;
                while (merging.Count != 0)
                {
                    int min = 0;
                    for (int i = 1; i < merging.Count; i++)
                    {
                        if (merging[i][0].CompareTo(merging[min][0]) < 0)
                        {
                            min = i;
                        }
                    }
                    temp[j] = merging[min][0];
                    merging[min].RemoveAt(0);
                    if (merging[min].Count == 0)
                        merging.RemoveAt(min);
                    j++;
                }

                j = 0;
                for (int i = start; i < end + 1; i++)
                {
                    items[i] = temp[j];
                    j++;
                }
            }
            
        }
	}
}
