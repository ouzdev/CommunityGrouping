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
using CommunityGrouping.Entities.Dto.Person;

namespace CommunityGrouping.Business.Services.Concrete
{
    public class PersonService :BaseService<PersonPerson>, IPersonService
    {
        public PersonService(IPersonRepository personRepository, IMapper mapper, IUnitOfWork unitOfWork) : base(personRepository, mapper, unitOfWork)
        {
        }

    }

}
