using Infrastructure.Data.DbContext;
using Infrastructure.Data.Repositories.Student;
using Sample.Application.Services.Students;

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