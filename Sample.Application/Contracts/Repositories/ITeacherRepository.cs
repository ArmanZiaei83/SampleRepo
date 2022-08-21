using Sample.Domain.Entities;

namespace Sample.Application.Contracts.Repositories
{
    public interface ITeacherRepository : IRepository
    {
        public void Add(Teacher teacher);
    }
}