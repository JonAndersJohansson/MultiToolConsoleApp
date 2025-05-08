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

            Console.WriteLine("                  ██████╗     ██╗██████╗   ██╗███████╗                  ");
            Console.WriteLine("                  ██╔══██╗   ██╔╝██╔══██╗ ██╔╝██╔════╝");
            Console.WriteLine("                  ██████╔╝  ██╔╝ ██████╔╝██╔╝ ███████╗");
            Console.WriteLine("                  ██╔══██╗ ██╔╝  ██╔═══╝██╔╝  ╚════██║");
            Console.WriteLine("                  ██║  ██║██╔╝   ██║   ██╔╝   ███████║");
            Console.WriteLine("                  ╚═╝  ╚═╝╚═╝    ╚═╝   ╚═╝    ╚══════╝");
            Console.WriteLine("                  --- Sten/Sax/Påse - Console App ----");
            Console.WriteLine("");

            Console.ResetColor();
        }
    }
}
