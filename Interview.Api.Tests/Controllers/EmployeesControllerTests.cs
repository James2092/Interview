using Interview.Api.Controllers;
using Interview.Api.Helpers;
using Interview.Api.Tests.TestClass;
using Interview.Application.Models;
using Interview.Application.UseCases;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace Interview.Api.Tests.Controllers
{
    [TestFixture]
    public class EmployeesControllerTests
    {
        private Mock<IImportEmployees> _stubImportEmployees;
        private Mock<IFileConvertor> _stubFileConvertor;

        private EmployeesController _controllerUnderTest;

        [SetUp]
        public void Setup()
        {
            _stubImportEmployees = new Mock<IImportEmployees>();
            _stubFileConvertor = new Mock<IFileConvertor>();

            _controllerUnderTest = new EmployeesController();
        }

        [Test]
        public void results_Ok_if_successful()
        {
            // arrange
            _stubImportEmployees.Setup(x => x.Execute(It.IsAny<FileUpload>())).Returns(new FileUploadResult() { Success = true });

            // act
            var result = _controllerUnderTest.Post(new TestFormFile(), _stubFileConvertor.Object, _stubImportEmployees.Object);

            // assert
            Assert.IsInstanceOf(typeof(OkObjectResult), result);
        }

        [Test]
        public void returns_bad_request_if_unsuccessful()
        {
            // arrange
            _stubImportEmployees.Setup(x => x.Execute(It.IsAny<FileUpload>())).Returns(new FileUploadResult() { Success = false });

            // act
            var result = _controllerUnderTest.Post(new TestFormFile(), _stubFileConvertor.Object, _stubImportEmployees.Object);

            // assert
            Assert.IsInstanceOf(typeof(BadRequestObjectResult), result);
        }
    }
}
