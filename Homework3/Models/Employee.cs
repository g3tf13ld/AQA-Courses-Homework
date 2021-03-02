using System;
using Homework3.Interfaces;

namespace Homework3.Models
{
    public class Employee : User, IInfoDisplayer
    {
        public Company Company;
        public void DisplayInfo()
        {
            Console.WriteLine($"Hello, I am {FullName}, {Job.Title} in {Company.Name}" +
                              $" ({Company.Address}) and my salary {Job.Salary} ");
        }
    }
}