using System;
using System.Diagnostics;

namespace Sorting
{
    public static class Sorts<T>
        where T : IComparable
    {
		public class Heap
        {
            private int HeapSize;

            public void HeapSort(T[] items)
            {
                HeapSize = items.Length - 1;

                BuildHeap(items);

                for (int i = items.Length - 1; i >= 1; i--)
                {
                    T temp = items[0];
                    items[0] = items[i];
                    items[i] = temp;

                    HeapSize--;
                    Heapify(items, 0);
                }
            }

            void BuildHeap(T [] items)
            {
                for (int i = items.Length/2; i >= 0; i--)
                {
                    Heapify(items, i);
                }
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

            private int DetermineLargestChild(T [] items, int i)
            {
                int largest;
                int l = Left(i);
                int r = Right(i);

                // Determine which child to swap with.
                if ((l <= HeapSize) && (items[l].CompareTo(items[i]) > 0))
                {
                    // Left child has the largest value.
                    largest = l;
                }
                else
                {
                    // Parent has the largest value.
                    largest = i;
                }

                if ((r <= HeapSize) && (items[r].CompareTo(items[largest]) > 0))
                {
                    // Right child has the largest value.
                    largest = r;
                }

                return largest;
            }

            private int Parent(int i)
            {
                return i >> 1;
            }

            private int Left(int i)
            {
                return (i << 1);
            }

            private int Right(int i)
            {
                return (i << 1) + 1;
            }
        }
	}
}