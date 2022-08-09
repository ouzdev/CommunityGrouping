using CommunityGrouping.Entities;
using Microsoft.EntityFrameworkCore;

namespace CommunityGrouping.Data.Context.EntityFramework
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}
