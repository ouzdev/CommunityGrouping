
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
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CommunityGroupService(ICommunityGroupRepository communityGroupRepository, IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(communityGroupRepository, mapper, unitOfWork, httpContextAccessor)
        {
            _communityGroupRepository = communityGroupRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async override Task<IDataResult<CommunityGroupDto>> InsertAsync(CommunityGroupDto insertResource)
        {
            try
            {
                var communityGroup = _mapper.Map<CommunityGroup>(insertResource);
                communityGroup.ApplicationUserId = base.CurrentUserId;
                await _communityGroupRepository.AddAsync(communityGroup);
                await _unitOfWork.CompleteAsync();

                return new SuccessDataResult<CommunityGroupDto>(_mapper.Map<CommunityGroupDto>(communityGroup), Messages.PERSON_ADDED);
            }
            catch (Exception ex)
            {
                throw new MessageResultException(Messages.ADD_ERROR, ex);
            }
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
                await _unitOfWork.CompleteAsync();

                var resource = _mapper.Map<CommunityGroup, CommunityGroupDto>(tempEntity);

                return new SuccessDataResult<CommunityGroupDto>(resource, Messages.RECORD_UPDATED);
            }
            catch (Exception ex)
            {
                throw new MessageResultException(Messages.UPDATE_ERROR, ex);
            }
        }

        public async Task<IDataResult<CommunityGroupPeopleDto>> GetCommunityGroupPeopleAsync(int communityGroupId)
        {
            try
            {
                var tempEntity = await _communityGroupRepository.GetGroupWithPeople(communityGroupId);
                
                if (tempEntity == null) return new ErrorDataResult<CommunityGroupPeopleDto>(Messages.ID_NOT_EXISTENT);

                var resource = _mapper.Map<CommunityGroupPeopleDto>(tempEntity);
                return new SuccessDataResult<CommunityGroupPeopleDto>(resource, Messages.RECORD_LISTED);
            }
            catch (Exception ex)
            {
                throw new MessageResultException(Messages.SYSTEM_ERROR, ex);
            }
        }

        public void MapCollectionsInPlace<TSource, TDestination>(IEnumerable<TSource> source_collection,
            IEnumerable<TDestination> destination_collection)
        {
            var source_enumerator = source_collection.GetEnumerator();
            var destination_enumerator = destination_collection.GetEnumerator();

            while (source_enumerator.MoveNext())
            {
                if (!destination_enumerator.MoveNext())
                    throw new Exception("Source collection has more items than destination collection");

                _mapper.Map(source_enumerator.Current, destination_enumerator.Current);
            }
        }
    }
}
