using System;
using Homework3.Interfaces;

namespace Homework3.Models
{
    public abstract class User : IInfoDisplayer
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => FirstName + " " + LastName;
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public int Salary { get; set; }
        
        public void DisplayInfo()
        {
            throw new NotImplementedException();
        }
    }
}