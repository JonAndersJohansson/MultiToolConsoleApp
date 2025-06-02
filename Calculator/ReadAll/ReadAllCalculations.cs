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
                        Display = string.Format("{0,-10} {1,-10} {2,-10} {3,-12} {4,-12}",
                                                c.Number1.HasValue ? c.Number1.Value.ToString("0.##") : "-",
                                                c.Operator ?? "-",
                                                c.Number2.HasValue ? c.Number2.Value.ToString("0.##") : "-",
                                                c.Result.ToString("0.##"),
                                                c.PerformedAt.ToShortDateString()),
                        Data = c
                    })
                    .ToList();

                var menuItems = formattedChoices
                    .Select(f => f.Display)
                    .Append("[red]Tillbaka[/]")
                    .ToList();

                AnsiConsole.MarkupLine($"[bold aqua]  Tidigare uträkningar sorterade efter datum[/]");
                AnsiConsole.MarkupLine($"[bold aqua]  Välj en uträkning (enter) för att [red]ta bort[/] eller [yellow]ändra[/][/]");

                AnsiConsole.MarkupLine("\n[aqua][bold]  Tal1       Op        Tal2     Resultat        Datum[/][/]");

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
