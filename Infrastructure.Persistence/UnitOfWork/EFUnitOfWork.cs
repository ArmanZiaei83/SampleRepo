using System.Threading.Tasks;
using Infrastructure.Persistence.DbContext;
using Sample.Application.Interfaces;

namespace Infrastructure.Persistence.UnitOfWork
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly EFDataContext _dataContext;

        public EFUnitOfWork(EFDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task Begin()
        {
            await _dataContext.Database.BeginTransactionAsync();
        }

        public void CommitPartial()
        {
            _dataContext.SaveChanges();
        }

        public async Task Commit()
        {
            await _dataContext.SaveChangesAsync();
            await _dataContext.Database.CommitTransactionAsync();
        }

        public async Task Rollback()
        {
            await _dataContext.Database.RollbackTransactionAsync();
        }

        public async Task Complete()
        {
            await _dataContext.SaveChangesAsync();
        }
    }
}