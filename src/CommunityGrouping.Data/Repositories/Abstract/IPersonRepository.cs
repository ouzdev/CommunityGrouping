using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityGrouping.Business.Filters;
using CommunityGrouping.Core.BaseModel;
using CommunityGrouping.Entities;
using CommunityGrouping.Entities.Dto;

namespace CommunityGrouping.Data.Repositories.Abstract
{
    public interface IPersonRepository:IGenericRepository<Person>
    {
        Task<(IEnumerable<Person> records, int total)> GetPaginationAsync(PaginationFilter paginationFilter, PersonDto filterResource);
        Task InsertBulk(IList<Person> persons);

        Task<int> TotalRecordAsync();
    }
}
