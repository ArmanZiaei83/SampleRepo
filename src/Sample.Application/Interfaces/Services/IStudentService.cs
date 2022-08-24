using System.Threading.Tasks;
using Sample.Application.DTOs;
using Sample.Application.DTOs.Students;

namespace Sample.Application.Interfaces.Services
{
    public interface IStudentService : IService
    {
        public Task<int> Add(AddStudentDto dto);
        Task DeleteById(int id);
    }
}