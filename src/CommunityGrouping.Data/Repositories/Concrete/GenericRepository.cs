using System.Linq.Expressions;
using CommunityGrouping.Core;
using CommunityGrouping.Core.BaseModel;
using CommunityGrouping.Data.Context.EntityFramework;
using CommunityGrouping.Data.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace CommunityGrouping.Data.Repositories.Concrete;
public class GenericRepository<TEntity> : IGenericRepository<TEntity>
    where TEntity : BaseEntity, IEntity, new()
{
    protected readonly AppDbContext Context;
    private DbSet<TEntity> entities;

    public GenericRepository(AppDbContext dbContext)
    {
        Context = dbContext;
        entities = Context.Set<TEntity>();
    }

    public async Task AddAsync(TEntity entity)
    {
        await entities.AddAsync(entity);
    }

    public void Delete(TEntity entity)
    {
        entities.Remove(entity);
    }

    public async Task<TEntity?> GetAsync(Expression<Func<TEntity?, bool>>? filter = null)
    {
        return await entities.AsNoTracking().Where(filter).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? filter = null)
    {
        return await (filter == null ? entities.AsNoTracking().ToListAsync() : entities.AsNoTracking().Where(filter).ToListAsync());
    }

    public void Update(TEntity entity)
    {
        entities.Update(entity);
    }
}