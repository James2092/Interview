using Interview.Repository.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;

namespace Interview.Application.Transformers
{
    public class EmployeeCsvTransformer : ITransformEmployeeFile
    {
        private readonly ILogger<EmployeeCsvTransformer> _logger;
        public EmployeeCsvTransformer(ILogger<EmployeeCsvTransformer> logger)
        {
            _logger = logger;
        }
        public IList<Employee> Transform(byte[] file)
        {
            List<Employee> employees = new List<Employee>();

            try
            {
                using var memoryStream = new MemoryStream(file);
                using (var reader = new StreamReader(memoryStream))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(",");

                        employees.Add(new Employee
                        {
                            Title = values[0],
                            FirstName = values[1],
                            LastName = values[2],
                            Sex = values[3],
                            DateOfBirth = values[4],
                            Email = values[5],
                            Role = values[6],
                            Salary = values[7]
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"[EmployeeCsvTransformer] An error occured whilst transforming the csv file. Message - {ex.Message}");

                throw new InvalidDataException(ex.Message);
            }

            _logger.LogInformation($"[EmployeeCsvTransformer] Successfully transformed file with {employees.Count} entities.");

            return employees;
        }
    }
}
