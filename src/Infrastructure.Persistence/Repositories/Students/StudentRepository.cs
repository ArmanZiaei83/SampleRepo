using System.Threading.Tasks;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Sample.Application.Interfaces.Repositories;
using Sample.Domain.Entities;

namespace Infrastructure.Persistence.Repositories.Students
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DbSet<Student> _students;

        public StudentRepository(EFDataContext? dataContext)
        {
            _students = dataContext.Students;
        }

        public void Add(Student student)
        {
            _students.Add(student);
        }

        public void DeleteById(Student student)
        {
            _students.Remove(student);
        }

        public ValueTask<Student?> Find(int id)
        {
            return _students.FindAsync(id);
        }

        public async Task<bool> Exists(int id)
        {
            return await _students.AnyAsync(_ => _.Id == id);
        }
    }
}