using Sample.Domain.Entities;

namespace Sample.Application.Contracts.Repositories
{
    public interface IStudentRepository : IRepository
    {
        public void Add(Student student);
    }
}