using Interview.Application.UseCases;
using Interview.Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Interview.Api.Helpers;

namespace Interview.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromForm]IFormFile file, [FromServices] IFileConvertor fileConvertor, [FromServices] IImportEmployees importEmployees)
        {
            var result = importEmployees.Execute(new FileUpload() { FileBytes = fileConvertor.Convert(file) });
           
            if (result.Success)
                return Ok(result.Message);

            return BadRequest(result.Message);
        }
    }
}
