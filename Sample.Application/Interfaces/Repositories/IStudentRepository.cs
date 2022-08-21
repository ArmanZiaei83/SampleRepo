using Sample.Domain.Entities;

namespace Sample.Application.Interfaces.Repositories
{
    public interface IStudentRepository : IRepository
    {
        public void Add(Student student);
    }
}