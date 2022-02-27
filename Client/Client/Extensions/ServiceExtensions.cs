using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Infastucture.Repositories;
using Infastucture.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Client.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserManagementRepository, UserManagementRepository>();
        }
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IUserManagementService, UserManagementService>();
        }
    }
}