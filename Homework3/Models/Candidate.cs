using System;
using Homework3.Interfaces;

namespace Homework3.Models
{
    public class Candidate : User, IInfoDisplayer
    {
        public void DisplayInfo()
        {
            Console.WriteLine($"Hello, I am {FullName}." +
                              $" I want to be a {JobTitle} ({JobDescription}) with a salary from {Salary}");
        }
    }
}