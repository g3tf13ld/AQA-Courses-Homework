using System;
using Homework4.Models;

namespace Homework4.Tasks
{
    // Реализовать любые две сортировки из списка в лекции.
    
    public class Task4
    {
        private int[] GetRandomArray(int count = 1)
        {
            var arr = new int[count];
            for (var i = 0; i < count; i++)
            {
                arr[i] = new Random().Next(-1000, 1000);
            }

            return arr;
        }

        private void ArrayDisplay(int[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
        
        public void Start()
        {
            var intArray1 = GetRandomArray(10000);
            int[] intArray2;
            var intArray3 = GetRandomArray(10);
            int[] intArray4;
            
            //ArrayDisplay(intArray1);
            intArray2 = ShakerSort.Sort(intArray1);
            //ArrayDisplay(intArray2);
            
            //ArrayDisplay(intArray3);
            intArray4 = BogoSort.Sort(intArray3);
            //ArrayDisplay(intArray4);
            
        }
    }
}