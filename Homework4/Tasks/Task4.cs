using System;
using Homework4.Models;

namespace Homework4.Tasks
{
    // Реализовать любые две сортировки из списка в лекции.
    
    public class Task4
    {
        public void Start()
        {
            var intArray1 = new CollectionGenerator().GenerateArray(10);
            int[] intArray2;
            var intArray3 = new CollectionGenerator().GenerateArray(10);
            int[] intArray4;
            var displayer = new CollectionDisplayer();

            Console.WriteLine("Task 4");
            // displayer.Display(intArray1);
            intArray2 = ShakerSort.Sort(intArray1);
            // displayer.Display(intArray2);

            // Console.WriteLine();
            // displayer.Display(intArray3);
            intArray4 = BogoSort.Sort(intArray3);
            // displayer.Display(intArray4);
            
        }
    }
}