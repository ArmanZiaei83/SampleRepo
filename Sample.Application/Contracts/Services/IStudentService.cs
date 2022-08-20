using System.Threading.Tasks;
using Sample.Application.ViewModel;

namespace Sample.Application.Contracts.Services
{
    public interface IStudentService
    {
        public Task<int> Add(AddStudentDto dto);
    }
}