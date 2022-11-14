using System;

namespace double_linked_list
{
    class node
    {
        /*Node class represent the node of doubly linked list.
        *it consist of the information part and links to
        *its succeeding and preceeding 
        *in terms of next and previous */
        public int noMhs;
        public string name;
        //point to the succeding node
        public node next;
        //point to the precceeding node
        public node prev;
    }

    class DoubleLinkedList
    {
        node START;

        //constructor
        public DoubleLinkedList()
        {
            START = null;
        }

        public void addnode()
        {
            int nim;
            string nm;
            Console.Write("\nEnter the roll number off the student: ");
            nim = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nEnter the name of student: ");
            nm = Console.ReadLine();
            node newNode = new node();
            newNode.noMhs = nim;
            newNode.name = nm;
        }
    }
    
}