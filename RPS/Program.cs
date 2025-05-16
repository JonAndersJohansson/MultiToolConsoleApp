using Autofac;
using Autofac.Extensions.DependencyInjection;
using DataAccessLayer.Data;
using DataAccessLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RPS.Game;
using RPS.Menu;
using Service.RPS;
using Spectre.Console;
using System.ComponentModel.DataAnnotations;

namespace RPS
{
    public class Program
    {
        //static void Main(string[] args)
        //{
        //    Console.Clear();
        //    Console.WriteLine("Inside RPS Program.cs");
        //    Console.ReadKey();

        //    var host = Host.CreateDefaultBuilder(args)
        //        .UseServiceProviderFactory(new AutofacServiceProviderFactory()) //Autofac
        //        .ConfigureAppConfiguration(config =>
        //        {
        //            config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        //        })
        //        .ConfigureContainer<ContainerBuilder>(builder =>
        //        {
        //            builder.Register(ctx =>
        //            {
        //                var config = ctx.Resolve<IConfiguration>();
        //                var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        //                optionsBuilder.UseSqlServer(
        //                    config.GetConnectionString("DefaultConnection"),
        //                    b => b.MigrationsAssembly("DataAccessLayer")); // Dela migrationsaasembly
        //                return new AppDbContext(optionsBuilder.Options);
        //            }).AsSelf().InstancePerLifetimeScope();

        //            builder.RegisterType<RpsService>().As<IRpsService>().InstancePerLifetimeScope();
        //            builder.RegisterType<RpsMenu>().As<IRpsMenu>().InstancePerLifetimeScope();
        //        })
        //        .Build();

        //    // Skapa databas + seeda
        //    using var scope = host.Services.CreateScope();
        //    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        //    DatabaseBootstrapper.EnsureDatabaseCreated(db);

        //    // Starta meny
        //    var menu = scope.ServiceProvider.GetRequiredService<IRpsMenu>();
        //    Console.WriteLine("CHECK");
        //    Console.ReadKey();
        //    menu.Show();
        //}
        public static async Task Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            AnsiConsole.MarkupLine("[cyan]  Startar RPS...[/]");

            IHost host = null;
            IServiceScope scope = null;
            IRpsMenu menu = null;

            await AnsiConsole.Status()
                .Spinner(Spinner.Known.Star)
                .StartAsync("  Initierar tjänster och databas...", async ctx =>
                {
                    host = Host.CreateDefaultBuilder(args)
                        .UseServiceProviderFactory(new AutofacServiceProviderFactory())
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
                                    b => b.MigrationsAssembly("DataAccessLayer"));
                                return new AppDbContext(optionsBuilder.Options);
                            }).AsSelf().InstancePerLifetimeScope();

                            builder.RegisterType<RpsRepository>().As<IRpsRepository>().InstancePerLifetimeScope();
                            builder.RegisterType<RpsService>().As<IRpsService>().InstancePerLifetimeScope();
                            builder.RegisterType<RpsMenu>().As<IRpsMenu>().InstancePerLifetimeScope();
                            builder.RegisterType<RpsGame>().As<IRpsGame>().InstancePerLifetimeScope();
                        })
                        .Build();

                    scope = host.Services.CreateScope();
                    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                    DatabaseBootstrapper.EnsureDatabaseCreated(db);

                    menu = scope.ServiceProvider.GetRequiredService<IRpsMenu>();

                    ctx.Status("  Startar meny...");
                    await Task.Delay(500);
                });

            Console.Clear();
            menu.Show();
        }

    }
}
