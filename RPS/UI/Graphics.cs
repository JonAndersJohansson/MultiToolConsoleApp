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
        public static void DisplayClashingGraphics()
        {
            Console.Clear();
            Thread.Sleep(500);
            RenderClashingHands();
            Console.Beep(500, 500);
            Thread.Sleep(500);

            Console.Clear();
            Thread.Sleep(500);
            RenderClashingHands();
            Console.Beep(500, 500);
            Thread.Sleep(500);

            Console.Clear();
            Thread.Sleep(500);
            //RenderClashingHands();
            //Console.Beep(500, 500);
            //Thread.Sleep(500);
        }

        public static void DisplayScissorsScissors()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("     ________        ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("        ________");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(" ---'   _____)____   ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("   ____(_____   '---");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("           _______)  ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("  (_______");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("           ________) ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" (________");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("          ________)  ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("  (________");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(" ---.__________)     ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("     (__________.---");

            Console.ResetColor();
            Console.Beep(500, 500);
        }

        public static void DisplayScissorsRock()
        {
            throw new NotImplementedException();
        }

        public static void DisplayScissorsPaper()
        {
            throw new NotImplementedException();
        }

        public static void DisplayRockRock()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("            ______   ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("   ______");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(" ----------'  ____)  ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("  (____  '-----------");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("              (____) ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" (____)");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("              (____) ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" (____)");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("              (___)  ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("  (___)");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(" ----------.__(__)   ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("   (__)__.-----------");

            Console.ResetColor();
            Console.Beep(500, 500);
        }

        public static void DisplayRockScissors()
        {
            throw new NotImplementedException();
        }

        public static void DisplayRockPaper()
        {
            throw new NotImplementedException();
        }

        public static void DisplayPaperPaper()
        {
            throw new NotImplementedException();
        }

        public static void DisplayPaperRock()
        {
            throw new NotImplementedException();
        }

        public static void DisplayPaperScissors()
        {
            throw new NotImplementedException();
        }

        private static void RenderClashingHands()
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
