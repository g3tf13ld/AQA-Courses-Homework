using System;

namespace Homework4.Models
{
    public class BogoSort : AbstractSort
    {
        // Sorting check. 
        private static bool IsSorted(int[] array)
        {
            for (var i = 1; i < array.Length; i++)
            {
                if (array[i - 1] > array[i]) return false;
            }

            return true;
        }
        
        // Array "sorting".
        private static int[] RandomMixing(int[] array)
        {
            Random random = new Random();
            var i = array.Length;
            while (i > 1)
            {
                i--;
                var r = random.Next(i + 1);
                Swap(ref array[r], ref array[i]);
            }

            return array;
        }

        // Sorting.
        public static int[] Sort(int[] array)
        {
            var sortingTime = System.Diagnostics.Stopwatch.StartNew();
            sortingTime.Start();
            while(!IsSorted(array))
            {
                array = RandomMixing(array);
            }
            sortingTime.Stop();
            Console.WriteLine("BogoSort working time is " + sortingTime.ElapsedMilliseconds + " ms");
            
            return array;
        }
    }
}