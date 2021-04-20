using Interview.Repository.Entities;
using System.Collections.Generic;

namespace Interview.Repository.EmployeeRepository
{
    public interface IEmployeeRepository
    {
        public void AddEmployees(IList<Employee> employees);
    }
}
