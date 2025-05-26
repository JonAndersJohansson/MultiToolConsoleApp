using DataAccessLayer.Models;
using Service.Shapes.Strategy;
using Service.Shapes;
using Shapes.UI;
using Spectre.Console;

namespace Shapes.Edit
{
    public class EditShape : IEditShape
    {
        private readonly Dictionary<string, IShapeStrategy> _strategyResolver;
        private readonly IShapeService _shapeService;
        public EditShape(IEnumerable<IShapeStrategy> strategies, IShapeService shapeService)
        {
            _strategyResolver = strategies.ToDictionary(s => s.ShapeType);
            _shapeService = shapeService;
        }
        public void AskForShapeParameters(ShapeCalculation shape, bool isCreateNewShape)
        {
            bool isValidShape = true;

            while (isValidShape)
            {
                Console.Clear();
                Graphics.RenderShapes();
                if (isCreateNewShape)
                    AnsiConsole.MarkupLine($"[aqua]  Du har valt att skapa en {shape.ShapeType}.[/][red] 'exit' = Avbryt[/] ");
                else
                    AnsiConsole.MarkupLine($"[aqua]  Du har valt att redigera en {shape.ShapeType}.[/]");


                var strategy = _strategyResolver[shape.ShapeType];

                var prompts = strategy.ParameterPrompts;
                var parameters = new List<double>();

                for (int i = 0; i < prompts.Length; i++)
                {
                    var prompt = prompts[i];

                    string input = AnsiConsole.Ask<string>($"\n[aqua]  Ange {prompt}:[/]");

                    if (input.Trim().ToLower() == "exit")
                        return;

                    if (!double.TryParse(input, out double value))
                    {
                        AnsiConsole.MarkupLine("[red]\n  Fel: Du måste ange ett giltigt tal.[/]");
                        AnsiConsole.MarkupLine("[grey]  Tryck valfri tangent för att försöka igen.[/]");
                        Console.ReadKey();
                        isValidShape = false;
                        break;
                    }

                    if (value <= 0)
                    {
                        AnsiConsole.MarkupLine("[red]\n  Fel: Värdet måste vara större än 0.[/]");
                        AnsiConsole.MarkupLine("[grey]  Tryck valfri tangent för att försöka igen.[/]");
                        Console.ReadKey();
                        isValidShape = false;
                        break;
                    }

                    parameters.Add(value);
                }
                if (!isValidShape)
                {
                    isValidShape = true;
                    continue;
                }
                    

                var area = Math.Round(strategy.CalculateArea(parameters.ToArray()), 2);
                var perimeter = Math.Round(strategy.CalculatePerimeter(parameters.ToArray()), 2);
                if (area == -88)
                {
                    AnsiConsole.MarkupLine("[red]\n  Fel: Ogiltiga parametrar för triangel.[/]");
                    AnsiConsole.MarkupLine("[grey]  Tryck valfri tangent för att försöka igen.[/]");
                    Console.ReadKey();
                    continue;
                }

                AnsiConsole.MarkupLine($"\n[green]  Area: {area}[/]");
                AnsiConsole.MarkupLine($"[green]  Omkrets: {perimeter}[/]");

                _shapeService.Save(shape, parameters.ToArray(), area, perimeter);

                AnsiConsole.MarkupLine("[grey]  Tryck valfri tangent för att återgå till menyn.[/]");
                Console.ReadKey();
                break;
            }

        }
    }
}
