using System.Threading.Tasks;
using Infrastructure.Persistence.DbContext;
using Sample.Application.Contracts.Repositories;
using Sample.Domain.Entities;

namespace Infrastructure.Persistence.Repositories.Students
{
    public class StudentRepository : IStudentRepository
    {
        private readonly EFDataContext _dataContext;

        public StudentRepository(EFDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Add(Student student)
        {
            _dataContext.Students.Add(student);
        }

        public async Task Save()
        {
            await _dataContext.SaveChangesAsync();
        }
    }
}