using CommunityGrouping.Core.Utilities.URI;

namespace CommunityGrouping.API.Extension.StartupExtension
{
    public static class PaginationExtension
    {
        public static void AddPagination(this IServiceCollection services)
        { 
            services.AddSingleton<IPaginationUriService>(o =>
            {
                var accessor = o.GetRequiredService<IHttpContextAccessor>();
                var request = accessor.HttpContext.Request;
                var uri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
                return new PaginationUriService(uri);
            });
        }
    }
}
