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
        public Job Job;
        
        public abstract void DisplayInfo();
    }
}