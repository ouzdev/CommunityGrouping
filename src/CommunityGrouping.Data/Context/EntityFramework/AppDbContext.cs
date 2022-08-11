using CommunityGrouping.Entities;
using Microsoft.EntityFrameworkCore;

namespace CommunityGrouping.Data.Context.EntityFramework
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Person>(entity =>
            {
                entity.HasIndex(e => e.Email).IsUnique();
            });
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Occupation> Occupations { get; set; }
        public DbSet<CommunityGroup> CommunityGroups { get; set; }


    }
}
