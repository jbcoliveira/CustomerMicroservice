using Business.Interfaces.Repositories;
using Business.Interfaces.Services;
using Business.Services;
using Data.Repositories;

namespace API.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerService, CustomerService>();
            return services;
        }
    }
}
