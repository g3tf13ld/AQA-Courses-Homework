using System;
using Homework3.Interfaces;

namespace Homework3.Models
{
    public class Candidate : User
    {
        public override void DisplayInfo()
        {
            Console.WriteLine($"Hello, I am {FullName}." +
                              $" I want to be a {Job.Title} ({Job.Description}) with a salary from {Job.Salary}");
        }
    }
}