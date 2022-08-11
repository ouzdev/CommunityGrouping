using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CommunityGrouping.Business.Constant;
using CommunityGrouping.Business.Services.Abstract;
using CommunityGrouping.Core;
using CommunityGrouping.Data.Repositories.Abstract;
using CommunityGrouping.Data.Repositories.UnitOfWork;
using CommunityGrouping.Entities;
using CommunityGrouping.Entities.Dto;
using Microsoft.AspNetCore.Http;

namespace CommunityGrouping.Business.Services.Concrete
{
    public class CommunityGroupService : BaseService<CommunityGroupDto, CommunityGroup>, ICommunityGroupService
    {
        private readonly ICommunityGroupRepository _communityGroupRepository;

        public CommunityGroupService(ICommunityGroupRepository communityGroupRepository, IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(communityGroupRepository, mapper, unitOfWork, httpContextAccessor)
        {
            _communityGroupRepository = communityGroupRepository;
        }

        public override async Task<IDataResult<CommunityGroupDto>> UpdateAsync(int id, CommunityGroupDto updateResource)
        {
            try
            {
                var tempEntity = await _communityGroupRepository.GetByIdAsync(id);
                if (tempEntity is null)
                    return new ErrorDataResult<CommunityGroupDto>(Messages.ID_NOT_EXISTENT);
                tempEntity.Name = updateResource.Name;
                tempEntity.Description = updateResource.Description;
                _communityGroupRepository.Update(tempEntity);
                await UnitOfWork.CompleteAsync();

                var resource = Mapper.Map<CommunityGroup, CommunityGroupDto>(tempEntity);

                return new SuccessDataResult<CommunityGroupDto>(resource, Messages.RECORD_UPDATED);
            }
            catch (Exception ex)
            {
                throw new MessageResultException(Messages.UPDATE_ERROR, ex);
            }
        }
    }
}
