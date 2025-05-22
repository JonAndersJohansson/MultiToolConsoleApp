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
            Console.Clear();
            Graphics.RenderShapes();
            if (isCreateNewShape)
                AnsiConsole.MarkupLine($"[aqua]  Du har valt att skapa en {shape.ShapeType}.[/]");
            else
                AnsiConsole.MarkupLine($"[aqua]  Du har valt att redigera en {shape.ShapeType}.[/]");
            

            var strategy = _strategyResolver[shape.ShapeType];

            var prompts = strategy.ParameterPrompts;
            var parameters = new List<double>();

            foreach (var prompt in prompts)
            {
                double value = AnsiConsole.Prompt(
                    new TextPrompt<double>($"\n[aqua]  Ange {prompt}[/]:")
                        .ValidationErrorMessage("[red]  Fel: Du måste ange ett tal.[/]")
                        .Validate(input =>
                            input > 0 ? ValidationResult.Success() :
                            ValidationResult.Error("[red]  Värdet måste vara större än 0.[/]"))
                );

                parameters.Add(value);
            }


            var area = Math.Round(strategy.CalculateArea(parameters.ToArray()), 2);
            var perimeter = Math.Round(strategy.CalculatePerimeter(parameters.ToArray()), 2);

            AnsiConsole.MarkupLine($"\n[green]  Area: {area}[/]");
            AnsiConsole.MarkupLine($"[green]  Omkrets: {perimeter}[/]");

            _shapeService.Save(shape, parameters.ToArray(), area, perimeter);

            AnsiConsole.MarkupLine("[grey]  Tryck valfri tangent för att återgå till menyn.[/]");
            Console.ReadKey();
        }
    }
}
