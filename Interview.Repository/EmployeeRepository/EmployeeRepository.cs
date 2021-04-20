using Interview.Repository.Entities;
using System.Collections.Generic;
using Dapper;
using Interview.Repository.DapperRepository;

namespace Interview.Repository.EmployeeRepository
{
    public class EmployeeRepository : IEmployeeRepository 
    {
        private readonly IRepository _repository;

        public EmployeeRepository(IRepository repository)
        {
            _repository = repository;
        }

        public void AddEmployees(IList<Employee> employees)
        {
            foreach(var employee in employees)
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Title", employee.Title);
                parameters.Add("@FirstName", employee.FirstName);
                parameters.Add("@LastName", employee.LastName);
                parameters.Add("@Sex", employee.Sex);
                parameters.Add("@DateOfBirth", employee.DateOfBirth);
                parameters.Add("@Email", employee.Email);
                parameters.Add("@Role", employee.Role);
                parameters.Add("@Salary", employee.Salary);

                _repository.ExecuteStoredProcedure("Emp.sp_AddEmployee", parameters);
            }         
        }
    }
}
