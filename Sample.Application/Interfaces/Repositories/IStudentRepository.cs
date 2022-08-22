using System.Threading.Tasks;
using Sample.Application.Students;
using Sample.Domain.Entities;

namespace Sample.Application.Interfaces.Repositories
{
    public interface IStudentRepository : IRepository
    {
        public void Add(Student student);
        void DeleteById(Student student);
        ValueTask<Student?> Find(int id);
    }
}