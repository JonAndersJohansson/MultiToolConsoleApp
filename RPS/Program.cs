using Autofac;
using Autofac.Extensions.DependencyInjection;
using DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RPS.Menu;
using Service.RPS;

namespace RPS
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Inside RPS");
            Console.ReadKey();

            var host = Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory()) //Autofac
                .ConfigureAppConfiguration(config =>
                {
                    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                })
                .ConfigureContainer<ContainerBuilder>(builder =>
                {
                    builder.Register(ctx =>
                    {
                        var config = ctx.Resolve<IConfiguration>();
                        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
                        optionsBuilder.UseSqlServer(
                            config.GetConnectionString("DefaultConnection"),
                            b => b.MigrationsAssembly("DataAccessLayer")); // Dela migrationsaasembly
                        return new AppDbContext(optionsBuilder.Options);
                    }).AsSelf().InstancePerLifetimeScope();

                    builder.RegisterType<RpsService>().As<IRpsService>().InstancePerLifetimeScope();
                    builder.RegisterType<RpsMenu>().As<IRpsMenu>().InstancePerLifetimeScope();
                })
                .Build();

            // Skapa databas + seeda
            using var scope = host.Services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            DatabaseBootstrapper.EnsureDatabaseCreated(db);

            // Starta meny
            var menu = scope.ServiceProvider.GetRequiredService<IRpsMenu>();
            menu.ShowMenu();
        }
    }
}
