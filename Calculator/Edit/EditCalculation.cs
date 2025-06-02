using Calculator.UI;
using DataAccessLayer.DTOs;
using Spectre.Console;

namespace Calculator.Edit
{
    public class EditCalculation : IEditCalculation
    {
        private readonly Dictionary<string, ICalculatorStrategy> _strategyResolver;
        private readonly ICalculatorService _calcService;

        public EditCalculation(IEnumerable<ICalculatorStrategy> strategies, ICalculatorService calcService)
        {
            _strategyResolver = strategies.ToDictionary(c => c.Operator);
            _calcService = calcService;
        }

        public void AskForCalcParameters(CalculatorOperationDto calcDto, bool isNew)
        {
            while (true)
            {
                Console.Clear();
                Graphics.RenderCalculator();

                if (isNew)
                {
                    AnsiConsole.MarkupLine($"[aqua]  Du har valt att skapa en [white]uträkning[/].[/][red] 'exit' = Avbryt[/]\n");
                }
                else
                {
                    DisplayCalcProps(calcDto);
                    AnsiConsole.MarkupLine($"[aqua]\n  Ändrar [white]uträkning[/]. Ange nya värden.[/][red] 'exit' = Avbryt[/]\n");
                }

                if (!_strategyResolver.TryGetValue(calcDto.Operator, out var strategy))
                {
                    AnsiConsole.MarkupLine("[red]\n  Fel: Operatorstrategi saknas.[/]");
                    AnsiConsole.MarkupLine("[grey]  Tryck valfri tangent för att återgå.[/]");
                    Console.ReadKey();
                    return;
                }

                var prompts = strategy.ParameterPrompts;
                var parameters = new List<double>();
                bool inputValid = true;

                for (int i = 0; i < prompts.Length; i++)
                {
                    string prompt = prompts[i];

                    string input = AnsiConsole.Ask<string>($"\n[aqua]  Ange [white]{prompt}[/] och tryck 'Enter':[/]");

                    if (input.Trim().ToLower() == "exit")
                        return;

                    if (!double.TryParse(input, out double value))
                    {
                        AnsiConsole.MarkupLine("[red]\n  Fel: Du måste ange ett giltigt tal.[/]");
                        AnsiConsole.MarkupLine("[grey]  Tryck valfri tangent för att försöka igen.[/]");
                        Console.ReadKey();
                        inputValid = false;
                        break;
                    }

                    if (value <= 0)
                    {
                        AnsiConsole.MarkupLine("[red]\n  Fel: Värdet måste vara större än 0.[/]");
                        AnsiConsole.MarkupLine("[grey]  Tryck valfri tangent för att försöka igen.[/]");
                        Console.ReadKey();
                        inputValid = false;
                        break;
                    }

                    parameters.Add(value);
                }

                if (!inputValid)
                {
                    continue;
                }

                var result = Math.Round(strategy.Calculate(parameters.ToArray()), 2);

                AnsiConsole.MarkupLine($"[aqua]\n  Resultat: {result} sparad.[/]");
                AnsiConsole.MarkupLine($"[aqua]\n  Uträkning sparad.[/]");
                AnsiConsole.MarkupLine($"[grey]\n  Tryck valfri tangent för att återgå till menyn.[/]");

                _calcService.Save(calcDto, parameters.ToArray(), result, isNew);

                Console.ReadKey();
                break;
            }
        }

        public void EditSelectedCalc(CalculatorOperationDto selected)
        {
            Console.Clear();
            Graphics.RenderCalculator();

            DisplayCalcProps(selected);

            var action = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title($"[aqua]\n  Vad vill du göra med denna uträkning?[/]")
                    .HighlightStyle("blue")
                    .AddChoices("Ändra", "Ta bort", "[red]Tillbaka[/]")
            );

            switch (action)
            {
                case "Ändra":
                    AskForCalcParameters(selected, false);
                    break;
                case "Ta bort":
                    _calcService.DeleteCalc(selected);
                    AnsiConsole.MarkupLine($"[green]\n  Uträkning borttagen.[/]\n  [grey]Tryck på någon knapp för att återgå.[/]");
                    Console.ReadKey();
                    break;
                case "[red]Tillbaka[/]":
                    break;
            }
        }

        private void DisplayCalcProps(CalculatorOperationDto selected)
        {
            var chosenCalcDisplay = string.Format("{0,-14} {1,8} {2,8:0.00} {3,14}",
                                                  selected.Number1,
                                                  selected.Operator,
                                                  selected.Number2,
                                                  selected.Result);

            AnsiConsole.MarkupLine("\n[aqua][bold]  Uträkning         Nr1   Operation   Nr2     Resultat[/][/]");
            AnsiConsole.MarkupLine($"  {chosenCalcDisplay}\n");

            if (_strategyResolver.TryGetValue(selected.Operator, out var strategy))
            {
                var prompts = strategy.ParameterPrompts;

                for (int i = 0; i < prompts.Length; i++)
                {
                    string prompt = prompts[i];
                    double? value = i switch
                    {
                        0 => selected.Number1,
                        1 => selected.Number2,
                        _ => null
                    };

                    if (value.HasValue)
                        AnsiConsole.MarkupLine($"  [aqua]{prompt}:[/] {value:0.##}");
                }
            }
            else
            {
                AnsiConsole.MarkupLine("[red]  Fel: Operatorstrategi saknas.[/]");
            }
        }
    }
}
