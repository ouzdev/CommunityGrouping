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
            services.AddScoped<IAuthService, AuthService>();

            
            services.AddSingleton<IValidator<UserForRegisterDto>, UserForRegisterDtoValidator>();

            //services.AddSingleton<IValidator<UserForLoginDto>, UserForLoginDtoValidator>();
            //services.AddSingleton<IValidator<UserForRegisterDto>, UserForRegisterDtoValidator>();
            //services.AddSingleton<IValidator<UserForChangePasswordDto>, UserForChangePasswordDtoValidator>();
            //services.AddSingleton<IValidator<UserForEditDto>, UserForEditDtoValidator>();

            //services.AddSingleton<IValidator<EmployeeAddDto>, EmployeeAddDtoValidator>();
        }
    }
}
