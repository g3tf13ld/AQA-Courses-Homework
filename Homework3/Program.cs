using Bogus;
using Homework3.Factories;
using Homework3.Models;

namespace Homework3
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new UserFactory();
            var candidates = factory.GetCandidates(new Faker().Random.Int(8, 15));
            var employees =  factory.GetEmployee(new Faker().Random.Int(8, 15));
            
            var employeeReportGenerator = new EmployeeReportGenerator(employees);
            employeeReportGenerator.Report();

            var candidateReportGenerator = new СandidateReportGenerator(candidates);
            candidateReportGenerator.Report();

        }
    }
}