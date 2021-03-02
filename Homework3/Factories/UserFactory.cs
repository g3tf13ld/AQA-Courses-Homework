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
                .RuleFor(p => p.Job, GetJob())
                .Generate(count);
        }
        
        public List<Employee> GetEmployee(int count = 1)
        {
            return new Faker<Employee>()
                .RuleFor(p => p.Id, f => f.Random.Guid())
                .RuleFor(p => p.FirstName, f => f.Name.FirstName())
                .RuleFor(p => p.LastName, f => f.Name.LastName())
                .RuleFor(p => p.Job, GetJob())
                .RuleFor(p => p.Company, GetCompany())
                .Generate(count);
        }

        private Company GetCompany()
        {
            return new Faker<Company>().Rules((faker, company) =>
            {
                company.Name = faker.Company.CompanyName();
                company.Country = faker.Address.Country();
                company.City = faker.Address.City();
                company.Street = faker.Address.StreetAddress();
            });
            
        }

        private Job GetJob()
        {
            return new Faker<Job>().Rules((faker, job) =>
            {
                job.Title = faker.Name.JobTitle();
                job.Description = faker.Name.JobDescriptor();
                job.Salary = faker.Random.Int(1000, 1000000);
            });
        }
    }
}