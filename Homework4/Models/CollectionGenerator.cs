using System;
using System.Collections.Generic;

namespace Homework4.Models
{
    public class CollectionGenerator
    {
        public int[] GenerateArray(int count = 1)
        {
            return GenerateArray(0, 9, count);
        }
        
        public int[] GenerateArray(int bottomBound, int topBound, int count = 1)
        {
            var generatedArray = new int[count];
            for (var i = 0; i < count; i++)
            {
                generatedArray[i] = new Random().Next(bottomBound, topBound);
            }

            return generatedArray;
        }

        public Stack<int> GenerateStack(int bottomBound, int topBound, int count = 1)
        {
            return new Stack<int>(GenerateArray(bottomBound, topBound, count));
        }

        public Stack<int> GenerateStack(int count = 1)
        {
            return new Stack<int>(GenerateArray(0, 9, count));
        }
        
        public Queue<int> GenerateQueue(int bottomBound, int topBound, int count = 1)
        {
            return new Queue<int>(GenerateArray(bottomBound, topBound, count));
        }
        
        public Queue<int> GenerateQueue(int count = 1)
        {
            return new Queue<int>(GenerateArray(0, 9, count));
        }
    }
}