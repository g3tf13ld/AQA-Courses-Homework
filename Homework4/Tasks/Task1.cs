using System;
using System.Collections.Generic;
using Homework4.Models;
using Microsoft.VisualBasic;

namespace Homework4.Tasks
{
    public class Task1
    {
        
        /*
         * Из двух заданных стеков, хранящих цифры, создать новый стек из тех цифр,
         *      которые есть и в первом и во втором стеке.
         */

        private Stack<int> GetUniqItemsStack(Stack<int> s1, Stack<int> s2)
        {
            Stack<int> result = new Stack<int>();
            int tempItem;
            if (s1.Count >= s2.Count)
            {
                while (s1.Count != 0)
                {
                    tempItem = s1.Pop();
                    if (s2.Contains(tempItem))
                    {
                        if (!result.Contains(tempItem)) result.Push(tempItem);
                    }
                }
            }
            else
            {
                while (s2.Count != 0)
                {
                    tempItem = s2.Pop();
                    if (s1.Contains(tempItem))
                    {
                        if (!result.Contains(tempItem))  result.Push(tempItem);
                    }
                }
            }

            return result;
        }
        
        public void Start()
        {
            var stack1 = new Stack<int>();
            var stack2 = new Stack<int>();
            var stack3 = new Stack<int>();
            var displayer = new CollectionDisplayer();
            
            Console.WriteLine("Task 1");
            stack1 = new CollectionGenerator().GenerateStack(new Random().Next(5, 8));
            stack2 = new CollectionGenerator().GenerateStack(new Random().Next(5, 8));

            Console.Write("Stack1: ");
            displayer.Display(stack1);
            Console.Write("Stack2: ");
            displayer.Display(stack2);
            
            stack3 = GetUniqItemsStack(stack1, stack2);

            Console.Write("Stack3: ");
            displayer.Display(stack3);
            Console.WriteLine();
        }
    }
}