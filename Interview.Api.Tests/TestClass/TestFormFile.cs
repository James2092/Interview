using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Interview.Api.Tests.TestClass
{
    public class TestFormFile : IFormFile 
    {
        public string ContentDisposition => throw new System.NotImplementedException();

        public string ContentType => throw new System.NotImplementedException();

        public string FileName => throw new System.NotImplementedException();

        public IHeaderDictionary Headers => throw new System.NotImplementedException();

        public long Length => throw new System.NotImplementedException();

        public string Name => throw new System.NotImplementedException();

        public void CopyTo(Stream target)
        {
            throw new System.NotImplementedException();
        }

        public Task CopyToAsync(Stream target, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Stream OpenReadStream()
        {
            throw new System.NotImplementedException();
        }
    }
}
