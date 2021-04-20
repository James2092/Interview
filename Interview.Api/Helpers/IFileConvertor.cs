using Microsoft.AspNetCore.Http;

namespace Interview.Api.Helpers
{
    public interface IFileConvertor
    {
        byte[] Convert(IFormFile file);
    }
}
