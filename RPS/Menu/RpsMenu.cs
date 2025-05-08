using Service.RPS;

namespace RPS.Menu
{
    public class RpsMenu : IRpsMenu
    {
        private readonly IRpsService _rpsService;

        public RpsMenu(IRpsService rpsService)
        {
            _rpsService = rpsService;
        }
        public void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("Inside RPSMENU");
            Console.ReadKey();
        }
    }
}
