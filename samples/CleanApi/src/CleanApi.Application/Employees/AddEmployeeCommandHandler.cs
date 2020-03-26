using System;
using System.Threading.Tasks;
using CleanApi.Domain.Employees;
using CleanApi.Domain.Shared;

namespace CleanApi.Application.Employees
{
    public class AddEmployeeCommandHandler
    {
        private readonly IRepository<Employee> _employeeRepository;

        public AddEmployeeCommandHandler(IRepository<Employee> employeeRepository) =>
            _employeeRepository = employeeRepository;

        public async Task Add(Employee employee)
        {
            if(employee == null) throw new ArgumentNullException(nameof(employee));

            await _employeeRepository.InsertAsync(employee).ConfigureAwait(false);
        }
    }
}