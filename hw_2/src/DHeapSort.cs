using System;
using System.Diagnostics;

namespace Sorting
{
    public static class Sorts<T>
        where T : IComparable
    {
		public class D_Heap
        {
            public int d { get; private set; }
            int heapSize;

            public D_Heap(int d)
            {
                this.d = d;
            }

            public void DHeapSort(T[] items)
            {
                this.heapSize = items.Length - 1;
                BuildDHeap(items);
                
                for (int i = items.Length - 1; i >= 1; i--)
                {
                    T temp = items[0];
                    items[0] = items[i];
                    items[i] = temp;

                    this.heapSize--;
                    Heapify(items, 0);
                }
            }

            void BuildDHeap(T[] items)
            {
                for (int i = firstNonLeaf(items); i >= 0; i--)
                {
                    Heapify(items, i);
                }
            }

            int Parent(int i)
            {
                return (i - 1) / this.d;
            }

            int Child(int i, int j)
            {
                return i*this.d + j;
            }

            // index of the first element of the heap with children
            int firstNonLeaf(T[] items)
            {
                return (heapSize - 1) / this.d;
            }

            void Heapify(T[] items, int i)
            {
                int largest = DetermineLargestChild(items, i);

                if (largest != i)
                {
                    T temp = items[i];
                    items[i] = items[largest];
                    items[largest] = temp;

                    Heapify(items, largest);
                }
            }

            // here we're going to find the index of the largest child
            int DetermineLargestChild(T[] items, int i)
            {
                int largest = i;
                int CurrentChild = Child(i, 1);

                if (CurrentChild > this.heapSize)
                {
                    return i;
                }
                int j = 1;

                while (j <= this.d & CurrentChild <= this.heapSize)
                {
                    if (items[CurrentChild].CompareTo(items[largest]) > 0)
                    {
                        largest = CurrentChild;
                    }

                    j++;
                    CurrentChild = Child(i, j);
                }

                return largest;
            }
        }
	}
}