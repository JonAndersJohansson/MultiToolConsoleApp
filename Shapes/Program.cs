using Autofac;
using Autofac.Extensions.DependencyInjection;
using DataAccessLayer.Data;
using DataAccessLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Service.Shapes;
using Service.Shapes.Strategy;
using Shapes.Edit;
using Shapes.Menu;
using Spectre.Console;

namespace Shapes
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            AnsiConsole.MarkupLine("[cyan]  Startar Shapes...[/]");

            IHost host = null;
            IServiceScope scope = null;
            IShapesMenu menu = null;
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

                            builder.RegisterType<ShapesMenu>().As<IShapesMenu>().InstancePerLifetimeScope();
                            builder.RegisterType<RectangleStrategy>().As<IShapeStrategy>();
                            builder.RegisterType<ParallelogramStrategy>().As<IShapeStrategy>();
                            builder.RegisterType<TriangleStrategy>().As<IShapeStrategy>();
                            builder.RegisterType<RhombusStrategy>().As<IShapeStrategy>();
                            builder.RegisterType<EditShape>().As<IEditShape>().InstancePerLifetimeScope();
                            builder.RegisterType<ShapeRepository>().As<IShapeRepository>().InstancePerLifetimeScope();
                            builder.RegisterType<ShapeService>().As<IShapeService>().InstancePerLifetimeScope();
                        })
                        .Build();

                    scope = host.Services.CreateScope();
                    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                    DatabaseBootstrapper.EnsureDatabaseCreated(db);

                    menu = scope.ServiceProvider.GetRequiredService<IShapesMenu>();

                    ctx.Status("  Startar meny...");
                    await Task.Delay(500);
                });

            Console.Clear();
            menu.ShapesMainMenu();
        }
    }
}
