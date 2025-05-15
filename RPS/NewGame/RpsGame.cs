using RPS.Menu;
using RPS.UI;
using Service.RPS;
using Service.RPS.Enum;
using Spectre.Console;
using System.ComponentModel;

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
            Graphics.DisplayClashingGraphics();
            Console.ReadKey();

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

            AnsiConsole.MarkupLine($"Det blev {result}");
            Console.ReadKey();





            //return GameResult.Lose;
            //AnsiConsole.MarkupLine($"[red]Du valde {userInput} och datorn valde {computerChoiceString}. Du förlorade![/]");

            //return GameResult.Win;
            //AnsiConsole.MarkupLine($"[green]Du valde {userInput} och datorn valde {computerChoiceString}. Du vann![/]");

            //return GameResult.Draw;
            //AnsiConsole.MarkupLine($"[yellow]Du valde {userInput} och datorn valde {computerChoiceString}. Det blev oavgjort![/]");

        }


    }
}
