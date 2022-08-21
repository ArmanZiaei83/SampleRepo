using System.Threading.Tasks;
using Sample.Domain;
using Sample.Domain.Entities;

namespace Sample.Application.Contracts.Repositories
{
    public interface IStudentRepository
    {
        public void Add(Student student);
        public Task Save();
    }
}