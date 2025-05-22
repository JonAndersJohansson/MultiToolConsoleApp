using DataAccessLayer.Models;
using Service.Shapes;
using Service.Shapes.Strategy;
using Shapes.Edit;
using Shapes.UI;
using Spectre.Console;

namespace Shapes.Menu
{
    public class ShapesMenu : IShapesMenu
    {
        private readonly IEditShape _editShape;

        public ShapesMenu(IEditShape editShape)
        {
            _editShape = editShape;
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
                    case "Parallellogram":
                    case "Romb":
                    case "Triangel":
                        ShapeCalculation shape = new ShapeCalculation();
                        shape.ShapeType = userInput;
                        _editShape.AskForShapeParameters(shape);
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
        //public void AskForShapeParameters(ShapeCalculation shape)
        //{
        //    Console.Clear();
        //    Graphics.RenderShapes();
        //    AnsiConsole.MarkupLine($"[aqua]  Du har valt att skapa en {shape.ShapeType}.[/]");

        //    var strategy = _strategyResolver[shape.ShapeType]; // Dictionary eller Autofac Named-resolver

        //    var prompts = strategy.ParameterPrompts;
        //    var parameters = new List<double>();

        //    foreach (var prompt in prompts)
        //    {
        //        double value = AnsiConsole.Prompt(
        //            new TextPrompt<double>($"\n[aqua]  Ange {prompt}[/]:")
        //                //.PromptStyle("aqua")
        //                .ValidationErrorMessage("[red]  Fel: Du måste ange ett tal.[/]")
        //                .Validate(input =>
        //                    input > 0 ? ValidationResult.Success() :
        //                    ValidationResult.Error("[red]  Värdet måste vara större än 0.[/]"))
        //        );

        //        parameters.Add(value);
        //    }


        //    var area = Math.Round(strategy.CalculateArea(parameters.ToArray()), 2);
        //    var perimeter = Math.Round(strategy.CalculatePerimeter(parameters.ToArray()), 2);

        //    AnsiConsole.MarkupLine($"\n[green]  Area: {area}[/]");
        //    AnsiConsole.MarkupLine($"[green]  Omkrets: {perimeter}[/]");

        //    Console.ReadKey();
        //    // Spara till databasen...
        //    //_shapeService.CreateCalculation(shape, parameters.ToArray(), area, perimeter);

        //    AnsiConsole.MarkupLine("[grey]Tryck valfri tangent för att återgå till menyn.[/]");
        //    Console.ReadKey();
        //}
    }
}
