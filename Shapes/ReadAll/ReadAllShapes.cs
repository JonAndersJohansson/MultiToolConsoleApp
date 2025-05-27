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
            int pageSize = 10;

            while (true)
            {
                Console.Clear();
                Graphics.RenderShapes();

                var shapes = _shapeService.GetAllShapes();
                int totalPages = (int)Math.Ceiling(shapes.Count / (double)pageSize);

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

                AnsiConsole.MarkupLine($"[bold aqua]  Tidigare formuträkningar sorterad efter datum\n  Välj en form (enter) för att [red]ta bort[/] eller [yellow]ändra[/][/]");
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
                _editShape.EditSelectedShape(selected);
            }
        }
    }
}
