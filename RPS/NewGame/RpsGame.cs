using RPS.UI;
using Service.RPS;
using Service.RPS.Enum;
using Spectre.Console;

namespace RPS.Game
{
    public class RpsGame : IRpsGame
    {
        private readonly IRpsService _rpsService;

        public RpsGame(IRpsService rpsService)
        {
            _rpsService = rpsService;
        }
        public void StartGame()
        {
            while (true)
            {
                var userInput = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("[aqua]  Välj ditt vapen:[/]")
                        .PageSize(10)
                        .MoreChoicesText("[grey]  (Pila upp eller ned)[/]")
                        .AddChoices(new[] {
                    "Sten", "Sax", "Påse", "[maroon]Avbryt spel[/]",
                        }));

                if (userInput == "[maroon]Avbryt spel[/]")
                    break;

                CalculateResult(userInput);
                return;
            }
        }

        private void CalculateResult(string userInput)
        {
            string result = string.Empty;
            GameResult graphicResult = _rpsService.CalculateResult(userInput);
            if (graphicResult == GameResult.Error)
            {
                AnsiConsole.MarkupLine($"[red]Ogiltigt val, tryck på någon tangent för att fortsätta.[/]");
                Console.ReadKey();
                Console.Clear();
                return;
            }

            switch (graphicResult)
            {
                case GameResult.ScissorsScissors:
                    result = "Oavgjort";
                    Graphics.DisplayScissorsScissors();
                    break;
                case GameResult.ScissorsRock:
                    result = "Förlust";
                    Graphics.DisplayScissorsRock();
                    break;
                case GameResult.ScissorsPaper:
                    result = "Vinst";
                    Graphics.DisplayScissorsPaper();
                    break;
                case GameResult.RockRock:
                    result = "Oavgjort";
                    Graphics.DisplayRockRock();
                    break;
                case GameResult.RockScissors:
                    result = "Vinst";
                    Graphics.DisplayRockScissors();
                    break;
                case GameResult.RockPaper:
                    result = "Förlust";
                    Graphics.DisplayRockPaper();
                    break;
                case GameResult.PaperPaper:
                    result = "Oavgjort";
                    Graphics.DisplayPaperPaper();
                    break;
                case GameResult.PaperRock:
                    result = "Vinst";
                    Graphics.DisplayPaperRock();
                    break;
                case GameResult.PaperScissors:
                    result = "Förlust";
                    Graphics.DisplayPaperScissors();
                    break;
                default:
                    AnsiConsole.MarkupLine($"[red]Ogiltigt val resultat, tryck på någon tangent för att fortsätta.[/]");
                    Console.ReadKey();
                    break;
            }
            if (result == "Förlust")
                AnsiConsole.MarkupLine($"\n  Det blev [red]förlust![/] 😩");
            else if (result == "Vinst")
                AnsiConsole.MarkupLine($"\n  Det blev [green]vinst![/] 😎");
            else
                AnsiConsole.MarkupLine($"\n  Det blev [yellow]oavgjort![/] 🙄");

            var currentWinRatio = _rpsService.GetCurrentWinRatio();
            if (currentWinRatio != null)
            {
                AnsiConsole.MarkupLine($"  Din vinstprocent är: [green]{currentWinRatio}[/] %");
            }
            else
            {
                AnsiConsole.MarkupLine($"[red]  Ingen vinstprocent hittades.[/]");
            }

            AnsiConsole.MarkupLine("  Tryck på någon tangent för att återgå till menyn...");

            Console.ReadKey();
            Console.Clear();
        }
    }
}
