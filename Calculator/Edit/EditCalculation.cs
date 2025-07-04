﻿using Calculator.UI;
using DataAccessLayer.DTOs;
using Service.Calculator;
using Service.Calculator.Strategy;
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

                string input1 = AnsiConsole.Ask<string>("\n[aqua]  Ange [white]Tal 1[/] och tryck 'Enter':[/]");
                if (input1.Trim().ToLower() == "exit") return;

                if (!double.TryParse(input1, out double number1))
                {
                    AnsiConsole.MarkupLine("[red]\n  Fel: Du måste ange ett giltigt tal.[/]");
                    AnsiConsole.MarkupLine("[grey]  Tryck valfri tangent för att försöka igen.[/]");
                    Console.ReadKey();
                    continue;
                }

                string operatorInput = AnsiConsole.Ask<string>("\n[aqua]  Ange [white]operator (+, -, *, /, √, %)[/] och tryck 'Enter':[/]");
                if (operatorInput.Trim().ToLower() == "exit") return;

                if (!_strategyResolver.TryGetValue(operatorInput, out var strategy))
                {
                    AnsiConsole.MarkupLine("[red]\n  Fel: Operatorstrategi saknas eller är ogiltig.[/]");
                    AnsiConsole.MarkupLine("[grey]  Tryck valfri tangent för att försöka igen.[/]");
                    Console.ReadKey();
                    continue;
                }

                var parameters = new List<double> { number1 };

                if (strategy.ParameterPrompts.Length > 1)
                {
                    string input2 = AnsiConsole.Ask<string>($"\n[aqua]  Ange [white]{strategy.ParameterPrompts[1]}[/] och tryck 'Enter':[/]");
                    if (input2.Trim().ToLower() == "exit") return;

                    if (!double.TryParse(input2, out double number2))
                    {
                        AnsiConsole.MarkupLine("[red]\n  Fel: Du måste ange ett giltigt tal.[/]");
                        AnsiConsole.MarkupLine("[grey]  Tryck valfri tangent för att försöka igen.[/]");
                        Console.ReadKey();
                        continue;
                    }

                    parameters.Add(number2);
                }

                if (operatorInput == "√" && number1 < 0)
                {
                    AnsiConsole.MarkupLine("[red]\n  Fel: Talet måste vara större än eller lika med 0 för att räkna ut roten ur.[/]");
                    AnsiConsole.MarkupLine("[grey]  Tryck valfri tangent för att försöka igen.[/]");
                    Console.ReadKey();
                    continue;
                }

                double result;
                try
                {
                    result = Math.Round(strategy.GetResult(parameters.ToArray()), 2);
                }
                catch (DivideByZeroException ex)
                {
                    AnsiConsole.MarkupLine($"[red]\n  Fel: {ex.Message}[/]");
                    AnsiConsole.MarkupLine("[grey]  Tryck valfri tangent för att försöka igen.[/]");
                    Console.ReadKey();
                    continue;
                }
                catch (Exception ex)
                {
                    AnsiConsole.MarkupLine($"[red]\n  Fel: {ex.Message}[/]");
                    AnsiConsole.MarkupLine("[grey]  Tryck valfri tangent för att försöka igen.[/]");
                    Console.ReadKey();
                    continue;
                }

                AnsiConsole.MarkupLine($"[aqua]\n  Resultat:[/][white] {result}[/]");

                calcDto.Number1 = number1;
                calcDto.Number2 = parameters.Count > 1 ? parameters[1] : null;
                calcDto.Operator = operatorInput;
                calcDto.Result = result;
                calcDto.PerformedAt = DateTime.Now;

                _calcService.Save(calcDto, parameters.ToArray(), result, isNew);

                AnsiConsole.MarkupLine($"[aqua]\n  Uträkning sparad.[/]");
                AnsiConsole.MarkupLine($"[grey]\n  Tryck valfri tangent för att återgå till menyn.[/]");

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
                    _calcService.DeleteCalculation(selected);
                    AnsiConsole.MarkupLine($"[green]\n  Uträkning borttagen.[/]\n  [grey]Tryck på någon knapp för att återgå.[/]");
                    Console.ReadKey();
                    break;
                case "[red]Tillbaka[/]":
                    break;
            }
        }

        private void DisplayCalcProps(CalculatorOperationDto selected)
        {
            var chosenCalcDisplay = string.Format("{0,-10} {1,-10} {2,-10} {3,-12} {4,-12}",
                selected.Number1.HasValue ? selected.Number1.Value.ToString("0.##") : "-",
                selected.Operator ?? "-",
                selected.Number2.HasValue ? selected.Number2.Value.ToString("0.##") : "-",
                selected.Result.ToString("0.##"),
                selected.PerformedAt.ToShortDateString());

            AnsiConsole.MarkupLine("\n[aqua][bold]  Tal1       Op        Tal2     Resultat        Datum[/][/]");
            AnsiConsole.MarkupLine($"  {chosenCalcDisplay}\n");
        }
    }
}
