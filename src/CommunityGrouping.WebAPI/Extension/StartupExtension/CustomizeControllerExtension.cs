using System.Reflection;
using System.Text.Json.Serialization;
using FluentValidation.AspNetCore;

namespace CommunityGrouping.API.Extension.StartupExtension
{
    public static class CustomizeControllerExtension
    {
        public static void AddCustomizeController(this IServiceCollection services)
        {
            services.AddControllers()
                .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles)
                .AddFluentValidation(c => c.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));
        }
    }
}
