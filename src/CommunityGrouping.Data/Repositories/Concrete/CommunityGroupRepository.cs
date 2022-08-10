using CommunityGrouping.Data.Context.EntityFramework;
using CommunityGrouping.Data.Repositories.Abstract;
using CommunityGrouping.Entities;

namespace CommunityGrouping.Data.Repositories.Concrete
{
    public class CommunityGroupRepository : GenericRepository<CommunityGroup>, ICommunityGroupRepository
    {
        public CommunityGroupRepository(AppDbContext context) : base(context)
        {
        }
    }
}
