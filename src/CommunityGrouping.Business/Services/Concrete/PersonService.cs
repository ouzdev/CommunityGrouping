using System.Text;
using AutoMapper;
using CommunityGrouping.Business.Constant;
using CommunityGrouping.Business.Filters;
using CommunityGrouping.Business.Services.Abstract;
using CommunityGrouping.Core;
using CommunityGrouping.Core.BaseModel;
using CommunityGrouping.Core.Extensions;
using CommunityGrouping.Core.Utilities.URI;
using CommunityGrouping.Data.Repositories.Abstract;
using CommunityGrouping.Data.Repositories.UnitOfWork;
using CommunityGrouping.Entities;
using CommunityGrouping.Entities.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace CommunityGrouping.Business.Services.Concrete
{
    public class PersonService : BaseService<PersonDto, Person>, IPersonService
    {
        private readonly IPaginationUriService _paginationUriService;

        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOccupationService _occupationService;
        private readonly IDistributedCache _distributedCache;

        public PersonService(IPersonRepository personRepository,
                             IMapper mapper,
                             IUnitOfWork unitOfWork,
                             IHttpContextAccessor httpContextAccessor,
                             IOccupationService occupationService,
                             IDistributedCache distributedCache,
                             IPaginationUriService paginationUriService) : base(personRepository, mapper, unitOfWork, httpContextAccessor)
        {
            _personRepository = personRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _occupationService = occupationService;
            _distributedCache = distributedCache;
            _paginationUriService = paginationUriService;
        }

        public override async Task<IDataResult<PersonDto>> InsertAsync(PersonDto insertResource)
        {
            try
            {
                var occupationResult = await _occupationService.GetByIdAsync(insertResource.OccupationId);

                if (!occupationResult.Success) return new ErrorDataResult<PersonDto>(Messages.OCCUPATION_NOT_FOUND);

                var person = _mapper.Map<Person>(insertResource);
                person.ApplicationUserId = base.CurrentUserId;
                await _personRepository.AddAsync(person);
                await _unitOfWork.CompleteAsync();

                return new SuccessDataResult<PersonDto>(_mapper.Map<PersonDto>(person), Messages.PERSON_ADDED);
            }
            catch (Exception ex)
            {
                throw new MessageResultException(Messages.ADD_ERROR, ex);
            }
        }

        public async Task<IDataResult<IEnumerable<PersonDto>>> GetPaginationAsync(PaginationFilter paginationFilter, PersonDto filterResource, string route)
        {

            var paginationPerson = await _personRepository.GetPaginationAsync(paginationFilter, filterResource);
            var resource = GeneratePagination(paginationFilter, route, paginationPerson);
            return resource;

        }
        private PaginatedResult<IEnumerable<PersonDto>> GeneratePagination(PaginationFilter paginationFilter, string route, (IEnumerable<Person> records, int total) paginationPerson)
        {
            var tempResource = Mapper.Map<IEnumerable<Person>, IEnumerable<PersonDto>>(paginationPerson.records);
            var resource = new PaginatedResult<IEnumerable<PersonDto>>(tempResource);
            resource.CreatePaginationResponse(paginationFilter, paginationPerson.total, _paginationUriService, route);
            return resource;
        }
    }

}
