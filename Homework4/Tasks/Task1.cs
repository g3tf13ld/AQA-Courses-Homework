using System;
using System.Collections.Generic;

namespace Homework4.Tasks
{
    public class Task1
    {
        
        /*
         * Из двух заданных стеков, хранящих цифры, создать новый стек из тех цифр,
         *      которые есть и в первом и во втором стеке.
         */
        
        private Stack<int> RandomIntStackInit(Stack<int> stack, int count = 1)
        {
            for (var i = 0; i < count; i++)
            {
                stack.Push(new Random().Next(0, 9));
            }

            return stack;
        }

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

        private void StackDisplay(Stack<int> stack)
        {
            foreach (var s in stack)
            {
                Console.Write(s + " ");
            }
            Console.WriteLine();
        }
        
        public void Start()
        {
            var stack1 = new Stack<int>();
            var stack2 = new Stack<int>();
            var stack3 = new Stack<int>();
            
            Console.WriteLine("Task 1");
            stack1 = RandomIntStackInit(stack1, new Random().Next(5, 8));
            stack2 = RandomIntStackInit(stack2, new Random().Next(5, 8));

            Console.Write("Stack1: ");
            StackDisplay(stack1);
            Console.Write("Stack2: ");
            StackDisplay(stack2);
            
            stack3 = GetUniqItemsStack(stack1, stack2);

            Console.Write("Stack3: ");
            StackDisplay(stack3);
            Console.WriteLine();
        }
    }
}