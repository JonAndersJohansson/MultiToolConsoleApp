namespace Calculator
{
    public class CalculatorMenu : ICalculatorMenu
    {
        public void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("Välkommen till kalkylator");
            Console.ReadKey();
        }
    }
}
