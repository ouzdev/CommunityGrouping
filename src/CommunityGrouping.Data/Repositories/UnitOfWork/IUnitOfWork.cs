
namespace CommunityGrouping.Data.Repositories.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        Task CompleteAsync();
        Task BulkCompleteAsync();
    }
}

