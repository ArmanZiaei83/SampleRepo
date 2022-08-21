using Sample.Domain.Entities;

namespace Sample.Application.Contracts.Repositories
{
    public interface ITeacherRepository
    {
        public void Add(Teacher teacher);
    }
}