using System;
using System.Threading.Tasks;
using CleanApi.Application.Employees;
using CleanApi.Domain.Employees;
using Microsoft.AspNetCore.Mvc;

namespace CleanApi.Api.Employees
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeesQueryHandler _employeesQueryHandler;
        private readonly AddEmployeeCommandHandler _addEmployeeCommandHandler;
        private readonly DeleteEmployeeCommandHandler _deleteEmployeeCommandHandler;

        public EmployeeController(EmployeesQueryHandler employeesQueryHandler,
            AddEmployeeCommandHandler addEmployeeCommandHandler,
            DeleteEmployeeCommandHandler deleteEmployeeCommandHandler)
        {
            _employeesQueryHandler = employeesQueryHandler;
            _addEmployeeCommandHandler = addEmployeeCommandHandler;
            _deleteEmployeeCommandHandler = deleteEmployeeCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await _employeesQueryHandler.Employees().ConfigureAwait(false);
            return new OkObjectResult(employees);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(Employee employee)
        {
            try
            {
                await _addEmployeeCommandHandler.Add(employee).ConfigureAwait(false);
                return new OkObjectResult("New employee added");
            }
            catch (Exception ex)
            {
                return new BadRequestResult();
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                await _deleteEmployeeCommandHandler.Delete(id).ConfigureAwait(false);
                return new OkObjectResult($"Employee with id {id} deleted.");
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult("Error deleting employee");
            }
        }
    }
}