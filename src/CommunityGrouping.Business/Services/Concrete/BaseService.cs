using AutoMapper;
using CommunityGrouping.Business.Constant;
using CommunityGrouping.Business.Services.Abstract;
using CommunityGrouping.Core;
using CommunityGrouping.Core.BaseModel;
using CommunityGrouping.Data.Repositories.Abstract;
using CommunityGrouping.Data.Repositories.UnitOfWork;

namespace CommunityGrouping.Business.Services.Concrete
{
    public abstract class BaseService<TReadDto, TWriteDto, TEntity> : IBaseService<TReadDto, TWriteDto, TEntity> where TEntity : BaseEntity
    {

        private readonly IGenericRepository<TEntity> baseRepository;
        protected readonly IMapper Mapper;
        protected readonly IUnitOfWork UnitOfWork;


        public BaseService(IGenericRepository<TEntity> baseRepository, IMapper mapper, IUnitOfWork unitOfWork) : base()
        {
            this.baseRepository = baseRepository;
            this.Mapper = mapper;
            this.UnitOfWork = unitOfWork;
        }


        public virtual async Task<IDataResult<IEnumerable<TReadDto>>> GetAllAsync()
        {
            // Get list record from DB
            var tempEntity = await baseRepository.GetAllAsync();
            // Mapping Entity to Resource
            var result = Mapper.Map<IEnumerable<TEntity>, IEnumerable<TReadDto>>(tempEntity);

            return new SuccessDataResult<IEnumerable<TReadDto>>(result);
        }

        public virtual async Task<IDataResult<TReadDto>> GetByIdAsync(int id)
        {
            var tempEntity = await baseRepository.GetByIdAsync(id);
            // Mapping Entity to Resource
            var result = Mapper.Map<TEntity, TReadDto>(tempEntity);

            return new SuccessDataResult<TReadDto>(result);
        }

        public virtual async Task<IDataResult<TReadDto>> InsertAsync(TWriteDto insertResource)
        {
            try
            {
                // Mapping Resource to Entity
                var tempEntity = Mapper.Map<TWriteDto, TEntity>(insertResource);

                await baseRepository.AddAsync(tempEntity);
                await UnitOfWork.CompleteAsync();

                return new SuccessDataResult<TReadDto>(Mapper.Map<TEntity, TReadDto>(tempEntity));
            }
            catch (Exception ex)
            {
                throw new MessageResultException(Messages.ADD_ERROR, ex);
            }
        }

        public virtual async Task<IDataResult<TReadDto>> RemoveAsync(int id)
        {
            try
            {
                // Validate Id is existent
                var tempEntity = await baseRepository.GetByIdAsync(id);
                if (tempEntity is null)
                    return new ErrorDataResult<TReadDto>(Messages.ID_NOT_EXISTENT);

                baseRepository.Delete(tempEntity);
                await UnitOfWork.CompleteAsync();

                return new SuccessDataResult<TReadDto>(Mapper.Map<TEntity, TReadDto>(tempEntity));
            }
            catch (Exception ex)
            {
                throw new MessageResultException(Messages.DELETE_ERROR, ex);
            }
        }

        public virtual async Task<IDataResult<TReadDto>> UpdateAsync(int id, TWriteDto updateResource)
        {
            try
            {
                var tempEntity = await baseRepository.GetByIdAsync(id);
                if (tempEntity is null)
                    return new ErrorDataResult<TReadDto>(Messages.ID_NOT_EXISTENT);

                Mapper.Map(updateResource, tempEntity);

                await UnitOfWork.CompleteAsync();

                var resource = Mapper.Map<TEntity, TReadDto>(tempEntity);

                return new SuccessDataResult<TReadDto>(resource);
            }
            catch (Exception ex)
            {
                throw new MessageResultException(Messages.UPDATE_ERROR, ex);
            }
        }
    }
}
