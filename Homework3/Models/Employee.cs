using System;
using Homework3.Interfaces;

namespace Homework3.Models
{
    public class Employee : User, IInfoDisplayer
    {
        public string CompanyName { get; set; }
        public string CompanyCountry { get; set; }
        public string CompanyCity { get; set; }
        public string CompanyStreet { get; set; }
        public string CompanyAddress => $"{CompanyCountry}, {CompanyCity}, {CompanyStreet}";
        
        public void DisplayInfo()
        {
            Console.WriteLine($"Hello, I am {FullName}, {JobTitle} in {CompanyName}" +
                              $" ({CompanyAddress}) and my salary {Salary} ");
        }
    }
}