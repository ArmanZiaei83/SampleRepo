using System.Threading.Tasks;
using Sample.Application.DTOs;
using Sample.Application.DTOs.Teachers;

namespace Sample.Application.Interfaces.Services
{
    public interface ITeacherService : IService
    {
        public Task<int> Add(AddTeacherDto dto);
    }
}