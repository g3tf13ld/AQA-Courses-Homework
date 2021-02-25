using System;
using System.Collections.Generic;
using Homework4.Models;

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
        
        private void Deletion(LinkedList<int> linkedList)
        {
            var displayer = new CollectionDisplayer();
            displayer.Display(linkedList);
            var curItem = linkedList.First;
            while (linkedList.Count != 1)
            {
                linkedList.Remove(curItem.Next ?? linkedList.First);
                displayer.Display(linkedList);
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