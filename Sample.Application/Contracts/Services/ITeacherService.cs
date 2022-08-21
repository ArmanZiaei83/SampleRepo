using System.Threading.Tasks;
using Sample.Application.DTOs;

namespace Sample.Application.Contracts.Services
{
    public interface ITeacherService
    {
        public Task<int> Add(AddTeacherDto dto);
    }
}