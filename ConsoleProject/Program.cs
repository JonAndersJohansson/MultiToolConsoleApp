using Autofac.Extensions.DependencyInjection;
using Client.Menu;
using DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ConsoleProject
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureAppConfiguration(config =>
                {
                    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                })
                .ConfigureServices((context, services) =>
                {
                    var connectionString = context.Configuration.GetConnectionString("DefaultConnection");

                    // DbContext
                    services.AddDbContext<AppDbContext>(options =>
                        options.UseSqlServer(connectionString));

                    // Services
                    //services.AddScoped<IShapeService, ShapeService>();
                    //services.AddScoped<ICalculatorService, CalculatorService>();
                    //services.AddScoped<IRpsService, RpsService>();

                    // Meny
                    services.AddScoped<IMainMenu, MainMenu>();
                })
                .Build();

            
            using var scope = host.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            DataInitializer.Seed(dbContext);

            Console.WriteLine("In client program.cs...");
            Console.ReadLine();

            var mainMenu = scope.ServiceProvider.GetRequiredService<IMainMenu>();
            mainMenu.Show();
        }
    }
}
