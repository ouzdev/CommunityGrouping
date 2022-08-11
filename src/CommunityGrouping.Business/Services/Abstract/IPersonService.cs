using CommunityGrouping.Business.Filters;
using CommunityGrouping.Core;
using CommunityGrouping.Core.BaseModel;
using CommunityGrouping.Entities;
using CommunityGrouping.Entities.Dto;



namespace CommunityGrouping.Business.Services.Abstract
{
    public interface IPersonService:IBaseService<PersonDto,Person>
    {
        Task<IDataResult<IEnumerable<PersonDto>>> GetPaginationAsync(PaginationFilter paginationFilter, PersonDto filterResource, string route);
    }
}
