using AmsApi.DataModel.Repository;
using AmsApi.DataModel.Repository.Interface;
using AmsApi.Mapper;
using AmsApi.Services;
using AmsApi.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
            services.AddScoped<ITokenService, TokenService>();
        }
    }
}
