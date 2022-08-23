using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sample.Application.DTOs;
using Sample.Application.DTOs.Students;
using Sample.Application.Interfaces.Services;

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

        [HttpDelete]
        public async Task Delete(int id)
        {
            await _service.DeleteById(id);
        }
    }
}