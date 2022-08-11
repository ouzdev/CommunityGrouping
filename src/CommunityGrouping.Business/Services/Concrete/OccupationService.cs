using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CommunityGrouping.Business.Services.Abstract;
using CommunityGrouping.Data.Repositories.Abstract;
using CommunityGrouping.Data.Repositories.Concrete;
using CommunityGrouping.Data.Repositories.UnitOfWork;
using CommunityGrouping.Entities;
using CommunityGrouping.Entities.Dto;
using Microsoft.AspNetCore.Http;

namespace CommunityGrouping.Business.Services.Concrete
{
    public class OccupationService : BaseService<OccupationDto, Occupation>, IOccupationService
    {
        public OccupationService(IOccupationRepository occupationRepository, IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(occupationRepository, mapper, unitOfWork, httpContextAccessor)
        {
        }
    }
    
    
}
