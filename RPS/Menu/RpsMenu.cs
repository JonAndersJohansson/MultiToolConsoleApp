using RPS.Game;
using RPS.UI;
using Service.RPS;
using Spectre.Console;

namespace RPS.Menu
{
    public class RpsMenu : IRpsMenu
    {
        private readonly IRpsGame _rpsGame;

        public RpsMenu(IRpsGame rpsGame)
        {
            _rpsGame = rpsGame;
        }
        public void Show()
        {
            while (true)
            {
                Console.Clear();
                Graphics.RenderRPS();

                var userInput = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("[aqua]  Välkommen till Sten, Sax, Påse. Välj val:[/]")
                        .PageSize(10)
                        .MoreChoicesText("[grey](Pila upp eller ned)[/]")
                        .AddChoices(new[] {
                            "Spela mot datorn", "Visa tidigare spel", "Visa regler", "[maroon]Tillbaka[/]",
                        }));

                switch (userInput)
                {
                    case "Spela mot datorn":
                        _rpsGame.StartGame();
                        break;
                    case "Visa tidigare spel":
                        //
                        break;
                    case "Visa regler":
                        //
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
