using System;
using Homework3.Interfaces;

namespace Homework3.Models
{
    public class Employee : User
    {
        public Company Company;
        public override void DisplayInfo()
        {
            Console.WriteLine($"Hello, I am {FullName}, {Job.Title} in {Company.Name}" +
                              $" ({Company.Address}) and my salary {Job.Salary} ");
        }
    }
}