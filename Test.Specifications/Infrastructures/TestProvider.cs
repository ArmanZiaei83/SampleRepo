using Infrastructure.Persistence.DbContext;
using Infrastructure.Persistence.InMemoryDatabase;

namespace Test.Specifications.Infrastructures
{
    public class TestProvider
    {
        protected readonly EFDataContext _dataContext;
        protected readonly EFDataContext _readDataContext;

        protected TestProvider()
        {
            var memoryDatabase = new EFInMemoryDatabase();
            _dataContext = memoryDatabase.CreateDataContext<EFDataContext>();
            _readDataContext =
                memoryDatabase.CreateDataContext<EFDataContext>();
        }

        protected void Save<T>(T entity)
        {
            _dataContext.Add(entity);
            _dataContext.SaveChanges();
        }
    }
}