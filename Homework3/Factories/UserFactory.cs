using System.Collections.Generic;
using Bogus;
using Homework3.Models;

namespace Homework3.Factories
{
    public class UserFactory
    {
        public List<Candidate> GetCandidates(int count = 1)
        {
            return new Faker<Candidate>()
                .RuleFor(p => p.Id, f => f.Random.Guid())
                .RuleFor(p => p.FirstName, f => f.Name.FirstName())
                .RuleFor(p => p.LastName, f => f.Name.LastName())
                .RuleFor(p => p.JobTitle, f => f.Name.JobTitle())
                .RuleFor(p => p.JobDescription, f => f.Name.JobDescriptor())
                .RuleFor(p => p.Salary, f => f.Random.Int(1000, 1000000))
                .Generate(count);
        }
        
        public List<Employee> GetEmployee(int count = 1)
        {
            return new Faker<Employee>()
                .RuleFor(p => p.Id, f => f.Random.Guid())
                .RuleFor(p => p.FirstName, f => f.Name.FirstName())
                .RuleFor(p => p.LastName, f => f.Name.LastName())
                .RuleFor(p => p.JobTitle, f => f.Name.JobTitle())
                .RuleFor(p => p.JobDescription, f => f.Name.JobDescriptor())
                .RuleFor(p => p.Salary, f => f.Random.Int(1000, 1000000))
                .RuleFor(p => p.CompanyName, f => f.Company.CompanyName())
                .RuleFor(p => p.CompanyCountry, f => f.Address.Country())
                .RuleFor(p => p.CompanyCity, f => f.Address.City())
                .RuleFor(p => p.CompanyStreet, f => f.Address.StreetAddress())
                .Generate(count);
        }
    }
}