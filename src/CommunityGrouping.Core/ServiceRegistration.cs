using Microsoft.Extensions.DependencyInjection;

namespace CommunityGrouping.Core
{
    public static class ServiceRegistration
    {
        public static void AddCoreLayerServiceRegistration(this IServiceCollection services)
        {
            services.AddScoped<ITokenHelper, JwtHelper>();

        }
    }
}
