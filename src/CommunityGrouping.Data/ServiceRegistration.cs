using CommunityGrouping.Data.Repositories.Abstract;
using CommunityGrouping.Data.Repositories.Concrete;
using CommunityGrouping.Data.Repositories.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace CommunityGrouping.Data
{
    public static class ServiceRegistration
    {
        public static void AddDataLayerServiceRegistration(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IOccupationRepository, OccupationRepository>();
            services.AddScoped<ICommunityGroupRepository, CommunityGroupRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

        }
    }
}
