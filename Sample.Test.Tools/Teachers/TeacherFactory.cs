using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repositories.Teachers;
using Infrastructure.Persistence.UnitOfWork;
using Sample.Application.Teachers;

namespace Sample.Test.Tools.Teachers
{
    public static class TeacherFactory
    {
        public static TeacherService CreateService(EFDataContext? dataContext)
        {
            var unitOfWork = new EFUnitOfWork(dataContext);
            var repository = new TeacherRepository(dataContext);
            return new TeacherService(unitOfWork, repository);
        }
    }
}