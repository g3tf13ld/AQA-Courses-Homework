using System;

namespace Homework4.Models
{
    public class ShakerSort : AbstractSort
    {
        public static int[] Sort(int[] array)
        {
            var flag = false;
            var sortingTime = System.Diagnostics.Stopwatch.StartNew();
            sortingTime.Start();
            for (var i = 0; i < array.Length / 2; i++)
            {
                // From left to right checking.
                for (var j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        Swap(ref array[j], ref array[j + 1]);
                        flag = true;
                    }
                }
                
                // From right to left checking.
                for (var j = array.Length - 2 - i; j > i; j--)
                {
                    if (array[j - 1] > array[j])
                    {
                        Swap(ref array[j], ref array[j - 1]);
                        flag = true;
                    }
                }
                
                // Breaking the main cycle in case of swap absence.
                if (!flag) break;
            }

            sortingTime.Stop();
            Console.WriteLine("ShakerSort working time is " + sortingTime.ElapsedMilliseconds + " ms");
            
            return array;
        }
    }
}