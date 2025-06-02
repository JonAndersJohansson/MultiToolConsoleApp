using Calculator.Edit;
using Calculator.UI;
using Service.Calculator;
using Spectre.Console;

namespace Calculator.ReadAll
{
    public class ReadAllCalculations : IReadAllCalculations
    {
        private readonly ICalculatorService _calcService;
        private readonly IEditCalculation _editCalc;

        public ReadAllCalculations(ICalculatorService calculatorService, IEditCalculation editCalculation)
        {
            _calcService = calculatorService;
            _editCalc = editCalculation;
        }
        public void ShowAllCalculations()
        {
            int pageSize = 10;

            while (true)
            {
                Console.Clear();
                Graphics.RenderCalculator();

                var calcs = _calcService.GetAllCalculations();
                int totalPages = (int)Math.Ceiling(calcs.Count / (double)pageSize);

                var formattedChoices = calcs
                    .Select(c => new
                    {
                        Display = string.Format("{0,-14} {1,8:0.00} {2,8:0.00} {3,14}", c.Number1, c.Operator, c.Number2, c.PerformedAt.ToShortDateString()),
                        Data = c
                    })
                    .ToList();

                var menuItems = formattedChoices
                    .Select(f => f.Display)
                    .Append("[red]Tillbaka[/]")
                    .ToList();

                AnsiConsole.MarkupLine($"[bold aqua]  Tidigare uträkningar sorterad efter datum\n  Välj en uträkning (enter) för att [red]ta bort[/] eller [yellow]ändra[/][/]");
                AnsiConsole.MarkupLine("\n[aqua][bold]  Uträkning          Tal1     Tal2    Resultat     Datum[/][/]");

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
                _editCalc.EditSelectedCalc(selected);
            }
        }
    }
}
