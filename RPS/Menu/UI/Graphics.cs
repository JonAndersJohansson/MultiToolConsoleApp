using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS.Menu.UI
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
    }
}
