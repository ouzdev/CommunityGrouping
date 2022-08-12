
namespace CommunityGrouping.Data.Repositories.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        Task CompleteAsync();
        void Complete();
        Task BulkCompleteAsync();
    }
}

