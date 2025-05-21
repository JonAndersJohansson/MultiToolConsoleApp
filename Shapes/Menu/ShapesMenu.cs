using Shapes.UI;
using Spectre.Console;

namespace Shapes.Menu
{
    public class ShapesMenu : IShapesMenu
    {
        public void Show()
        {
            while (true)
            {
                Console.Clear();
                Graphics.RenderShapes();

                var userInput = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("[aqua]  Välkommen till Formuträknaren. Välj form:[/]")
                        .PageSize(10)
                        .MoreChoicesText("  [grey](Pila upp eller ned)[/]")
                        .AddChoices(new[] {
                            "Rektangel", "Parallellogram", "Triangel", "Romb", "[maroon]Tillbaka[/]",
                        }));

                switch (userInput)
                {
                    case "Rektangel":
                        //rektangel
                        break;
                    case "Parallellogram":
                        //parallellogram
                        break;
                    case "Triangel":
                        //triangel
                        break;
                    case "Romb":
                        //Romb
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
    }
}
