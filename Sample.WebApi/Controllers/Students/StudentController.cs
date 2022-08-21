using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sample.Application.Contracts.Services;
using Sample.Application.DTOs;

namespace Sample.WebApi.Controllers.Students
{
    [ApiController]
    [Route("api/students")]
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