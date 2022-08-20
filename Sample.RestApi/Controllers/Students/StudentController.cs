using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sample.Application.Contracts.Services;
using Sample.Application.ViewModel;

namespace Sample.RestApi.Controllers.Students
{
    [ApiController]
    [Route("[controller]/students")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentController(IStudentService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<int> Add(AddStudentDto dto)
        {
            return await _service.Add(dto);
        }
    }
}