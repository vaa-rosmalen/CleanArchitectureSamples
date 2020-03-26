using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Bogus;
using CleanApi.Domain.Employees;
using CleanApi.Domain.Shared;

namespace CleanApi.Infrastructure.Employees
{
    public class EmployeeRepository : IRepository<Employee>
    {
        public async Task<IEnumerable<Employee>> GetAsync(Expression<Func<Employee, bool>> predicate)
        {
            var i = 1;
            return new Faker<Employee>()
                .RuleFor(x => x.Id, faker => i++)
                .RuleFor(x => x.FirstName, faker => faker.Person.FirstName)
                .RuleFor(x => x.LastName, faker => faker.Person.LastName)
                .RuleFor(x => x.Status, faker => faker.PickRandom<Status>())
                .Generate(20);
        }

        public Task<int> CountAsync(Expression<Func<Employee, bool>> predicate) => throw new NotImplementedException();

        public Task<Employee> SingleItemAsync(Expression<Func<Employee, bool>> predicate) => throw new NotImplementedException();

        public Task InsertAsync(Employee entity) => Task.FromResult(true); // fake implementation!

        public Task UpdateAsync(Employee entity) => throw new NotImplementedException();

        public Task InsertOrUpdateAsync(Employee entity) => throw new NotImplementedException();
        public Task DeleteAsync(int id) => throw new NotImplementedException();
    }
}