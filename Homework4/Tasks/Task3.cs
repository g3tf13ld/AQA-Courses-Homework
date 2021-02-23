using System;
using System.Collections.Generic;

namespace Homework4.Tasks
{
    /*
     * В кругу стоят N человек, пронумерованных от 1 до N.
     * При ведении счета по кругу вычёркивается каждый второй человек, пока не останется один.
     * Составить программу, моделирующую процесс.
     */
    
    public class Task3
    {

        private LinkedList<int> getLinkedList(int count = 1)
        {
            var linkedList = new LinkedList<int>();
            for (var i = 1; i <= count; i++)
            {
                linkedList.AddLast(i);
            }
            return linkedList;
        }
        
        private void LinkedListDisplay(LinkedList<int> linkedList)
        {
            foreach (var item in linkedList)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        private void Deletion(LinkedList<int> linkedList)
        {
            LinkedListDisplay(linkedList);
            var curItem = linkedList.First;
            while (linkedList.Count != 1)
            {
                linkedList.Remove(curItem.Next ?? linkedList.First);
                LinkedListDisplay(linkedList);
                curItem = curItem.Next ?? linkedList.First;
            }
        }

        public void Start()
        {
            Console.WriteLine("Task 3");
            var linkedList = getLinkedList(13);
            Deletion(linkedList);
            Console.WriteLine();
        }
    }
}