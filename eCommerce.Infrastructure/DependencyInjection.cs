using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Infrastructure
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Extension method to add infrastructure services to the dependency injection container
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            //TO DO: Add services to the IoC container
            //Infrastructure services such as data access, caching, other low-level components etc. will be registered here.

            return services;
        }
    }
}
