using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Core
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Extension method to add Core services to the dependency injection container
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            //TO DO: Add services to the IoC container
            //Core services such as domain services, business logic components, interfaces etc. will be registered here.

            return services;
        }
    }
}
