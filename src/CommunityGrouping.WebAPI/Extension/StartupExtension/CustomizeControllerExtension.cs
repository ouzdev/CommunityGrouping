using System.Reflection;
using System.Text.Json.Serialization;
using FluentValidation.AspNetCore;
using Newtonsoft.Json.Converters;

namespace CommunityGrouping.API.Extension.StartupExtension
{
    public static class CustomizeControllerExtension
    {
        public static void AddCustomizeController(this IServiceCollection services)
        {
            services.AddControllers()
                .AddJsonOptions(x =>
                {
                    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                })
                .AddFluentValidation(c => c.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));
        }
    }
}
