using System.Threading.Tasks;
using Sample.Domain;

namespace Sample.Application.Contracts.Repositories
{
    public interface IStudentRepository
    {
        public void Add(Student student);
        public Task Save();
    }
}