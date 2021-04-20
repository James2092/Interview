using Interview.Application.Models;
using Interview.Application.Transformers;
using Interview.Repository.EmployeeRepository;
using System;
using System.IO;

namespace Interview.Application.UseCases
{
    public class ImportEmployees: IImportEmployees
    {
        private ITransformEmployeeFile _transformFile;
        private IEmployeeRepository _employeeRepository;


        public ImportEmployees(ITransformEmployeeFile transformFile, IEmployeeRepository employeeRepository)
        {
            _transformFile = transformFile;
            _employeeRepository = employeeRepository;
        }

        public FileUploadResult Execute(FileUpload file)
        {
            var result = new FileUploadResult();

            try
            {
                var employees = _transformFile.Transform(file.FileBytes);

                _employeeRepository.AddEmployees(employees);

                result.Success = true;
                result.Message = "Successfully uploaded employees";
            }
            catch(InvalidDataException)
            {
                result.Success = false;
                result.Message = "Invalid file";
            }
            catch (Exception)
            {
                result.Success = false;
                result.Message = "Something went wrong";
            }


            return result;
        }
    }
}
