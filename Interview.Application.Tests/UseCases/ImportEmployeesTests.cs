using NUnit.Framework;
using Moq;
using Interview.Application.Transformers;
using Interview.Application.UseCases;
using Interview.Repository.EmployeeRepository;
using Interview.Repository.Entities;
using System;
using System.Collections.Generic;
using Interview.Application.Models;

namespace Interview.Application.Tests.UseCases
{
    [TestFixture]
    public class ImportEmployeesTests
    {
        private Mock<ITransformEmployeeFile> _stubTransformRepository;
        private Mock<IEmployeeRepository> _stubEmployeeRepository;

        private ImportEmployees _useCaseUnderTest;

        [SetUp]
        public void Setup()
        {
            _stubTransformRepository = new Mock<ITransformEmployeeFile>();
            _stubEmployeeRepository = new Mock<IEmployeeRepository>();

            _useCaseUnderTest = new ImportEmployees(_stubTransformRepository.Object, _stubEmployeeRepository.Object);
        }

        [Test]
        public void returns_false_if_file_transformation_fails()
        {
            // arrange
            _stubTransformRepository.Setup(x => x.Transform(It.IsAny<byte[]>())).Throws(new Exception());

            // act
            var result = _useCaseUnderTest.Execute(new FileUpload());

            // assert
            Assert.IsFalse(result.Success);
        }

        [Test]
        public void returns_false_if_employee_repository_throws_an_exception()
        {
            // arrange
            _stubTransformRepository.Setup(x => x.Transform(It.IsAny<byte[]>())).Returns(new List<Employee>());
            _stubEmployeeRepository.Setup(x => x.AddEmployees(It.IsAny<List<Employee>>())).Throws(new Exception());

            // act
            var result = _useCaseUnderTest.Execute(new FileUpload());

            // assert
            Assert.IsFalse(result.Success);
        }

        [Test]
        public void returns_true()
        {
            // arrange
            _stubTransformRepository.Setup(x => x.Transform(It.IsAny<byte[]>())).Returns(new List<Employee>());

            // act
            var result = _useCaseUnderTest.Execute(new FileUpload());

            // assert
            Assert.IsTrue(result.Success);
        }
    }
}
