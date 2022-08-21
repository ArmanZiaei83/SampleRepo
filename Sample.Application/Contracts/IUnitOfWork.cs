using System.Threading.Tasks;

namespace Sample.Application.Contracts
{
    public interface IUnitOfWork
    {
        Task Begin();
        void CommitPartial();
        Task Commit();
        Task Rollback();
        Task Complete();
    }
}