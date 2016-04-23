using System;
using System.Diagnostics;

namespace Sorting
{
    public static class Sorts<T>
        where T : IComparable
    {
		public static class LeftistHeap
        {
            static Node leftistHeap;

            public static void Sort(T [] items)
            {
                Node node;
                for (int i = 0; i < items.Length; i++)
                {
                    node = new Node(items[i]);
                    AddNode(ref leftistHeap, ref node);
                }
                for (int i = 0; i < items.Length; i++)
                {
                    items[items.Length - 1 - i] = ExtractMax(ref leftistHeap);
                }
            }

            class Node
            {
                public T key { get; private set; }
                public int npl = 0;
                public Node parent;
                public Node lchild;
                public Node rchild;

                public Node(T key)
                {
                    this.key = key;
                }
            }

            static T ExtractMax(ref Node node)
            {
                T maxkey = node.key;
                if (node.rchild != null)
                {
                    node.lchild.parent = null;
                }
                if (node.rchild != null)
                {
                    node.rchild.parent = null;
                }
                node = Merge(ref node.lchild, ref node.rchild);
                return maxkey;
            }

            static Node Merge(ref Node node1, ref Node node2)
            {
                if (node1 == null)
                {
                    return node2;
                }

                if (node2 == null)
                {
                    return node1;
                }

                T H1 = node1.key;
                T H2 = node2.key;

                if (H1.CompareTo(H2) < 0)
                {
                    Swap(ref node1, ref node2);
                }

                node1.rchild = Merge(ref node1.rchild, ref node2);
                node1.rchild.parent = node1;

                if (Npl(node1.rchild) > Npl(node1.lchild))
                {
                    Swap(ref node1.rchild, ref node1.lchild);
                }
                node1.npl = Npl(node1);
                return node1;
            }

            static void Swap(ref Node node1, ref Node node2)
            {
                Node temp = node1;
                node1 = node2;
                node2 = temp;
            }

            static void AddNode(ref Node leftistHeap, ref Node node)
            {
                leftistHeap = Merge(ref leftistHeap, ref node);
            }

            static int Npl(Node node)
            {
                if (node == null)
                {
                    return -1;
                }
                if (node.rchild == null)
                {
                    return 0;
                }
                return node.rchild.npl + 1;
            }
        }
	}
}