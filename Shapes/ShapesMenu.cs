namespace Shapes
{
    public class ShapesMenu : IShapesMenu
    {
        public void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("Välkommen till former");
            Console.ReadKey();
        }
    }
}
