using Microsoft.AspNetCore.Http;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace Interview.Api.Helpers
{
    [ExcludeFromCodeCoverage]
    public class FileConvertor : IFileConvertor
    {
        public byte[] Convert(IFormFile file)
        {
            byte[] fileBytes;
            using (var memStream = new MemoryStream())
            {
                file.CopyTo(memStream);
                fileBytes = memStream.ToArray();

                return fileBytes;
            }
        }
    }
}
