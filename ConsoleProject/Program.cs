using Client.Menu;

namespace ConsoleProject
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("In client program.cs...");
            Console.ReadLine();

            MainMenu.Show();
        }
    }
}
