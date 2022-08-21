using System.Threading.Tasks;
using Sample.Application.DTOs;

namespace Sample.Application.Contracts.Services
{
    public interface ITeacherService : IService
    {
        public Task<int> Add(AddTeacherDto dto);
    }
}