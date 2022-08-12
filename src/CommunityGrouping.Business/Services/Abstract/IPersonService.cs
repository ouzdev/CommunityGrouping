using CommunityGrouping.Business.Filters;
using CommunityGrouping.Core;
using CommunityGrouping.Core.BaseModel;
using CommunityGrouping.Entities;
using CommunityGrouping.Entities.Dto;
using CommunityGrouping.Entities.QueryModel;
using Microsoft.AspNetCore.Http;


namespace CommunityGrouping.Business.Services.Abstract
{
    public interface IPersonService:IBaseService<PersonDto,Person>
    {
        Task<IDataResult<IEnumerable<PersonDto>>> GetPaginationAsync(PersonFilter paginationFilter, string route);
        Task<IDataResult<PersonDto>> AddPersonToCommunityGroup(AddPersonToGroupQuery addPersonToGroupDto);
        Task<IDataResult<PersonDto>> DeletePersonToCommunityGroup(int id);

        Task<IResult> InsertBulkPerson(IFormFile file);
    }

    
}
