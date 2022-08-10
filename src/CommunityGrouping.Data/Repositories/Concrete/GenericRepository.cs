using System.Linq.Expressions;
using CommunityGrouping.Core.BaseModel;
using CommunityGrouping.Data.Context.EntityFramework;
using CommunityGrouping.Data.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace CommunityGrouping.Data.Repositories.Concrete;
public class GenericRepository<TEntity> : IGenericRepository<TEntity>
    where TEntity : BaseEntity, IEntity, new()
{
    protected readonly AppDbContext Context;
    private readonly DbSet<TEntity> _entities;

    public GenericRepository(AppDbContext dbContext)
    {
        Context = dbContext;
        _entities = Context.Set<TEntity>();
    }

    public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>>? filter = null)
    {
        if (filter != null)
            return await _entities.SingleOrDefaultAsync(filter);

        return await _entities.SingleOrDefaultAsync();
    }


    public async Task<TEntity?> GetByIdAsync(int entityId)
    {
        return await _entities.AsNoTracking().FirstOrDefaultAsync(x => x.Id == entityId);
    }

    public async Task AddAsync(TEntity entity)
    {
        await _entities.AddAsync(entity);
    }

    public void Delete(TEntity entity)
    {
        _entities.Remove(entity);
    }


    public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? filter = null)
    {
        return await (filter == null ? _entities.AsNoTracking().ToListAsync() : _entities.AsNoTracking().Where(filter).ToListAsync());
    }

    public void Update(TEntity entity)
    {
        _entities.Update(entity);
    }
}