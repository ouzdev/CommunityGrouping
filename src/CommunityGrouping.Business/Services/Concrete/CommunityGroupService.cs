using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CommunityGrouping.Business.Services.Abstract;
using CommunityGrouping.Data.Repositories.Abstract;
using CommunityGrouping.Data.Repositories.UnitOfWork;
using CommunityGrouping.Entities;
using CommunityGrouping.Entities.Dto;
using Microsoft.AspNetCore.Http;

namespace CommunityGrouping.Business.Services.Concrete
{
    public class CommunityGroupService:BaseService<CommunityGroupDto, CommunityGroup>,ICommunityGroupService
    {
        public CommunityGroupService(ICommunityGroupRepository communityGroupRepository, IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(communityGroupRepository, mapper, unitOfWork, httpContextAccessor)
        {
        }
    }
}
