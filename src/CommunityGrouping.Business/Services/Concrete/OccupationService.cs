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

namespace CommunityGrouping.Business.Services.Concrete
{
    public class OccupationService : BaseService<OccupationDto, Occupation>, IOccupationService
    {
        public OccupationService(OccupationRepository occupationRepository, IMapper mapper, IUnitOfWork unitOfWork) : base(occupationRepository, mapper, unitOfWork)
        {
        }
    }
    
    
}
