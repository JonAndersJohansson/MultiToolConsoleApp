using Autofac;
using Autofac.Extensions.DependencyInjection;
using Calculator.Edit;
using Calculator.Menu;
using DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Service.Calculator;
using Service.Calculator.Strategy;
using Service.Shapes.Strategy;
using Spectre.Console;

namespace Calculator
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            AnsiConsole.MarkupLine("[cyan]  Startar Calculator...[/]");

            IHost host = null;
            IServiceScope scope = null;
            ICalculatorMenu menu = null;
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

                            builder.RegisterType<CalculatorMenu>().As<ICalculatorMenu>().InstancePerLifetimeScope();
                            //builder.RegisterType<ReadAllCalculation>().As<IReadAllCalculations>().InstancePerLifetimeScope();
                            builder.RegisterType<AdditionStrategy>().As<ICalculatorStrategy>();
                            builder.RegisterType<DivisionStrategy>().As<ICalculatorStrategy>();
                            builder.RegisterType<ModulusStrategy>().As<ICalculatorStrategy>();
                            builder.RegisterType<MultiplicationStrategy>().As<ICalculatorStrategy>();
                            builder.RegisterType<SquareRootStrategy>().As<ICalculatorStrategy>();
                            builder.RegisterType<SubtractionStrategy>().As<ICalculatorStrategy>();
                            //builder.RegisterType<CalculatorRepository>().As<ICalculatorRepository>().InstancePerLifetimeScope();
                            builder.RegisterType<CalculatorService>().As<ICalculatorService>().InstancePerLifetimeScope();
                            builder.RegisterType<EditCalculation>().As<IEditCalculation>().InstancePerLifetimeScope();
                        })
                        .Build();

                    scope = host.Services.CreateScope();
                    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                    DatabaseBootstrapper.EnsureDatabaseCreated(db);

                    menu = scope.ServiceProvider.GetRequiredService<ICalculatorMenu>();

                    ctx.Status("  Startar meny...");
                    await Task.Delay(500);
                });

            Console.Clear();
            menu.CalculatorMainMenu();
        }
    }
}

