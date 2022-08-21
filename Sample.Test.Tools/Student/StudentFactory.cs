using Infrastructure.Persistence.DbContext;
using Infrastructure.Persistence.Repositories.Student;
using Sample.Application.Students;

namespace Sample.Test.Tools.Student
{
    public static class StudentFactory
    {
        public static StudentService CreateService(EFDataContext dataContext)
        {
            var repository = new StudentRepository(dataContext);
            return new StudentService(repository);
        }
    }
}