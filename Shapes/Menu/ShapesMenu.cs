namespace Shapes.Menu
{
    public class ShapesMenu : IShapesMenu
    {
        public void Show()
        {
            Console.Clear();
            Console.WriteLine("Inside ShapesMenu");
            Console.ReadKey();
            //Console.WriteLine("1. Circle");
            //Console.WriteLine("2. Square");
            //Console.WriteLine("3. Triangle");
            //Console.WriteLine("4. Exit");
            //var choice = Console.ReadKey(true).KeyChar;
            //switch (choice)
            //{
            //    case '1':
            //        // Show circle menu
            //        break;
            //    case '2':
            //        // Show square menu
            //        break;
            //    case '3':
            //        // Show triangle menu
            //        break;
            //    case '4':
            //        Environment.Exit(0);
            //        break;
            //    default:
            //        Console.WriteLine("Invalid choice, please try again.");
            //        Show();
            //        break;
        }
    }
}
