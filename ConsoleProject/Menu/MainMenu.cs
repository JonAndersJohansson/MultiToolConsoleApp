using Client.Menu.UI;
using Spectre.Console;
using System.Diagnostics;

namespace Client.Menu
{
    public static class MainMenu
    {
        public static void Show()
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
                        StartExternalApp("CalculatorApp.exe");
                        break;
                    case "Använd Formuträknare":
                        StartExternalApp("ShapesApp.exe");
                        break;
                    case "Spela Sten, Sax, Påse":
                        StartExternalApp("RpsGameApp.exe");
                        break;
                    case "[maroon]Avsluta[/]":
                        Environment.Exit(0);
                        break;
                }
            }
        }
        private static void StartExternalApp(string exeName)
        {
            try
            {
                var path = Path.Combine("..", "..", "..", "..", exeName.Replace(".exe", ""), "bin", "Debug", "net8.0", exeName);

                if (!File.Exists(path))
                {
                    AnsiConsole.MarkupLine($"[red]Kunde inte hitta {exeName} på sökvägen:[/] {path}");
                    Console.ReadKey();
                    return;
                }

                var process = Process.Start(path);
                process.WaitForExit(); // Vänta tills användaren stängt appen
            }
            catch (Exception ex)
            {
                AnsiConsole.MarkupLine($"[red]Fel vid start av app:[/] {ex.Message}");
                Console.ReadKey();
            }
        }
    }
}
