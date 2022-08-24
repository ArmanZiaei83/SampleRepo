using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repositories.Students;
using Infrastructure.Persistence.UnitOfWork;
using Sample.Application.Students;

namespace Sample.Test.Tools.Students
{
    public static class StudentFactory
    {
        public static StudentService CreateService(EFDataContext? dataContext)
        {
            var unitOfWork = new EFUnitOfWork(dataContext);
            var repository = new StudentRepository(dataContext);
            return new StudentService(unitOfWork, repository);
        }
    }
}