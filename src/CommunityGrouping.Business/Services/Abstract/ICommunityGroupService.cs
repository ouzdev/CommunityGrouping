using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityGrouping.Core;
using CommunityGrouping.Entities;

namespace CommunityGrouping.Business.Services.Abstract
{
    public interface ICommunityGroupService
    {
        Task<IResult> AddAsync(ApplicationUser user);
        IResult Update(ApplicationUser user);
        Task<IResult> Delete(ApplicationUser user);
    }
}
