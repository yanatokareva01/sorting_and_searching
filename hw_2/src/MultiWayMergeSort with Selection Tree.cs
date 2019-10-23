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

            int[] items;

            public class Node
            {
                public int Key { get; set; }
                public int run { get; private set; }

                public Node(int Key, int run)
                {
                    this.Key = Key;
                    this.run = run;
                }
            }

            public MultyWayMergeSort(int ways)
            {
                this.Ways = ways;
            }

            public void Sort(int [] items)
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
                int[] temp = new int[end - start + 1];
                // Creating lists for merging
                List<List<int>> merging = new List<List<int>>(Ways);
                List<int> tmp;
                int l, r;
                int j;

                for (int i = 0; i < Ways - 1 & i < temp.Length; i++)
                {
                    l = start + length * i;
                    r = start + length * i + length - 1;
                    tmp = new List<int>(length);
                    for (j = l; j < r + 1; j++)
                        tmp.Add(items[j]);
                    merging.Add(tmp);
                }
                if ((r = start + length * (Ways - 1)) <= end)
                {
                    tmp = new List<int>(end - r + 1);
                    for (j = r; j < end + 1; j++)
                        tmp.Add(items[j]);
                    merging.Add(tmp);
                }                
                
                // Build selection tree, extract root of the tree, while runs for merging exist
                j = 0;
                SelectionTree tree;
                int[] arr = new int[merging.Count];
                for (int i = 0; i < merging.Count; i++)
                {
                    arr[i] = merging[i][0];
                }
                tree = new SelectionTree(arr);
				
                Node node;
                int count = merging.Count;
                while (count != 0)
                {
                    node = tree.ExtractMax();
                    temp[j] = merging[node.run][0];
                    merging[node.run].RemoveAt(0);
					
                    if (merging[node.run].Count == 0)
                    {
                        count--;
                        tree.AddTo(node.run, int.MaxValue);
                    }
                    else
                        tree.AddTo(node.run, merging[node.run][0]);
                    j++;
                }

                j = 0;
                for (int i = start; i < end + 1; i++)
                {
                    items[i] = temp[j];
                    j++;
                }
            }

            public class SelectionTree
            {
                public Node[] arr;
                
                int maxValue = int.MaxValue;
                int realRuns;
                int runs;

                public SelectionTree(int[] items)
                {
                    realRuns = items.Length;
                    BuildTree(items);
                }

                public Node ExtractMax()
                {
                    return arr[0];
                }

                public void AddTo(int i, int key)
                {
                    int index = arr.Length - runs + i;
                    arr[index] = new Node(key, i);
                    if (parent(index) >= 0)
                        SiftUp(parent(index));
                }

                void SiftUp(int i)
                {
                    int largest = i;
                    int left = lChild(i);
                    int right = rChild(i);

                    if (arr[right].Key < arr[left].Key)
                        arr[i] = arr[right];
                    else
                        arr[i] = arr[left];
                    if (i != 0)
                        SiftUp(parent(i));
                }

                void BuildTree(int[] items)
                {
                    runs = findLengthForTree(realRuns);
                    arr = new Node[2 * runs - 1];

                    for (int i = 0; i < realRuns; i++)
                    {
                        arr[runs - 1 + i] = new Node(items[i], i);
                    }
                    for (int i = 0; i < runs - realRuns; i++)
                    {
                        arr[runs - 1 + realRuns + i] = new Node(maxValue, realRuns + i);
                    }

                    FillTree();
                }

                int findLengthForTree(int l)
                {
                    int length = 1;
                    l = l - 1;
                    while (l > 0)
                    {
                        l = l >> 1;
                        length = length * 2;
                    }
                    return length;
                }

                void FillTree()
                {
                    int pair = arr.Length - 2, i;
                    while (pair >= 1)
                    {
                        i = pair;

                        if (arr[i + 1].Key < (arr[i]).Key)
                            i++;

                        arr[parent(i)] = arr[i];
                        pair -= 2;
                    }
                }

                int parent(int i)
                {
                    return (i - 1) / 2;
                }

                int rChild(int i)
                {
                    return 2 * i + 2;
                }

                int lChild(int i)
                {
                    return 2 * i + 1;
                }
            }

        }
	}
}