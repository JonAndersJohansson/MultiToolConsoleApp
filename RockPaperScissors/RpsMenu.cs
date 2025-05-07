namespace RockPaperScissors
{
    public class RpsMenu : IRpsMenu
    {
        public void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("Välkommen till Sten, Sax, Påse!");
            Console.ReadKey();

            //    Console.WriteLine("Välkommen till Sten, Sax, Påse!");
            //    Console.WriteLine("1. Spela");
            //    Console.WriteLine("2. Avsluta");
            //    Console.Write("Välj ett alternativ: ");
            //    string choice = Console.ReadLine();
            //    switch (choice)
            //    {
            //        case "1":
            //            PlayGame();
            //            break;
            //        case "2":
            //            Environment.Exit(0);
            //            break;
            //        default:
            //            Console.WriteLine("Ogiltigt val. Försök igen.");
            //            ShowMenu();
            //            break;
            //    }
            //}
            //private void PlayGame()
            //{
            //    // Implementera spel-logik här
            //    Console.WriteLine("Spelet startar...");
            //    // ...
            //}
        }
    }
}
