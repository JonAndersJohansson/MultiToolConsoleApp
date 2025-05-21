using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.UI
{
    public class Graphics
    {
        public static void RenderShapes()
        {
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine("  ███████╗██╗  ██╗ █████╗ ██████╗ ███████╗███████╗  ");
            Console.WriteLine("  ██╔════╝██║  ██║██╔══██╗██╔══██╗██╔════╝██╔════╝  ");
            Console.WriteLine("  ███████╗███████║███████║██████╔╝█████╗  ███████╗  ");
            Console.WriteLine("  ╚════██║██╔══██║██╔══██║██╔═══╝ ██╔══╝  ╚════██║  ");
            Console.WriteLine("  ███████║██║  ██║██║  ██║██║     ███████╗███████║  ");
            Console.WriteLine("  ╚══════╝╚═╝  ╚═╝╚═╝  ╚═╝╚═╝     ╚══════╝╚══════╝  ");
            Console.WriteLine("                     Console App                              ");
            Console.WriteLine("");

            Console.ResetColor();
        }
    }
}
