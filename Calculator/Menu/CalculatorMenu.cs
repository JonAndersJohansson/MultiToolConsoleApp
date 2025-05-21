namespace Calculator.Menu
{
    public class CalculatorMenu : ICalculatorMenu
    {
        public void Show()
        {
            Console.Clear();
            Console.WriteLine("Inside CalculatorMenu");
            Console.ReadKey();

        }
    }
}
