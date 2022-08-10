using CommunityGrouping.Data.Context.EntityFramework;
using CommunityGrouping.Data.Repositories.Abstract;
using CommunityGrouping.Entities;

namespace CommunityGrouping.Data.Repositories.Concrete
{
    public class OccupationRepository:GenericRepository<Occupation>,IOccupationRepository
    {
        public OccupationRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
