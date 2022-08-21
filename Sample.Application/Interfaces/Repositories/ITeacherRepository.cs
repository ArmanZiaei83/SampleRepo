using Sample.Domain.Entities;

namespace Sample.Application.Interfaces.Repositories
{
    public interface ITeacherRepository : IRepository
    {
        public void Add(Teacher teacher);
    }
}