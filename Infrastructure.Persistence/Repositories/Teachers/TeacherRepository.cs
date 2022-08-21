using Infrastructure.Persistence.DbContext;
using Sample.Application.Contracts.Repositories;
using Sample.Domain.Entities;

namespace Infrastructure.Persistence.Repositories.Teachers
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly EFDataContext _dataContext;

        public TeacherRepository(EFDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Add(Teacher teacher)
        {
            _dataContext.Teachers.Add(teacher);
        }
    }
}