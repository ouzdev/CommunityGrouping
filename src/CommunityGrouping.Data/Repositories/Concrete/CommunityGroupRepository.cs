using CommunityGrouping.Data.Context.EntityFramework;
using CommunityGrouping.Data.Repositories.Abstract;
using CommunityGrouping.Entities;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace CommunityGrouping.Data.Repositories.Concrete
{
    public class CommunityGroupRepository : GenericRepository<CommunityGroup>, ICommunityGroupRepository
    {
        private readonly AppDbContext _context;

        public CommunityGroupRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<CommunityGroup> GetGroupWithPeople(int communityId)
        {
            var response = await _context.CommunityGroups
                                                    .Include(c => c.People)
                                                    .Where(c => c.Id == communityId)
                                                    .FirstOrDefaultAsync();
            return response;
        }
    }
}
