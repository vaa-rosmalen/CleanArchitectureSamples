using System;
using System.Threading.Tasks;
using CleanApi.Domain.Employees;
using CleanApi.Domain.Shared;

namespace CleanApi.Application.Employees
{
    public class DeleteEmployeeCommandHandler
    {
        private readonly IRepository<Employee> _employeeRepository;

        public DeleteEmployeeCommandHandler(IRepository<Employee> employeeRepository) =>
            _employeeRepository = employeeRepository;

        public async Task Delete(int id)
        {
            if (id == 0) throw new ArgumentNullException();

            await _employeeRepository.DeleteAsync(id).ConfigureAwait(false);
        }
    }
}