using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3
{
    class Node
    {
        public int rollNumber;
        public string name;
        public Node next;
    }
    class CircularList
    {
        Node LAST;
        
        public CircularList()
        {
            LAST = null;
        }

        public void insertNode()
        {
            int nim;
            string nm;
            Console.WriteLine("\nEnter the roll number of the student: ");
            nim = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nEnter the name of the student");
            nm = Console.ReadLine();
            Node newNode = new Node();
            newNode.name = nm;
            newNode.rollNumber = nim;


            if (LAST == null || nim <= LAST.rollNumber)
            {
                if ((LAST != null) && (nim == LAST.rollNumber))
                {
                    Console.WriteLine();
                    return;
                }
                newNode.next = LAST;
                LAST = newNode;
                return;
            }
            Node previous, current;
            previous = LAST.next;
            current = LAST.next;

            while((current != null) && (nim >= current.rollNumber))
            {
                if(nim == current.rollNumber)
                {
                    Console.WriteLine();
                    return;
                }
                previous.next = current;
                previous.next = newNode;
            }
            newNode.next = LAST.next;
            LAST.next = newNode;
        }
        public bool deleteNode(int number)
        {
            Node previous, current;
            previous = current = null;
            if (Search(number, ref previous, ref current) == false)
                return false;
            if (number == LAST.next.rollNumber)
            {
                current = LAST.next;
                LAST.next = current.next;
                return true;
            }
            if (number == LAST.rollNumber)
            {
                current = LAST;
                previous = current.next;
                while (previous.next != LAST)
                    previous = previous.next;
                previous.next = LAST.next;
                LAST = previous;
                return true;
            }
            if (number <= LAST.rollNumber)
            {
                current = LAST.next;
                previous = LAST.next;
                while (number > current.rollNumber || previous == LAST)
                {
                    previous = current;
                    current = current.next;
                }
                previous.next = current.next;
            }
            return true;
        }

        public bool Search(int rollNo, ref Node previous, ref Node current)
        {
            for(previous = current = LAST.next; current != LAST; previous =
                current, current = current.next)
            {
                if(rollNo == current.rollNumber)
                    return(true);
            }
            if (rollNo == LAST.rollNumber)
                return true;
            else
                return (false);
        }
        public bool listEmpty()
        {
            if (LAST == null)
                return true;
            else
                return false;
        }

        public void traverse()
        {
            if (listEmpty())
                Console.WriteLine("\nList is empty");
            else
            {
                Console.WriteLine("\nREcord in the list are: \n");
                Node currentNode;
                currentNode = LAST.next;
                while(currentNode != LAST)
                {
                    Console.Write(currentNode.rollNumber + "    " +
                        currentNode.name + "\n");
                    currentNode = currentNode.next;
                }
                Console.Write(LAST.rollNumber + "    " + LAST.name + "\n");
            }
        }
        public void firstNode()
        {
            if (listEmpty())
                Console.WriteLine("\nList is empty");
            else
                Console.WriteLine("\nThe first record in the list is:\n\n" +
                    LAST.next.rollNumber + "    " + LAST.next.name);
        }
        
        static void Main(string[] args)
        {
            CircularList obj = new CircularList();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMenu");
                    Console.WriteLine("1. Add a record to the list");
                    Console.WriteLine("2. Delete a record in the list");
                    Console.WriteLine("3. View all records in the list");
                    Console.WriteLine("4. Search for a record in the list");
                    Console.WriteLine("5. Display the first record in the list");
                    Console.WriteLine("6. Exit\n");
                    Console.WriteLine("Enter your choice (1-6): ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.insertNode();
                            }
                            break;
                        case '2':
                            {
                                if (obj.listEmpty())
                                {
                                    Console.WriteLine("\nList is empty");
                                    break;
                                }
                                Console.WriteLine("Enter the roll number of the student" +
                                    "whose record is to be deleted: ");
                                int number = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (obj.deleteNode(number) == false)
                                    Console.WriteLine("record not found");
                                else
                                    Console.WriteLine("Record with the number" + number + "deleted\n");
                            }
                            break;
                        case '3':
                            {
                                obj.traverse();
                            }
                            break;
                        case '4':
                            {
                                if (obj.listEmpty() == true)
                                {
                                    Console.WriteLine("\nList is empty");
                                    break;
                                }
                                Node prev, curr;
                                prev = curr = null;
                                Console.Write("\nEnter the roll number of the student whose record you want to search: ");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (obj.Search(num, ref prev, ref curr) == false)
                                    Console.WriteLine("\nRecord not found");
                                else
                                {
                                    Console.WriteLine("\nRecord found");
                                    Console.WriteLine("\nRoll number: " + curr.rollNumber);
                                    Console.WriteLine("\nName: " + curr.name);
                                }
                            }
                            break;
                        case '5':
                            {
                                obj.firstNode();
                            }
                            break;
                        case '6':
                            return;
                        default:
                            {
                                Console.WriteLine("\nInvalid option");
                            }
                            break;
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }
    }
}
