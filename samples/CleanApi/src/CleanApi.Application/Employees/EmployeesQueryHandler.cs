using System.Collections.Generic;
using System.Threading.Tasks;
using CleanApi.Domain.Employees;
using CleanApi.Domain.Shared;

namespace CleanApi.Application.Employees
{
    public class EmployeesQueryHandler
    {
        private readonly IRepository<Employee> _employeeRepository;

        public EmployeesQueryHandler(IRepository<Employee> employeeRepository) =>
            _employeeRepository = employeeRepository;

        public async Task<IEnumerable<Employee>> Employees() =>
            await _employeeRepository.GetAsync(x => true).ConfigureAwait(false);
    }
}