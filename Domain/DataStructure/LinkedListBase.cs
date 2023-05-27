using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.DataStructure
{
    public class LinkedListBase
    {
        public Node Head { get; private set; }

        public void AddNode(Node node)
        {
            if (Head == null)
            {
                Head = new Node();
                Head.data = node.data;
                return;
            }

            Node temp = Head;
            while (temp.Next != null)
            {
                temp = temp.Next;
            }

            temp.Next = node;
        }

        public void PrintNodes()
        {
            if (Head == null)
            {
                Console.WriteLine("There is no Node to display");
                return;
            }

            var temp = Head;
            while (temp.Next != null)
            {
                Console.WriteLine(string.Concat($" -> {temp.data}"));
                temp = temp.Next;

                if (temp.Next == null)
                    Console.WriteLine(string.Concat($" -> {temp.data}"));
            }
        }

        public void AddRecursive(Node node)
        {
            Head = AddRecursivitly(Head, node.data);
        }

        public Node AddRecursivitly(Node head, int _data)
        {
            if (head == null)
                head = new Node() { data = _data };
            else
                head.Next = AddRecursivitly(head.Next, _data);

            return head;
        }

        public void RemoveNode(int node)
        {
            if (Head != null && Head.data == node)
            {
                Head = Head.Next;
                return;
            }

            if (Head == null) return;

            //Node temp = Head;
            Node prev = Head;
            //while (temp.Next != null && temp.data != node) 
            //{
            //    prev = temp;
            //    temp = temp.Next;
            //}

            //if (temp == null)
            //{
            //    return;
            //}

            //prev.Next = temp.Next;

            prev = RemoveNodeRecursive(Head, node);

        }

        /// <summary>
        /// Remove recursivetly
        /// </summary>
        /// <param name="head"></param>
        /// <param name="node"></param>
        /// <returns></returns>
        public Node RemoveNodeRecursive(Node head, int node)
        {
            Node temp = head;
            Node prev = head;
            if (temp.data != node)
                temp = temp.Next;
            else
                prev = RemoveNodeRecursive(temp.Next, node);

            prev.Next = temp.Next;

            return prev;
        }

    }

    public class Node
    {
        public int data { get; set; }
        public Node Next { get; set; }

    }
}
