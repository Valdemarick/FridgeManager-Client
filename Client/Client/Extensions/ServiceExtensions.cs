using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Flurl.Http.Configuration;
using Domain.Repositories;
using Domain.Services;
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
            services.AddScoped<IFridgeModelRepository, FridgeModelRepository>();
            services.AddScoped<IFridgeProductRepository, FridgeProductRepository>();
            services.AddScoped<IServiceManager, ServiceManager>();
        }

        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IUserManagementService, UserManagementService>();
            services.AddScoped<IFridgeService, FridgeService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IFridgeModelService, FridgeModelService>();
            services.AddScoped<IFridgeProductService, FridgeProductService>();
        }

        public static void ConfigureHttpContextAccessor(this IServiceCollection services) =>
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        public static void ConfigureFlurlClient(this IServiceCollection services) =>
            services.AddSingleton<IFlurlClientFactory, PerBaseUrlFlurlClientFactory>();
    }
}