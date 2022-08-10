using AutoMapper;
using CommunityGrouping.Business.Mapper;

namespace CommunityGrouping.WebAPI.Extension.StartupExtension;

public static class AutoMapperExtension
{
    public static void AddAutoMapperDependecyInjection(this IServiceCollection services, WebApplicationBuilder builder)
    {
        var mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new MappingProfile());
        });

        builder.Services.AddSingleton(mapperConfig.CreateMapper());
    }

   
}