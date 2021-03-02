using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homework3.Models
{
    public class EmployeeReportGenerator
    {
        private List<Employee> Employees { get; set; }

        public EmployeeReportGenerator(List<Employee> employees)
        {
            this.Employees = employees;
        }
         
        private void Sort()
        {
            var temp = from employee in Employees
                                        orderby employee.Company.Name, employee.Job.Salary descending
                                        select employee;
            Employees = temp.ToList();
        }

        public void Report()
        {
            Sort();
            // The longest Name, FullName and Salary in the Employees list.
            var symbolCounter1 = 12;
            var symbolCounter2 = 18;
            var symbolCounter3 = 6;
            
            // The longest Name, FullName and Salary value finding.
            foreach (var employee in Employees)
            {
                if (employee.Company.Name.Length > symbolCounter1)
                {
                    symbolCounter1 = employee.Company.Name.Length;
                }
                if (employee.FullName.Length > symbolCounter2)
                {
                    symbolCounter2 = employee.FullName.Length;
                }
                if (employee.Job.Salary.ToString().Length > symbolCounter2)
                {
                    symbolCounter3 = employee.Job.Salary.ToString().Length;
                }
            }

            // Report printing start.
            // Report table header.
            Console.WriteLine("Employee Report");
            var stringBuilder = new StringBuilder();
            Console.WriteLine(stringBuilder.Insert(0, "_", 58 + symbolCounter1 + symbolCounter2).ToString());
            stringBuilder.Clear();
            stringBuilder.Append("|                  Id                  ||");
            if (symbolCounter1 <= "Company Name".Length)
            {
                stringBuilder.Append(" Company Name ||");
            }
            else
            {
                stringBuilder.Append(" Company Name ")
                    .Insert(stringBuilder.Length, " ", symbolCounter1 - 12)
                    .Append("||");
            }
            if (symbolCounter2 <= "Employee Full Name".Length)
            {
                stringBuilder.Append(" Employee Full Name ||");
            }
            else
            {
                stringBuilder.Append(" Employee Full Name ")
                    .Insert(stringBuilder.Length, " ", symbolCounter2 - 18)
                    .Append("||");
            }

            stringBuilder.Append(" Salary |");
            Console.WriteLine(stringBuilder.ToString());
            
            // Report body.
            foreach (var employee in Employees)
            {
                stringBuilder.Clear();
                stringBuilder.Append("| " + employee.Id + " || ");
                
                stringBuilder.Append(employee.Company.Name)
                    .Insert(stringBuilder.Length, " ",  symbolCounter1 - employee.Company.Name.Length)
                    .Append(" || ");
                
                stringBuilder.Append(employee.FullName)
                    .Insert(stringBuilder.Length, " ", symbolCounter2 - employee.FullName.Length)
                    .Append(" || "); 
                
                stringBuilder.Append(employee.Job.Salary)
                    .Insert(stringBuilder.Length, " ", symbolCounter3 - employee.Job.Salary.ToString().Length)
                    .Append(" |");
                
                Console.WriteLine(stringBuilder.ToString());
            }

            Console.WriteLine(stringBuilder.Clear().Insert(0, "-", 58 + symbolCounter1 + symbolCounter2).ToString());
        }
    }
}