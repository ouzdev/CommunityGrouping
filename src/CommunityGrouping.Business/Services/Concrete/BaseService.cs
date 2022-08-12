using AutoMapper;
using CommunityGrouping.Business.Constant;
using CommunityGrouping.Business.Services.Abstract;
using CommunityGrouping.Core;
using CommunityGrouping.Core.BaseModel;
using CommunityGrouping.Data.Repositories.Abstract;
using CommunityGrouping.Data.Repositories.UnitOfWork;
using Microsoft.AspNetCore.Http;

namespace CommunityGrouping.Business.Services.Concrete
{
    public abstract class BaseService<TDto, TEntity> : IBaseService<TDto, TEntity> where TEntity : BaseEntity
    {
        private readonly IGenericRepository<TEntity> _baseRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        protected BaseService(IGenericRepository<TEntity> baseRepository, IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base()
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
        }
        public virtual async Task<IDataResult<IEnumerable<TDto>>> GetAllAsync()
        {
            // Get list record from DB
            var tempEntity = await _baseRepository.GetAllAsync();
            // Mapping Entity to Resource
            var result = _mapper.Map<IEnumerable<TEntity>, IEnumerable<TDto>>(tempEntity);

            return new SuccessDataResult<IEnumerable<TDto>>(result, Messages.RECORD_LISTED);
        }
        public virtual async Task<IDataResult<TDto>> GetByIdAsync(int id)
        {
            try
            {
                var tempEntity = await _baseRepository.GetByIdAsync(id);

                if (tempEntity == null) return new ErrorDataResult<TDto>(Messages.ID_NOT_EXISTENT);

                var result = _mapper.Map<TEntity, TDto>(tempEntity);

                return new SuccessDataResult<TDto>(result,Messages.RECORD_LISTED);
            }
            catch (Exception ex)
            {
                throw new MessageResultException(Messages.SYSTEM_ERROR, ex);
            }
        }
        public virtual async Task<IDataResult<TDto>> InsertAsync(TDto insertResource)
        {
            try
            {
                // Mapping Resource to Entity
                var tempEntity = _mapper.Map<TDto, TEntity>(insertResource);

                await _baseRepository.AddAsync(tempEntity);
                await _unitOfWork.CompleteAsync();

                return new SuccessDataResult<TDto>(_mapper.Map<TEntity, TDto>(tempEntity), Messages.RECORD_ADDED);
            }
            catch (Exception ex)
            {
                throw new MessageResultException(Messages.ADD_ERROR, ex);
            }
        }
        public virtual async Task<IDataResult<TDto>> RemoveAsync(int id)
        {
            try
            {
                // Validate Id is existent
                var tempEntity = await _baseRepository.GetByIdAsync(id);
                if (tempEntity is null)
                    return new ErrorDataResult<TDto>(Messages.ID_NOT_EXISTENT);

                _baseRepository.Delete(tempEntity);
                await _unitOfWork.CompleteAsync();

                return new SuccessDataResult<TDto>(_mapper.Map<TEntity, TDto>(tempEntity), Messages.RECORD_DELETED);
            }
            catch (Exception ex)
            {
                throw new MessageResultException(Messages.DELETE_ERROR, ex);
            }
        }
        public virtual async Task<IDataResult<TDto>> UpdateAsync(int id, TDto updateResource)
        {
            try
            {
                var tempEntity = await _baseRepository.GetByIdAsync(id);
                if (tempEntity is null)
                    return new ErrorDataResult<TDto>(Messages.ID_NOT_EXISTENT);
                tempEntity = _mapper.Map(updateResource, tempEntity);
                _baseRepository.Update(tempEntity);
                await _unitOfWork.CompleteAsync();

                var resource = _mapper.Map<TEntity, TDto>(tempEntity);

                return new SuccessDataResult<TDto>(resource, Messages.RECORD_UPDATED);
            }
            catch (Exception ex)
            {
                throw new MessageResultException(Messages.UPDATE_ERROR, ex);
            }
        }
        public virtual int CurrentUserId
        {
            get
            {
                if (_httpContextAccessor.HttpContext != null)
                {
                    var claimValue = _httpContextAccessor.HttpContext?.User?.FindFirst(t => t.Type == "ApplicationUserId");
                    if (claimValue != null)
                    {
                        return Convert.ToInt32(claimValue.Value);
                    }
                    return 0;
                }
                else
                {
                    return 0;
                }
            }
            set => throw new NotImplementedException();
        }
    }
}
