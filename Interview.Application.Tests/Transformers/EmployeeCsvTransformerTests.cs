using Interview.Application.Transformers;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System.IO;
using System.Linq;
using System.Text;

namespace Interview.Application.Tests.Transformers
{
    [TestFixture]
    public class EmployeeCsvTransformerTests
    {
        private Mock<ILogger<EmployeeCsvTransformer>> _stubLogger;

        private EmployeeCsvTransformer _transformerUnderTest;



        [SetUp]
        public void Setup()
        {
            _stubLogger = new Mock<ILogger<EmployeeCsvTransformer>>();

            _transformerUnderTest = new EmployeeCsvTransformer(_stubLogger.Object);
        }

        [Test]
        public void returns_an_employee()
        {
            // arrange
            var csvString = "Dr,Elton,Lyte,M,10/25/1968,elyte0@icq.com,Safety Technician III ,23945.00";

            var bytes = Encoding.ASCII.GetBytes(csvString);

            // act
            var result = _transformerUnderTest.Transform(bytes);

            // assert
            Assert.IsTrue(result.Any());
        }

        [Test]
        public void throws_invalid_data_exception()
        {
            // arrange
            var csvString = "Dr,Elton,Lyte,M,10/25/1968,elyte0@icq.com,Safety Technician III";

            var bytes = Encoding.ASCII.GetBytes(csvString);

            // act
            Assert.Throws<InvalidDataException>(() => _transformerUnderTest.Transform(bytes));
        }
    }
}
