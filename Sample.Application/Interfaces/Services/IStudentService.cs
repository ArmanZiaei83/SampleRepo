using System.Threading.Tasks;
using Sample.Application.DTOs;

namespace Sample.Application.Interfaces.Services
{
    public interface IStudentService : IService
    {
        public Task<int> Add(AddStudentDto dto);
    }
}