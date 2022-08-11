using CommunityGrouping.Data.Context.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace CommunityGrouping.WebAPI.Extension.StartupExtension
{
    public static class ApplicationDbContextExtension
    {
        public static void AddDbContextDependencyInjection(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        }
    }
}
