using Service;
using Service.UI;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.Menus
{
    public class MainMenu : IMainMenu
    {
        private readonly IShapeService _shapeService;
        private readonly ICalculatorService _calcService;
        private readonly IRpsService _rpsService;

        public MainMenu(IShapeService shapeService, ICalculatorService calcService, IRpsService rpsService)
        {
            _shapeService = shapeService;
            _calcService = calcService;
            _rpsService = rpsService;
        }

        public async Task ShowAsync()
        {
            while (true)
            {
                Console.Clear();
                Graphics.RenderMultiTool();
                // Ask for the user's favorite fruit
                var fruit = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("What's your [green]favorite fruit[/]?")
                        .PageSize(10)
                        .MoreChoicesText("[grey](Move up and down to reveal more fruits)[/]")
                        .AddChoices(new[] {
                            "Apple", "Apricot", "Avocado",
                            "Banana", "Blackcurrant", "Blueberry",
                            "Cherry", "Cloudberry", "Cocunut",
                        }));

                // Echo the fruit back to the terminal
                AnsiConsole.WriteLine($"I agree. {fruit} is tasty!");
                Console.ReadKey();


                //Console.Clear();
                //Console.WriteLine("=== HUVUDMENY ===");
                //Console.WriteLine("1. Shapes");
                //Console.WriteLine("2. Miniräknare");
                //Console.WriteLine("3. Sten, Sax, Påse");
                //Console.WriteLine("0. Avsluta");
                //Console.Write("Val: ");
                //var input = Console.ReadLine();

                //switch (input)
                //{
                //    case "1":
                //        await _shapeService.ShowMenuAsync(); break;
                //    case "2":
                //        await _calcService.ShowMenuAsync(); break;
                //    case "3":
                //        await _rpsService.ShowMenuAsync(); break;
                //    case "0":
                //        return;
                //    default:
                //        Console.WriteLine("Ogiltigt val. Tryck valfri tangent.");
                //        Console.ReadKey();
                //        break;
                //}
            }
        }
    }

}
