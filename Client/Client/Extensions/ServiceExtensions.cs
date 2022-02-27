using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Flurl.Http.Configuration;
using Infastucture.Repositories;
using Infastucture.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Client.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserManagementRepository, UserManagementRepository>();
            services.AddScoped<IFridgeRepository, FridgeRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
        }

        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IUserManagementService, UserManagementService>();
            services.AddScoped<IFridgeService, FridgeService>();
            services.AddScoped<IProductService, ProductService>();
        }

        public static void ConfigureHttpContextAccessor(this IServiceCollection services) =>
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        public static void ConfigureFlurlClient(this IServiceCollection services) =>
            services.AddSingleton<IFlurlClientFactory, PerBaseUrlFlurlClientFactory>();
    }
}