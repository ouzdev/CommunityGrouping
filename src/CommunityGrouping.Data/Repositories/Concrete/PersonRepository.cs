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

        public async Task<(IEnumerable<Person> records, int total)> GetPaginationAsync(PaginationFilter paginationFilter, PersonDto filterResource)
        {
            var queryable = ConditionFilter(filterResource);

            var total = await queryable.CountAsync();

            var records = await queryable.AsNoTracking()
                .AsSplitQuery()
                .OrderBy(x => x.Id)
                .Skip((paginationFilter.PageNumber - 1) * paginationFilter.PageSize)
                .Take(paginationFilter.PageSize)
                .ToListAsync();

            return (records, total);
        }

        public async Task InsertBulk(IList<Person> persons)
        {
             await _dbContext.BulkInsertAsync<Person>(persons);
        }

        private IQueryable<Person> ConditionFilter(PersonDto filterResource)
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
