using Calculator.Edit;
using Calculator.ReadAll;
using Calculator.UI;
using DataAccessLayer.DTOs;
using Spectre.Console;

namespace Calculator.Menu
{
    public class CalculatorMenu : ICalculatorMenu
    {
        private readonly IEditCalculation _editCalculation;
        private readonly IReadAllCalculations _readAllCalculations;

        public CalculatorMenu(IEditCalculation editCalculation, IReadAllCalculations readAllCalculations)
        {
            _editCalculation = editCalculation;
            _readAllCalculations = readAllCalculations;
        }
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
                        _editCalculation.AskForCalcParameters(calcDto, true);
                        break;
                    case "Visa tidigare uträkningar, ta bort eller ändra":
                        _readAllCalculations.ShowAllCalculations();
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
