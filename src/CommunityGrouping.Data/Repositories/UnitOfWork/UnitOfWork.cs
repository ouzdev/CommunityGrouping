﻿using CommunityGrouping.Data.Context.EntityFramework;

namespace CommunityGrouping.Data.Repositories.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext dbContext;
    public bool disposed;

    public UnitOfWork(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public async Task CompleteAsync()
    {
        await dbContext.SaveChangesAsync();
    }
    protected virtual void Clean(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                dbContext.Dispose();
            }
        }
        this.disposed = true;
    }
    public void Dispose()
    {
        Clean(true);
        GC.SuppressFinalize(this);
    }
}