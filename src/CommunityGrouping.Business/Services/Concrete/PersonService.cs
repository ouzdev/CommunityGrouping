using System.Globalization;
using System.Text;
using AutoMapper;
using CommunityGrouping.Business.Constant;
using CommunityGrouping.Business.Filters;
using CommunityGrouping.Business.Mapper;
using CommunityGrouping.Business.Services.Abstract;
using CommunityGrouping.Core;
using CommunityGrouping.Core.BaseModel;
using CommunityGrouping.Core.Extensions;
using CommunityGrouping.Core.Utilities.URI;
using CommunityGrouping.Data.Repositories.Abstract;
using CommunityGrouping.Data.Repositories.UnitOfWork;
using CommunityGrouping.Entities;
using CommunityGrouping.Entities.Dto;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace CommunityGrouping.Business.Services.Concrete
{
    public class PersonService : BaseService<PersonDto, Person>, IPersonService
    {
        private readonly IPaginationUriService _paginationUriService;

        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDistributedCache _distributedCache;

        public PersonService(IPersonRepository personRepository,
                             IMapper mapper,
                             IUnitOfWork unitOfWork,
                             IHttpContextAccessor httpContextAccessor,
                             IDistributedCache distributedCache,
                             IPaginationUriService paginationUriService) : base(personRepository, mapper, unitOfWork, httpContextAccessor)
        {
            _personRepository = personRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _distributedCache = distributedCache;
            _paginationUriService = paginationUriService;
        }

        public override async Task<IDataResult<PersonDto>> InsertAsync(PersonDto insertResource)
        {
            try
            {
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

        public async Task<IDataResult<IEnumerable<PersonDto>>> GetPaginationAsync( PersonFilter filterResource, string route)
        {
            var paginationPerson = await _personRepository.GetPaginationAsync(filterResource);
            var resource = GeneratePagination(filterResource,route, paginationPerson);
            return resource;
        }

        //public async Task<IDataResult<IEnumerable<PersonDto>>> GetPaginationAsync(PersonFilter paginationFilter, string route)
        //{
        //    var cacheKey = $"{route}";
        //    string json;
        //    var employeesFromCache = await _distributedCache.GetAsync(cacheKey);
        //    if (employeesFromCache != null)
        //    {
        //        json = Encoding.UTF8.GetString(employeesFromCache);
        //        var employees = JsonConvert.DeserializeObject<PaginationEntityResponse<PersonDto>>(json);
        //        return new PaginatedResult<IEnumerable<PersonDto>>(employees.Data, employees.PageNumber,
        //            employees.PageSize)
        //        {
        //            PreviousPage = employees.PreviousPage,
        //            NextPage = employees.NextPage,
        //            LastPage = employees.LastPage,
        //            FirstPage = employees.FirstPage,
        //            TotalPages = employees.TotalPages,
        //            TotalRecords = employees.TotalRecords
        //        };
        //    }
        //    else
        //    {
        //        var paginationPerson = await _personRepository.GetPaginationAsync(paginationFilter);
        //        var resource = GeneratePagination(paginationFilter, route, paginationPerson);
        //        json = JsonConvert.SerializeObject(resource);
        //        employeesFromCache = Encoding.UTF8.GetBytes(json);
        //        var options = new DistributedCacheEntryOptions()
        //            .SetSlidingExpiration(TimeSpan.FromDays(1))
        //            .SetAbsoluteExpiration(DateTime.Now.AddMonths(1));
        //        await _distributedCache.SetAsync(cacheKey, employeesFromCache, options);
        //        return resource;
        //    }
        //}

        public async Task<IResult> InsertBulkPerson(IFormFile formFile)
        {
            try
            {
                using var reader = new StreamReader(formFile.OpenReadStream());
                var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);
                var records = csvReader.GetRecords<PersonMap>();
                var result = _mapper.Map<IList<Person>>(records);
                foreach (var item in result)
                {
                    item.ApplicationUserId = base.CurrentUserId;
                }
                await _personRepository.InsertBulk(result);
                await _unitOfWork.BulkCompleteAsync();
                return new SuccessResult(Messages.RECORD_ADDED);
            }
            catch (Exception ex)
            {
                throw new MessageResultException(Messages.ADD_ERROR, ex);
            }
        }

        private PaginatedResult<IEnumerable<PersonDto>> GeneratePagination(PaginationFilter paginationFilter, string route, (IEnumerable<Person> records, int total) paginationPerson)
        {
            var tempResource = _mapper.Map<IEnumerable<Person>, IEnumerable<PersonDto>>(paginationPerson.records);
            var resource = new PaginatedResult<IEnumerable<PersonDto>>(tempResource);
            resource.CreatePaginationResponse(paginationFilter, paginationPerson.total, _paginationUriService, route);
            return resource;
        }
    }
}
