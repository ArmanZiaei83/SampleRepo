using System.Threading.Tasks;

namespace Sample.Application.Interfaces
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