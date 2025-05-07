using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.UI
{
    public static class Graphics
    {
        public static void RenderMultiTool()
        {
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine("███╗   ███╗██╗   ██╗██╗  ████████╗██╗████████╗ ██████╗  ██████╗ ██╗     ");
            Console.WriteLine("████╗ ████║██║   ██║██║  ╚══██╔══╝██║╚══██╔══╝██╔═══██╗██╔═══██╗██║     ");
            Console.WriteLine("██╔████╔██║██║   ██║██║     ██║   ██║   ██║   ██║   ██║██║   ██║██║     ");
            Console.WriteLine("██║╚██╔╝██║██║   ██║██║     ██║   ██║   ██║   ██║   ██║██║   ██║██║     ");
            Console.WriteLine("██║ ╚═╝ ██║╚██████╔╝███████╗██║   ██║   ██║   ╚██████╔╝╚██████╔╝███████╗");
            Console.WriteLine("╚═╝     ╚═╝ ╚═════╝ ╚══════╝╚═╝   ╚═╝   ╚═╝    ╚═════╝  ╚═════╝ ╚══════╝");
            Console.WriteLine("------------------------------Console App-------------------------------");
            Console.WriteLine("");

            Console.ResetColor();
        }
    }
}
