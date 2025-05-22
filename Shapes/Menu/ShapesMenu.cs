using Shapes.UI;
using Spectre.Console;

namespace Shapes.Menu
{
    public class ShapesMenu : IShapesMenu
    {
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
                    case "C - Skapa och beräkna form":
                        ChooseShapeMenu();
                        break;
                    case "R - Visa tidigare uträkningar":
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
                        string shape = "Rektangel";
                        CreateShapeMenu(shape);
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
            var age = AnsiConsole.Ask<int>("[aqua]What's your age?");


            // Implement the logic to create and calculate the selected shape here
            // For example, you can prompt the user for dimensions and perform calculations
            Console.WriteLine("Tryck valfri tangent för att återgå till menyn.");
            Console.ReadKey();
        }
    }
}
