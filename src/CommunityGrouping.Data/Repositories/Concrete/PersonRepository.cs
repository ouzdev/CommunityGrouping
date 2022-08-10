using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityGrouping.Data.Context.EntityFramework;
using CommunityGrouping.Data.Repositories.Abstract;
using CommunityGrouping.Entities;

namespace CommunityGrouping.Data.Repositories.Concrete
{
    public class PersonRepository:GenericRepository<Person>,IPersonRepository
    {
        public PersonRepository(AppDbContext context) : base(context)
        {
        }
    }
}
