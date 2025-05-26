using DataAccessLayer.Models;
using Service.Shapes;
using Shapes.Edit;
using Shapes.UI;
using Spectre.Console;

namespace Shapes.ReadAll
{
    public class ReadAllShapes : IReadAllShapes
    {
        private readonly IShapeService _shapeService;
        private readonly IEditShape _editShape;

        public ReadAllShapes(IShapeService shapeService, IEditShape editShape)
        {
            _shapeService = shapeService;
            _editShape = editShape;
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

            var action = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title($"[aqua]  Vad vill du göra med {selected.ShapeType} från {selected.CalculatedAt.ToShortDateString()}?[/]")
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
