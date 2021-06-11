using ComputerShop.API.Services;
using ComputerShop.API.Services.Abstracts;
using ComputerShop.Data.Repositories;
using ComputerShop.Data.Repositories.Abstracts;
using Microsoft.Extensions.DependencyInjection;

namespace ComputerShop.API.Utils.Extensions
{
    public static class StartupExtensions
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IConfigurationsService, ConfigurationsService>();
            services.AddScoped<ILaptopService, LaptopService>();
            services.AddScoped<ICardService, CardService>();
        }
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IOrdersRepository, OrdersRepository>();
            services.AddScoped<ILaptopRepository, LaptopRepository>();
            services.AddScoped<IConfigurationsRepository, ConfigurationsRepository>();
        }
    }
}
