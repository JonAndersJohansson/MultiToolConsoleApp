using Service.Shapes;
using Service.Shapes.Strategy;
using Shapes.UI;
using Spectre.Console;

namespace Shapes.Menu
{
    public class ShapesMenu : IShapesMenu
    {
        private readonly Dictionary<string, IShapeStrategy> _strategyResolver;
        private readonly IShapeService _shapeService;

        public ShapesMenu(IEnumerable<IShapeStrategy> strategies, IShapeService shapeService)
        {
            _strategyResolver = strategies.ToDictionary(s => s.ShapeType);
            _shapeService = shapeService;
        }
        public void ShapesMainMenu()
        {
            while (true)
            {
                Console.Clear();
                Graphics.RenderShapes();

                var userInput = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("[aqua]  Välkommen till Formuträknaren. Välj:[/]")
                        .PageSize(10)
                        .MoreChoicesText("  [grey](Pila upp eller ned)[/]")
                        .AddChoices(new[] {
                            "Skapa och beräkna form", "Visa tidigare uträkningar", "[maroon]Tillbaka[/]",
                        }));

                switch (userInput)
                {
                    case "Skapa och beräkna form":
                        ChooseShapeMenu();
                        break;
                    case "Visa tidigare uträkningar":
                        //parallellogram
                        break;
                    case "[maroon]Tillbaka[/]":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val. Tryck valfri tangent.");
                        Console.ReadKey();
                        break;
                }
            }
        }
        public void ChooseShapeMenu()
        {
            while (true)
            {
                Console.Clear();
                Graphics.RenderShapes();

                var userInput = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("[aqua]  Välj form:[/]")
                        .PageSize(10)
                        .MoreChoicesText("  [grey](Pila upp eller ned)[/]")
                        .AddChoices(new[] {
                            "Rektangel", "Parallellogram", "Triangel", "Romb", "[maroon]Tillbaka[/]",
                        }));

                switch (userInput)
                {
                    case "Rektangel":
                        CreateShapeMenu(userInput);
                        break;
                    case "Parallellogram":
                        CreateShapeMenu(userInput);
                        break;
                    case "Triangel":
                        CreateShapeMenu(userInput);
                        break;
                    case "Romb":
                        CreateShapeMenu(userInput);
                        break;
                    case "[maroon]Tillbaka[/]":
                        return;
                    default:
                        Console.WriteLine("Ogiltigt val. Tryck valfri tangent.");
                        Console.ReadKey();
                        break;
                }
            }
        }
        public void CreateShapeMenu(string shape)
        {
            Console.Clear();
            Graphics.RenderShapes();
            AnsiConsole.MarkupLine($"[aqua]Du har valt att skapa en {shape}.[/]");

            var strategy = _strategyResolver[shape]; // Dictionary eller Autofac Named-resolver

            var prompts = strategy.ParameterPrompts;
            var parameters = new List<double>();

            foreach (var prompt in prompts)
            {
                double value = AnsiConsole.Ask<double>($"[aqua]{prompt}[/]:");
                parameters.Add(value);
            }

            var area = strategy.CalculateArea(parameters.ToArray());
            var perimeter = strategy.CalculatePerimeter(parameters.ToArray());

            AnsiConsole.MarkupLine($"[green]Area: {area}[/]");
            AnsiConsole.MarkupLine($"[green]Omkrets: {perimeter}[/]");

            Console.ReadKey();
            // Spara till databasen...
            _shapeService.CreateCalculation(shape, parameters.ToArray(), area, perimeter);

            AnsiConsole.MarkupLine("[grey]Tryck valfri tangent för att återgå till menyn.[/]");
            Console.ReadKey();
        }
    }
}
