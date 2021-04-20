using Interview.Application.Models;

namespace Interview.Application.UseCases
{
    public interface IImportEmployees
    {
        FileUploadResult Execute(FileUpload file);
    }
}
