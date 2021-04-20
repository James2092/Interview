using Interview.Repository.DapperRepository;
using Interview.Repository.Entities;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace Interview.Repository.Tests.EmployeeRepository
{
    [TestFixture]
    public class EmployeeRepositoryTests
    {
        private Mock<IRepository> _mockRepository;

        private Repository.EmployeeRepository.EmployeeRepository _repositoryUnderTest;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IRepository>();

            _repositoryUnderTest = new Repository.EmployeeRepository.EmployeeRepository(_mockRepository.Object);
        }

        [TestCase(3)]
        [TestCase(5)]
        [TestCase(10)]
        public void calls_repository_expected_number_of_times(int count)
        {
            // arrange
            var employees = CreateEmployeeList(count);

            // act
            _repositoryUnderTest.AddEmployees(employees);

            // assert
            _mockRepository.Verify(x => x.ExecuteStoredProcedure(It.IsAny<string>(), It.IsAny<object>()), Times.Exactly(count));
        }

        private List<Employee> CreateEmployeeList(int count)
        {
            var employees = new List<Employee>();

            for(int i = 0; i < count; i++)
            {
                employees.Add(new Employee());
            }

            return employees;
        }
    }
}
