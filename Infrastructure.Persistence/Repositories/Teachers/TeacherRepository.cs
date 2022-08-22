using Infrastructure.Persistence.DbContext;
using Microsoft.EntityFrameworkCore;
using Sample.Application.Interfaces.Repositories;
using Sample.Domain.Entities;

namespace Infrastructure.Persistence.Repositories.Teachers
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly DbSet<Teacher> _teachers;

        public TeacherRepository(EFDataContext dataContext)
        {
            _teachers = dataContext.Teachers;
        }

        public void Add(Teacher teacher)
        {
            _teachers.Add(teacher);
        }
    }
}