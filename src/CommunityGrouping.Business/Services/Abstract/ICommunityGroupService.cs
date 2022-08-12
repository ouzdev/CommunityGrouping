using CommunityGrouping.Core;
using CommunityGrouping.Entities;
using CommunityGrouping.Entities.Dto;

namespace CommunityGrouping.Business.Services.Abstract
{
    public interface ICommunityGroupService : IBaseService<CommunityGroupDto, CommunityGroup>
    {
        Task<IDataResult<CommunityGroupPeopleDto>> GetCommunityGroupPeopleAsync(int communityGroupId);
    }
}
