using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityGrouping.Entities;

namespace CommunityGrouping.Data.Repositories.Abstract
{
    public interface ICommunityGroupRepository:IGenericRepository<CommunityGroup>
    {
        Task<CommunityGroup> GetGroupWithPeople(int communityId);

    }
}
