using DataAccessLayer.Models;
using Service.Shapes;
using Service.Shapes.Strategy;
using Shapes.Edit;
using Shapes.UI;
using Spectre.Console;

namespace Shapes.ReadAll
{
    public class ReadAllShapes : IReadAllShapes
    {
        private readonly IShapeService _shapeService;
        private readonly IEditShape _editShape;
        private readonly Dictionary<string, IShapeStrategy> _strategyResolver;

        public ReadAllShapes(IShapeService shapeService, IEditShape editShape, IEnumerable<IShapeStrategy> strategies)
        {
            _shapeService = shapeService;
            _editShape = editShape;
            _strategyResolver = strategies.ToDictionary(s => s.ShapeType);
        }
        public void ShowAllShapes()
        {
            var shapes = _shapeService.GetAllShapes();
            int pageSize = 10;
            int page = 0;
            int totalPages = (int)Math.Ceiling(shapes.Count / (double)pageSize);

            while (true)
            {
                Console.Clear();
                Graphics.RenderShapes();

                var formattedChoices = shapes
                    .Select(s => new
                    {
                        Display = string.Format("{0,-14} {1,8:0.00} {2,8:0.00} {3,14}", s.ShapeType, s.Area, s.Perimeter, s.CalculatedAt.ToShortDateString()),
                        Data = s
                    })
                    .ToList();

                var menuItems = formattedChoices
                    .Select(f => f.Display)
                    .Append("[red]Tillbaka[/]")
                    .ToList();

                AnsiConsole.MarkupLine($"[bold aqua]             Tidigare formuträkningar\n  Välj en form (enter) för att ta bort eller ändra.[/]");
                AnsiConsole.MarkupLine("\n[aqua][bold]  Form              Area     Omkrets   Datum[/][/]");

                var selectedDisplay = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .HighlightStyle("blue")
                        .PageSize(pageSize + 1)
                        .MoreChoicesText("[grey] (bläddra ↑/↓/PgUp/PgDn [red]Tillbaka[/] finns längst ned)[/]")
                        .AddChoices(menuItems)
                );

                if (selectedDisplay == "[red]Tillbaka[/]")
                    return;

                var selected = formattedChoices.First(f => f.Display == selectedDisplay).Data;
                EditSelectedShape(selected);
            }
        }

        private void EditSelectedShape(ShapeCalculation selected)
        {
            Console.Clear();
            Graphics.RenderShapes();
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

            var action = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title($"[aqua]\n  Vad vill du göra?[/]")
                .HighlightStyle("blue")
                .AddChoices("Ändra", "Ta bort", "[red]Tillbaka[/]")
            );

            switch (action)
            {
                case "Ändra":
                    _editShape.AskForShapeParameters(selected, false);
                    break;
                case "Ta bort":
                    //_shapeService.DeleteShape(selected);
                    AnsiConsole.MarkupLine($"[bold aqua]  Form borttagen. Tryck på någon knapp för att återgå...[/]");
                    Console.ReadKey();
                    break;
                case "[red]Tillbaka[/]":
                    break;
            }
        }
    }
}
