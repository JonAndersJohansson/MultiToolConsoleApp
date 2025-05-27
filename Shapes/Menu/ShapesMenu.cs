using DataAccessLayer.Models;
using Shapes.Edit;
using Shapes.ReadAll;
using Shapes.UI;
using Spectre.Console;

namespace Shapes.Menu
{
    public class ShapesMenu : IShapesMenu
    {
        private readonly IEditShape _editShape;
        private readonly IReadAllShapes _readAllShapes;

        public ShapesMenu(IEditShape editShape, IReadAllShapes readAllShapes)
        {
            _editShape = editShape;
            _readAllShapes = readAllShapes;
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
                            "Skapa och beräkna form", "Visa tidigare uträkningar, ta bort eller ändra", "[maroon]Tillbaka[/]",
                        }));

                switch (userInput)
                {
                    case "Skapa och beräkna form":
                        ChooseShapeMenu();
                        break;
                    case "Visa tidigare uträkningar, ta bort eller ändra":
                        _readAllShapes.ShowAllShapes();
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
                        .Title("[aqua]  Välj form att skapa:[/]")
                        .PageSize(10)
                        .MoreChoicesText("  [grey](Pila upp eller ned)[/]")
                        .AddChoices(new[] {
                            "Rektangel", "Parallellogram", "Triangel", "Romb", "[maroon]Tillbaka[/]",
                        }));

                switch (userInput)
                {
                    case "Rektangel":
                    case "Parallellogram":
                    case "Romb":
                    case "Triangel":
                        ShapeCalculation shape = new ShapeCalculation();
                        shape.ShapeType = userInput;
                        _editShape.AskForShapeParameters(shape, true);
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
    }
}
