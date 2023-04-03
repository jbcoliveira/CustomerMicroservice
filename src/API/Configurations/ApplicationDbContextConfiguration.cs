using Data.Context;
using Microsoft.EntityFrameworkCore;

namespace API.Configurations
{
    public static class ApplicationDbContextConfiguration
    {
        public static IServiceCollection AddDbContextConfig(this IServiceCollection services,
          IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("MentoriaConnection")));

            return services;
        }
    }
}