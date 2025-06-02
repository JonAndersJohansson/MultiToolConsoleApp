using Calculator.UI;
using DataAccessLayer.DTOs;
using Spectre.Console;

namespace Calculator.Menu
{
    public class CalculatorMenu : ICalculatorMenu
    {
        public void CalculatorMainMenu()
        {
            while (true)
            {
                Console.Clear();
                Graphics.RenderCalculator();

                var userInput = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("[aqua]  Välkommen till Miniräknaren. Välj:[/]")
                        .PageSize(10)
                        .MoreChoicesText("  [grey](Pila upp eller ned)[/]")
                        .AddChoices(new[] {
                            "Skapa uträkning", "Visa tidigare uträkningar, ta bort eller ändra", "[maroon]Tillbaka[/]",
                        }));

                switch (userInput)
                {
                    case "Skapa uträkning":
                        CalculatorOperationDto calcDto = new CalculatorOperationDto();
                        //_editCalculation.AskForCalcParameters(calcDto, true);
                        break;
                        break;
                    case "Visa tidigare uträkningar, ta bort eller ändra":
                        //_readAllCalculations.ShowAllCalculations();
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
        //public void ChooseShapeMenu()
        //{
        //    while (true)
        //    {
        //        Console.Clear();
        //        Graphics.RenderShapes();

        //        var userInput = AnsiConsole.Prompt(
        //            new SelectionPrompt<string>()
        //                .Title("[aqua]  Välj form att skapa:[/]")
        //                .PageSize(10)
        //                .MoreChoicesText("  [grey](Pila upp eller ned)[/]")
        //                .AddChoices(new[] {
        //                    "Rektangel", "Parallellogram", "Triangel", "Romb", "[maroon]Tillbaka[/]",
        //                }));

        //        switch (userInput)
        //        {
        //            case "Rektangel":
        //            case "Parallellogram":
        //            case "Romb":
        //            case "Triangel":
        //                ShapeCalculationDto shapeDto = new ShapeCalculationDto();
        //                shapeDto.ShapeType = userInput;
        //                _editShape.AskForShapeParameters(shapeDto, true);
        //                break;
        //            case "[maroon]Tillbaka[/]":
        //                return;
        //            default:
        //                Console.WriteLine("Ogiltigt val. Tryck valfri tangent.");
        //                Console.ReadKey();
        //                break;
        //        }
        //    }
        //}
    }
}
