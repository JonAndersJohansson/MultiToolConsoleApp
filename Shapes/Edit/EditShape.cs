using DataAccessLayer.DTOs;
using DataAccessLayer.Models;
using Service.Shapes;
using Service.Shapes.Strategy;
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
        public void AskForShapeParameters(ShapeCalculationDto shapeDto, bool isNewShape)
        {
            bool isValidShape = true;

            while (isValidShape)
            {
                Console.Clear();
                Graphics.RenderShapes();

                if (isNewShape)
                    AnsiConsole.MarkupLine($"[aqua]  Du har valt att skapa en [white]{shapeDto.ShapeType}[/].[/][red] 'exit' = Avbryt[/]\n");
                else
                {
                    DisplayShapeProps(shapeDto);
                    AnsiConsole.MarkupLine($"[aqua]\n  Ändrar [white]{shapeDto.ShapeType}[/]. Ange nya värden.[/][red] 'exit' = Avbryt[/]\n");
                }

                var strategy = _strategyResolver[shapeDto.ShapeType];

                var prompts = strategy.ParameterPrompts;
                var parameters = new List<double>();

                for (int i = 0; i < prompts.Length; i++)
                {
                    var prompt = prompts[i];

                    string input = AnsiConsole.Ask<string>($"\n[aqua]  Ange [white]{prompt}[/] och tryck 'Enter':[/]");

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

                AnsiConsole.MarkupLine($"[aqua]\n  {shapeDto.ShapeType} sparad.[/]");
                AnsiConsole.MarkupLine($"[green]  Area: {area}[/]");
                AnsiConsole.MarkupLine($"[green]  Omkrets: {perimeter}[/]");
                AnsiConsole.MarkupLine($"[gray]\n  Tryck valfri tangent för att återgå till menyn.[/]");

                _shapeService.Save(shapeDto, parameters.ToArray(), area, perimeter, isNewShape);

                Console.ReadKey();
                break;
            }
        }
        public void EditSelectedShape(ShapeCalculationDto selected)
        {
            Console.Clear();
            Graphics.RenderShapes();

            DisplayShapeProps(selected);

            var action = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title($"[aqua]\n  Vad vill du göra med denna form?[/]")
                .HighlightStyle("blue")
                .AddChoices("Ändra", "Ta bort", "[red]Tillbaka[/]")
            );

            switch (action)
            {
                case "Ändra":
                    AskForShapeParameters(selected, false);
                    break;
                case "Ta bort":
                    _shapeService.DeleteShape(selected);
                    AnsiConsole.MarkupLine($"[green]\n  Form borttagen.[/]\n  [grey]Tryck på någon knapp för att återgå.[/]");
                    Console.ReadKey();
                    break;
                case "[red]Tillbaka[/]":
                    break;
            }
        }
        private void DisplayShapeProps(ShapeCalculationDto selected)
        {
            var chosenShapeDisplay = string.Format("{0,-14} {1,8:0.00} {2,8:0.00} {3,14}", selected.ShapeType, selected.Area, selected.Perimeter, selected.CalculatedAt.ToShortDateString());

            AnsiConsole.MarkupLine("\n[aqua][bold]  Vald form         Area     Omkrets   Datum[/][/]");
            AnsiConsole.MarkupLine($"  {chosenShapeDisplay}\n");

            var strategy = _strategyResolver[selected.ShapeType];
            var prompts = strategy.ParameterPrompts;

            for (int i = 0; i < prompts.Length; i++)
            {
                string prompt = prompts[i];
                double? value = i switch
                {
                    0 => selected.Param1,
                    1 => selected.Param2,
                    2 => selected.Param3,
                    _ => null
                };

                if (value.HasValue)
                    AnsiConsole.MarkupLine($"  [aqua]{prompt}:[/] {value:0.##}");
            }
        }
    }
}
