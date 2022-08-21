using System.Threading.Tasks;
using Infrastructure.Persistence.DbContext;
using Sample.Application.Contracts.Repositories;

namespace Infrastructure.Persistence.Repositories.Student
{
    public class StudentRepository : IStudentRepository
    {
        private readonly EFDataContext _dataContext;

        public StudentRepository(EFDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Add(Sample.Domain.Entities.Student student)
        {
            _dataContext.Students.Add(student);
        }

        public async Task Save()
        {
            await _dataContext.SaveChangesAsync();
        }
    }
}