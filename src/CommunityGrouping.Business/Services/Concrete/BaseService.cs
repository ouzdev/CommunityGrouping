using AutoMapper;
using CommunityGrouping.Business.Constant;
using CommunityGrouping.Business.Services.Abstract;
using CommunityGrouping.Core;
using CommunityGrouping.Core.BaseModel;
using CommunityGrouping.Data.Repositories.Abstract;
using CommunityGrouping.Data.Repositories.UnitOfWork;

namespace CommunityGrouping.Business.Services.Concrete
{
    public abstract class BaseService<TDto, TEntity> : IBaseService<TDto, TEntity> where TEntity : BaseEntity
    {

        private readonly IGenericRepository<TEntity> baseRepository;
        protected readonly IMapper Mapper;
        protected readonly IUnitOfWork UnitOfWork;


        protected BaseService(IGenericRepository<TEntity> baseRepository, IMapper mapper, IUnitOfWork unitOfWork) : base()
        {
            this.baseRepository = baseRepository;
            this.Mapper = mapper;
            this.UnitOfWork = unitOfWork;
        }


        public virtual async Task<IDataResult<IEnumerable<TDto>>> GetAllAsync()
        {
            // Get list record from DB
            var tempEntity = await baseRepository.GetAllAsync();
            // Mapping Entity to Resource
            var result = Mapper.Map<IEnumerable<TEntity>, IEnumerable<TDto>>(tempEntity);

            return new SuccessDataResult<IEnumerable<TDto>>(result);
        }

        public virtual async Task<IDataResult<TDto>> GetByIdAsync(int id)
        {
            var tempEntity = await baseRepository.GetByIdAsync(id);
            // Mapping Entity to Resource
            var result = Mapper.Map<TEntity, TDto>(tempEntity);

            return new SuccessDataResult<TDto>(result);
        }

        public virtual async Task<IDataResult<TDto>> InsertAsync(TDto insertResource)
        {
            try
            {
                // Mapping Resource to Entity
                var tempEntity = Mapper.Map<TDto, TEntity>(insertResource);

                await baseRepository.AddAsync(tempEntity);
                await UnitOfWork.CompleteAsync();

                return new SuccessDataResult<TDto>(Mapper.Map<TEntity, TDto>(tempEntity));
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
                var tempEntity = await baseRepository.GetByIdAsync(id);
                if (tempEntity is null)
                    return new ErrorDataResult<TDto>(Messages.ID_NOT_EXISTENT);

                baseRepository.Delete(tempEntity);
                await UnitOfWork.CompleteAsync();

                return new SuccessDataResult<TDto>(Mapper.Map<TEntity, TDto>(tempEntity));
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
                var tempEntity = await baseRepository.GetByIdAsync(id);
                if (tempEntity is null)
                    return new ErrorDataResult<TDto>(Messages.ID_NOT_EXISTENT);

                Mapper.Map(updateResource, tempEntity);

                await UnitOfWork.CompleteAsync();

                var resource = Mapper.Map<TEntity, TDto>(tempEntity);

                return new SuccessDataResult<TDto>(resource);
            }
            catch (Exception ex)
            {
                throw new MessageResultException(Messages.UPDATE_ERROR, ex);
            }
        }
    }
}
