using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS.UI
{
    public static class Graphics
    {
        public static void RenderRPS()
        {
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine("                ██████╗     ██╗██████╗   ██╗███████╗");
            Console.WriteLine("                ██╔══██╗   ██╔╝██╔══██╗ ██╔╝██╔════╝");
            Console.WriteLine("                ██████╔╝  ██╔╝ ██████╔╝██╔╝ ███████╗");
            Console.WriteLine("                ██╔══██╗ ██╔╝  ██╔═══╝██╔╝  ╚════██║");
            Console.WriteLine("                ██║  ██║██╔╝   ██║   ██╔╝   ███████║");
            Console.WriteLine("                ╚═╝  ╚═╝╚═╝    ╚═╝   ╚═╝    ╚══════╝");
            Console.WriteLine("------------------------------Console App-------------------------------");
            Console.WriteLine("");

            Console.ResetColor();
        }
        public static void RenderRules()
        {

            AnsiConsole.MarkupLine("  [aqua]Gör ditt val: Sten, Sax eller Påse.\n" +
                "  Du är [blue]blå[/] och boten är [red]röd.[/]\n" +
                "  Sten vinner över sax.\n" +
                "  Sax vinner över påse.\n" +
                "  Påse vinner över sten.\n" +
                "  Det kan bli oavgjort.[/]");
            AnsiConsole.MarkupLine("\n  Tryck på valfri tangent för att återgå...");
            Console.ReadKey();
        }

        public static void DisplayScissorsScissors()
        {
            DisplayClashingGraphics();
            Console.WriteLine("                    Du:                    Bot:");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("                 ________         ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("         ________");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("             ---'    ____)_____   ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("   _____(____    '---");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("                        _______)  ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("  (_______");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("             Sax     ___________) ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" (___________     Sax");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("                    (____)        ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("        (____)");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("             ---.__(___)          ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("         (___)___.---");

            Console.ResetColor();
            Console.Beep(500, 500);
        }

        public static void DisplayScissorsRock()
        {
            DisplayClashingGraphics();
            Console.WriteLine("                    Du:                    Bot:");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("                 ________         ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("   ______");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("             ---'    ____)_____   ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("  (____  '-----------");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("                        _______)  ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" (____)");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("             Sax     ___________) ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" (____)          Sten");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("                    (____)        ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("  (___)");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("             ---.__(___)          ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("   (__)__.-----------");

            Console.ResetColor();
            Console.Beep(500, 500);
        }

        public static void DisplayScissorsPaper()
        {
            DisplayClashingGraphics();
            Console.WriteLine("                    Du:                    Bot:");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("                 ________         ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("        ________");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("             ---'    ____)_____   ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("   ____(_____   '---");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("                        _______)  ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("  (_______");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("             Sax     ___________) ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" (________      Påse");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("                    (____)        ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("  (________");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("             ---.__(___)          ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("     (__________.---");

            Console.ResetColor();
            Console.Beep(500, 500);
        }

        public static void DisplayRockRock()
        {
            DisplayClashingGraphics();
            Console.WriteLine("                    Du:                    Bot:");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("                        ______   ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("   ______");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("             ----------'  ____)  ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("  (____  '-----------");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("                          (____) ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" (____)");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("             Sten         (____) ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" (____)         Sten");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("                          (___)  ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("  (___)");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("             ----------.__(__)   ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("   (__)__.-----------");

            Console.ResetColor();
            Console.Beep(500, 500);
        }

        public static void DisplayRockScissors()
        {
            DisplayClashingGraphics();
            //AnsiConsole.MarkupLine("                    [bold]Du:[/]                    [bold]Bot:[/]");
            //AnsiConsole.MarkupLine("[blue]                        ______   [/][red]         ________[/]");
            //AnsiConsole.MarkupLine("[blue]             ----------'  ____)  [/][red]   _____(____    '---[/]");
            //AnsiConsole.MarkupLine("[blue]                          (____) [/][red]  (_______[/]");
            //AnsiConsole.MarkupLine("[blue]             Sten         (____) [/][red] (___________     Sax[/]");
            //AnsiConsole.MarkupLine("[blue]                          (___)  [/][red]        (____)[/]");
            //AnsiConsole.MarkupLine("[blue]             ----------.__(__)   [/][red]         (___)___.---[/]");
            Console.WriteLine("                    Du:                    Bot:");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("                        ______   ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("         ________");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("             ----------'  ____)  ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("   _____(____    '---");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("                          (____) ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("  (_______");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("             Sten         (____) ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" (___________     Sax");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("                          (___)  ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("        (____)");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("             ----------.__(__)   ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("         (___)___.---");

            Console.ResetColor();
            Console.Beep(500, 500);
        }

        public static void DisplayRockPaper()
        {
            DisplayClashingGraphics();
            Console.WriteLine("                    Du:                    Bot:");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("                        ______   ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("        ________");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("             ----------'  ____)  ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("   ____(_____   '---");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("                          (____) ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("  (_______");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("             Sten         (____) ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" (________      Påse");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("                          (___)  ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("  (________");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("             ----------.__(__)   ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("     (__________.---");

            Console.ResetColor();
            Console.Beep(500, 500);
        }

        public static void DisplayPaperPaper()
        {
            DisplayClashingGraphics();
            Console.WriteLine("                    Du:                    Bot:");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("                 ________        ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("        ________");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("             ---'   _____)____   ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("   ____(_____   '---");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("                       _______)  ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("  (_______");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("             Påse      ________) ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" (________      Påse");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("                      ________)  ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("  (________");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("             ---.__________)     ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("     (__________.---");

            Console.ResetColor();
            Console.Beep(500, 500);
        }

        public static void DisplayPaperRock()
        {
            DisplayClashingGraphics();
            Console.WriteLine("                    Du:                    Bot:");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("                 ________        ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("   ______");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("             ---'   _____)____   ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("  (____  '-----------");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("                       _______)  ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" (____)");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("             Påse      ________) ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" (____)         Sten");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("                      ________)  ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("  (___)");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("             ---.__________)     ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("   (__)__.-----------");

            Console.ResetColor();
            Console.Beep(500, 500);
        }

        public static void DisplayPaperScissors()
        {
            DisplayClashingGraphics();
            Console.WriteLine("                    Du:                    Bot:");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("                 ________        ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("         ________");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("             ---'   _____)____   ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("   _____(____    '---");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("                       _______)  ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("  (_______");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("             Påse      ________) ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" (___________     Sax");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("                      ________)  ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("        (____)");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("             ---.__________)     ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("         (___)___.---");

            Console.ResetColor();
            Console.Beep(500, 500);
        }
        private static void DisplayClashingGraphics()
        {
            Console.Clear();
            RenderRPS();
            Thread.Sleep(500);
            RenderClashingHands();
            Console.Beep(500, 500);
            Thread.Sleep(500);

            Console.Clear();
            RenderRPS();
            Thread.Sleep(500);
            RenderClashingHands();
            Console.Beep(500, 500);
            Thread.Sleep(500);

            Console.Clear();
            RenderRPS();
            Thread.Sleep(500);
        }
        private static void RenderClashingHands()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("                        ______   ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("   ______");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("             ----------'  ____)  ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("  (____  '-----------");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("                          (____) ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" (____)");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("                          (____) ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" (____)");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("                          (___)  ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("  (___)");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("             ----------.__(__)   ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("   (__)__.-----------");

            Console.ResetColor();
        }
    }
}
