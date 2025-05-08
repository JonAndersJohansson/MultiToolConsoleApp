using DataAccessLayer.Data;
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
                .ConfigureAppConfiguration(config =>
                {
                    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                })
                .ConfigureServices((context, services) =>
                {
                    DatabaseBootstrapper.ConfigureDatabase(services, context.Configuration);;

                    //Service
                    services.AddScoped<IRpsService, RpsService>();

                    //Menu
                    services.AddScoped<IRpsMenu, RpsMenu>();
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
