using CommunityGrouping.Business.Filters;
using CommunityGrouping.Core.BaseModel;
using CommunityGrouping.Core.Extensions;
using CommunityGrouping.Data.Context.EntityFramework;
using CommunityGrouping.Data.Repositories.Abstract;
using CommunityGrouping.Entities;
using CommunityGrouping.Entities.Dto;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;

namespace CommunityGrouping.Data.Repositories.Concrete
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        private readonly AppDbContext _dbContext;
        public PersonRepository(AppDbContext context) : base(context)
        {
            _dbContext = context;
        }

        public async Task<(IEnumerable<Person> records, int total)> GetPaginationAsync(PersonFilter filterResource)
        {
            var queryable = ConditionFilter(filterResource);

            var total = await queryable.CountAsync();

            queryable.AsNoTracking().AsSplitQuery();

          var res =  filterResource.SortOrder == SortOrder.Descending ? await queryable.OrderByDescending(x => x.Id)
                .Skip((filterResource.PageNumber - 1) * filterResource.PageSize)
                .Take(filterResource.PageSize).ToListAsync() : 
                await queryable
                    .OrderBy(x => x.Id)
                    .Skip((filterResource.PageNumber - 1) * filterResource.PageSize)
                    .Take(filterResource.PageSize).ToListAsync();
            
            return (res, total);
        }

        public async Task InsertBulk(IList<Person> persons)
        {
            await _dbContext.BulkInsertAsync<Person>(persons);
        }

        private IQueryable<Person> ConditionFilter(PersonFilter filterResource)
        {
            var queryable = _dbContext.People.AsQueryable();

            if (filterResource != null)
            {

                if (!string.IsNullOrEmpty(filterResource.FirstName))
                {
                    string fullName = filterResource.FirstName.RemoveSpaceCharacter().ToLower();
                    queryable = queryable.Where(x => x.FirstName.Contains(fullName));
                }

                if (!string.IsNullOrEmpty(filterResource.LastName))
                {
                    string fullName = filterResource.LastName.RemoveSpaceCharacter().ToLower();
                    queryable = queryable.Where(x => x.LastName.Contains(fullName));
                }
            }

            return queryable;
        }

    }
}
