using System.Linq.Expressions;
namespace CommunityGrouping.Data.Repositories.Abstract
{
    public interface IGenericRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? filter = null);
        Task<TEntity?> GetAsync(Expression<Func<TEntity?, bool>>? filter = null);
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
