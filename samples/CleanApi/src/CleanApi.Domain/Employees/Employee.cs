using CleanApi.Domain.Shared;

namespace CleanApi.Domain.Employees
{
    public class Employee : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Status Status { get; set; }
    }
}