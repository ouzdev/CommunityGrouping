using CommunityGrouping.Business.Services.Abstract;
using CommunityGrouping.Business.Services.Concrete;
using CommunityGrouping.Business.ValidationRules.FluentValidation;
using CommunityGrouping.Entities.Dto;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;


namespace CommunityGrouping.Business
{
    public static class ServiceRegistration
    {
        public static void AddBusinessLayerServiceRegistration(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();

            
            services.AddScoped<IPersonService, PersonService>();
            
            services.AddScoped<IOccupationService, OccupationService>();
            services.AddScoped<ICommunityGroupService, CommunityGroupService>();

            services.AddScoped<IAuthService, AuthService>();

            
            services.AddSingleton<IValidator<UserForRegisterDto>, UserRegisterDtoValidator>();
            services.AddSingleton<IValidator<UserLoginDto>, UserLoginDtoValidator>();
            services.AddSingleton<IValidator<PersonDto>, PersonDtoValidator>();

        }
    }
}
