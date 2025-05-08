using DataAccessLayer.Data;

namespace RPS
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Inside RPS. Close app");
            Console.ReadKey();
            Environment.Exit(0);

            //var host = Host.CreateDefaultBuilder(args)
            //    .ConfigureAppConfiguration(config =>
            //    {
            //        config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            //    })
            //    .ConfigureServices((context, services) =>
            //    {
            //        DatabaseBootstrapper.ConfigureDatabase(services, context.Configuration);
            //        services.AddScoped<IMyService, MyService>();
            //    })
            //.Build();

            //// Skapa databas + seeda
            //using var scope = host.Services.CreateScope();
            //var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            //DatabaseBootstrapper.EnsureDatabaseCreated(db);

            //// Starta meny
            //var service = scope.ServiceProvider.GetRequiredService<IMyService>();
            //await service.ShowMenuAsync();

        }
    }
}
