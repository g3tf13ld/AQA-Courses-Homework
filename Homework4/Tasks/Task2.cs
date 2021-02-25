using System;
using System.Collections.Generic;
using Homework4.Models;

namespace Homework4.Tasks
{
    /*
     *  Дана последовательность из N различных целых чисел, занесённых в очередь.
     *  Найти сумму её членов расположенных между максимальным и минимальным значениями (в сумму включить и оба этих числа).
     */
    
    public class Task2
    {

        private int GetRangeMinMaxSum(Queue<int> queue)
        {
            var q = queue.ToArray();
            
            var sum = 0;
            int minIndex = 0, maxIndex = 0;

            for (var i = 1; i < q.Length; i++)
            {
                if (q[i] < q[minIndex])
                {
                    minIndex = i;
                }

                if (q[i] > q[maxIndex])
                {
                    maxIndex = i;
                }
            }

            Console.WriteLine($"Min = {q[minIndex]}");
            Console.WriteLine($"Max = {q[maxIndex]}");
            
            if (minIndex < maxIndex)
            {
                for (var i = minIndex; i <= maxIndex; i++)
                {
                    sum += q[i];
                }
            }
            else
            {
                for (var i = maxIndex; i <= minIndex; i++)
                {
                    sum += q[i];
                }
            }

            return sum;
        }
        
        public void Start()
        {
            var queue1 = new Queue<int>();
            var displayer = new CollectionDisplayer();
            queue1 = new CollectionGenerator().GenerateQueue(new Random().Next(5, 8));;
                
            Console.WriteLine("Task 2");
            Console.Write("Queue: ");
            displayer.Display(queue1);
            
            Console.WriteLine($"Sum of range between Min and Max : {GetRangeMinMaxSum(queue1)}");
            Console.WriteLine();
        }
    }
}