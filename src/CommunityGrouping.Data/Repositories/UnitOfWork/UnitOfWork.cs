using CommunityGrouping.Data.Context.EntityFramework;
using EFCore.BulkExtensions;

namespace CommunityGrouping.Data.Repositories.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _dbContext;
    public bool Disposed;

    public UnitOfWork(AppDbContext dbContext)
    {
        this._dbContext = dbContext;
    }
    public async Task CompleteAsync()
    {
        await _dbContext.SaveChangesAsync();
    }

    public async Task BulkCompleteAsync()
    {
        await _dbContext.BulkSaveChangesAsync();
    }

    protected virtual void Clean(bool disposing)
    {
        if (!this.Disposed)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }
        this.Disposed = true;
    }
    public void Dispose()
    {
        Clean(true);
        GC.SuppressFinalize(this);
    }
}