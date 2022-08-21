using System.Threading.Tasks;
using Sample.Application.DTOs;

namespace Sample.Application.Interfaces.Services
{
    public interface ITeacherService : IService
    {
        public Task<int> Add(AddTeacherDto dto);
    }
}