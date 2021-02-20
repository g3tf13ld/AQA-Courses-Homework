using System;

namespace Homework3.Models
{
    public interface IDisplay
    {
        void Display(Person p)
        {
            Console.WriteLine($"{p.Salary} {p.FullName}");
        }
    }
}