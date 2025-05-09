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
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine("  Gör ditt val: Sten sax eller påse.\n" +
                "  Sten vinner över sax.\n" +
                "  Sax vinner över påse.\n" +
                "  Påse vinner över sten.");

            Console.ResetColor();
        }
        public static void RenderClashingHands()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("     ______   ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("   ______");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(" ---'  ____)  ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("  (____  '---");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("       (____) ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" (____)       ");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("       (____) ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" (____)       ");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("       (___)  ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("  (___)       ");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(" ---.__(__)   ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("   (__)__.---");

            Console.ResetColor();
        }
    }
}
