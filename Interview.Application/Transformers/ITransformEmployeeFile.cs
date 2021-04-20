using Interview.Repository.Entities;
using System.Collections.Generic;

namespace Interview.Application.Transformers
{
    public interface ITransformEmployeeFile
    {
        IList<Employee> Transform(byte[] file);
    }
}
