using System;
using System.Collections;

namespace Homework4.Models
{
    public class CollectionDisplayer
    {
        public void Display(IEnumerable enumerable)
        {
            foreach (var item in enumerable)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}