using Interview.Application.Models;
using Interview.Application.Transformers;
using Interview.Application.UseCases;
using Interview.Repository.DapperRepository;
using Interview.Repository.EmployeeRepository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace Interview.ConsoleApplication
{
    public class Program
    {
        static void Main(string[] args)
        {
            var provider = ConfigureServices();

            var fileLocation = args[0];

            var importEmployees = provider.GetService<IImportEmployees>();
            var result = importEmployees.Execute(new FileUpload { FileBytes = ConvertFile(fileLocation) } );

            Console.WriteLine("****************************************************");
            Console.WriteLine($"Employees successfully processed? - {result.Success}");
            Console.WriteLine($"With message - {result.Message}");
            Console.WriteLine("****************************************************");

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        private static ServiceProvider ConfigureServices()
        {
            return new ServiceCollection()
                .AddScoped<IImportEmployees, ImportEmployees>()
                .AddScoped<ITransformEmployeeFile, EmployeeCsvTransformer>()
                .AddScoped<IEmployeeRepository, EmployeeRepository>()
                .AddSingleton<IRepository, DapperRepository>()
                .AddSingleton<IConfiguration>(GetConfig())
                .AddLogging(configure => configure.AddConsole())
                .BuildServiceProvider();
        }

        private static IConfigurationRoot GetConfig()
        {
            return new ConfigurationBuilder()
               .AddJsonFile("appsettings.json")
               .Build();
        }

        private static byte[] ConvertFile(string fileLocation)
        {
            return System.IO.File.ReadAllBytes(fileLocation);
        }
    }
}
