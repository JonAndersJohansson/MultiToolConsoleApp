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
            GameResult gameResult = _rpsService.CalculateResult(userInput);

            switch (gameResult)
            {
                case GameResult.Draw:
                    ShowDraw();
                    break;
                case GameResult.Win:
                    //
                    break;
                case GameResult.Lose:
                    //
                    break;
                default:
                    AnsiConsole.MarkupLine($"[red]Ogiltigt val resultat, tryck på någon tangent för att fortsätta.[/]");
                    Console.ReadKey();
                    break;
            }


            //return GameResult.Lose;
            //AnsiConsole.MarkupLine($"[red]Du valde {userInput} och datorn valde {computerChoiceString}. Du förlorade![/]");

            //return GameResult.Win;
            //AnsiConsole.MarkupLine($"[green]Du valde {userInput} och datorn valde {computerChoiceString}. Du vann![/]");

            //return GameResult.Draw;
            //AnsiConsole.MarkupLine($"[yellow]Du valde {userInput} och datorn valde {computerChoiceString}. Det blev oavgjort![/]");

        }

        private void ShowDraw()
        {
            Console.Clear();
            Thread.Sleep(500);
            Graphics.RenderClashingHands();
            Console.Beep(500, 500);
            Thread.Sleep(500);

            Console.Clear();
            Thread.Sleep(500);
            Graphics.RenderClashingHands();
            Console.Beep(500, 500);
            Thread.Sleep(500);

            Console.Clear();
            Thread.Sleep(500);
            Graphics.RenderClashingHands();
            Console.Beep(500, 500);
            Thread.Sleep(500);

        }
    }
}
