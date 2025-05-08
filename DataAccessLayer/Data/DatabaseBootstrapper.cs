using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccessLayer.Data
{
    public static class DatabaseBootstrapper
    {
        public static void ConfigureDatabase(IServiceCollection services, IConfiguration config)
        {
            var conn = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(opt =>
                opt.UseSqlServer(conn));
        }

        public static void EnsureDatabaseCreated(AppDbContext context)
        {
            //context.Database.EnsureCreated();
            DataInitializer.Seed(context);
        }
    }
}
