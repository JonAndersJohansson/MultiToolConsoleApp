namespace RPS.Menu
{
    public class RpsMenu : IRpsMenu
    {
        public void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("Inside RPSMENU");
            Console.ReadKey();
        }
    }
}
