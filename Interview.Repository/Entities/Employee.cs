using System;
namespace Interview.Repository.Entities
{
    public class Employee
    {
        public Employee()
        {

        }

        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }
        public string DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Salary { get; set; }
    }
}
