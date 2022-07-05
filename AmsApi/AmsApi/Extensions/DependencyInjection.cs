using AmsApi.DataModel.Models;
using AmsApi.DataModel.Repository;
using AmsApi.DataModel.Repository.Interface;
using AmsApi.Mapper;
using AmsApi.Services;
using AmsApi.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AmsApi.Extensions
{
    public static class DependencyInjection
    {
        public static void ConfigureDomainServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IRequestRepository, RequestRepository>();
            services.AddScoped<IRequestService, RequestService>();
            services.AddScoped<IRequestStatusRepository, RequestStatusRepository>();
            services.AddScoped<IRequestStatusService, RequestStatusService>();
            services.AddScoped<IUserLoginRepository, UserLoginRepository>();
            services.AddScoped<IUserLoginService, UserLoginService>();
            services.AddScoped<IUserRequestsRepository, UserRequestsRepository>();
            services.AddScoped<IUserRequestsService, UserRequestsService>();
            services.AddAutoMapper(typeof(ProfileMapper));
            services.AddScoped<IFileUploadRepository, FileUploadRepository>();
            services.AddScoped<IFileUploadService, FileUploadService>();
            services.AddScoped<IForgotPasswordRepository, ForgotPasswordRepository>();
            services.AddScoped<IForgotPasswordService, ForgotPasswordService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => options.TokenValidationParameters =
                new TokenValidationParameters
                {

                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenKey"])),
                    ValidateIssuer = false,
                    ValidateAudience = false

                });
            services.AddAuthorization(config =>
            {
                config.AddPolicy(UserRoles.CountryManager, Policies.CountryManagerPolicy());
                config.AddPolicy(UserRoles.SuperManager, Policies.SuperManagerPolicy());
                config.AddPolicy(UserRoles.Manager, Policies.ManagerPolicy());
                config.AddPolicy(UserRoles.Employee, Policies.EmployeePolicy());
            });
        }
    }
}
