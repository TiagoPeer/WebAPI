using Microsoft.EntityFrameworkCore;

namespace WebAPI.Data
{
    public static class DbExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(
                o => o.UseSqlServer(configuration.GetConnectionString("SqlConnection"),
                b => b.MigrationsAssembly("SneakerAPI")));
        }
    }
}