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

            //check if the list empty 
            if (START == null || nim <= START.noMhs)
            {
                if ((START != null) && (nim == START.noMhs))
                {
                    Console.WriteLine("\nDuplicate Number not allowed");
                    return;
                }
                newNode.next = START;
                if (START != null)
                    START.prev = newNode;
                newNode.prev = null;
                return;
            }
            //if the node is to be inserted at between two node 
            node Previous, current;
            for (current = Previous = START;
                current != null && nim >= current.noMhs;
                Previous = current, current = current.next)
            {
                if (nim == current.noMhs)
                {
                    Console.WriteLine("\nDuplicate roll number not allowed");
                    return ;
                }
            }
            /*on the execution of the aboce for loop, prev and
             * * current will point to those nodes
             * * between wich the new node is to be insarted.*/
            newNode.next = current;
            newNode.prev = Previous;

            //if the node is to be insarted at the end of the list 
            if (current == null)
            {
                newNode.next = null;
                Previous.next = newNode;
                return ;
            }
            current.prev = newNode;
            Previous.next = newNode;
        }
        public bool search(int rollNo, ref node previous, ref node current)
        {
            for(previous = current = START; current != null &&
                rollNo != current.noMhs; previous = current,
                current = current.next) { }
            return (current != null);
        }
        public bool dellnode(int rollNo)
        {
            node previous, current;
            previous = current = null;
            if (search(rollNo, ref previous, ref current) == false)
                return false;
            //the begining of data 
            if (current.next == null)
            {
                previous.next = null;
                return true;
            }
            //node beetwen two node in in the list 
            if (current == START)
            {
                START = START.next;
                if (START != null)
                    START.prev = null;
                return true;
            }
            // if the to be the deleted is in beetwen the list the the following lines if is executed
            previous.next = current.next;
            current.next.prev = previous;
            return true;
        }
        public bool ListEmpety()
        {
            if (START == null)
                return true;
            else
            return false;

             
        }

        public void ascending()
        {
            if (ListEmpety())
                Console.WriteLine("\nList is empty");
            else
            {
                Console.WriteLine("\nRecord in the ascending order of" + "roll number are:\n");
                node currentNode;
                for (currentNode = START; currentNode != null; currentNode = currentNode.next)
                    Console.Write(currentNode.noMhs + "" + currentNode.name + "\n");
            }
        }
        public void descending ()
        {
            if (ListEmpety())
                Console.WriteLine("\n list is empty");
            else
                Console.WriteLine("\nRecord in the descending order of" + "roll number are: \n");
            node currentNode;
            for (currentNode = START; currentNode != null; currentNode = currentNode.next)
            { }

            while(currentNode != null)
            {
                Console.Write(currentNode.noMhs + "" + currentNode.name + "\n");
                currentNode = currentNode.prev;
            }
        }
    }

    class program
    {
        static void main(string[] args)
        {
            DoubleLinkedList obj = new DoubleLinkedList();
            while (true)
            {
               try
                {
                    Console.WriteLine("\nMenu");
                    Console.WriteLine("1. Add a record to the list");
                    Console.WriteLine("2. Delete a record from the list");
                    Console.WriteLine("3. View all record in the ascending order of roll number");
                    Console.WriteLine("4. view all record in the descending order of roll number");
                    Console.WriteLine("5. search for a record in the list");
                    Console.WriteLine("6. Exit\n");
                    Console.Write("Enter your chioce (1-6): ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.addnode();
                            }
                            break;
                        case '2':
                            {
                                if (obj.ListEmpety())
                                {
                                    Console.WriteLine("\nlist is empty");
                                    break;
                                }
                                Console.Write("\nEnter the roll number of the student" + "whose record is to be deleted: ");
                                int rollNo = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (obj.dellnode(rollNo) == false)
                                    Console.WriteLine("record not found");
                                else
                                    Console.WriteLine("Record with roll number" + rollNo + " deleted \n");
                            }
                            break;
                        case '3':
                            {
                                obj.ascending();
                            }
                            break;
                        case '4':
                            {
                                obj.descending();
                            }
                            break;
                    }
               } 
            }
        }
    }
}