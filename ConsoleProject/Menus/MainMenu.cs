using Calculator;
using RockPaperScissors;
using Service.UI;
using Shapes;
using Spectre.Console;

namespace ConsoleProject.Menus
{
    public class MainMenu : IMainMenu
    {
        private readonly IShapesMenu _shapeMenu;
        private readonly ICalculatorMenu _calcMenu;
        private readonly IRpsMenu _rpsMenu;

        public MainMenu(IShapesMenu shapeMenu, ICalculatorMenu calcMenu, IRpsMenu rpsMenu)
        {
            _shapeMenu = shapeMenu;
            _calcMenu = calcMenu;
            _rpsMenu = rpsMenu;
        }

        public void Show()
        {
            while (true)
            {
                Console.Clear();
                Graphics.RenderMultiTool();

                var userInput = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("[fuchsia]  Vad vill du göra idag?[/]")
                        .PageSize(10)
                        .MoreChoicesText("[grey](Pila upp eller ned)[/]")
                        .AddChoices(new[] {
                            "Använd Kalkylator", "Använd Formuträknare", "Spela Sten, Sax, Påse", "[maroon]Avsluta[/]",
                        }));

                switch (userInput)
                {
                    case "Använd Kalkylator":
                        _calcMenu.ShowMenu(); break;
                    case "Använd Formuträknare":
                        _shapeMenu.ShowMenu(); break;
                    case "Spela Sten, Sax, Påse":
                        _rpsMenu.ShowMenu(); break;
                    case "Avsluta":
                        Environment.Exit(0); break;
                    default:
                        Console.WriteLine("Ogiltigt val. Tryck valfri tangent.");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }

}
