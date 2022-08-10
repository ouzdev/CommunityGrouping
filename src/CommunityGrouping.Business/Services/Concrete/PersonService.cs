using AutoMapper;
using CommunityGrouping.Business.Services.Abstract;
using CommunityGrouping.Data.Repositories.Abstract;
using CommunityGrouping.Data.Repositories.UnitOfWork;
using CommunityGrouping.Entities;
using CommunityGrouping.Entities.Dto;

namespace CommunityGrouping.Business.Services.Concrete
{
    public class PersonService : BaseService<PersonDto, Person>, IPersonService
    {
        public PersonService(IPersonRepository personRepository, IMapper mapper, IUnitOfWork unitOfWork) : base(personRepository, mapper, unitOfWork)
        {
        }
        
        //Another Logic Code Here
    }

}
