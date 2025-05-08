namespace RPS
{
    public class RpsGame : IRpsGame
    {
        public void StartGame()
        {
            Console.WriteLine("in game");
            Console.ReadKey();
        }
    }
}
