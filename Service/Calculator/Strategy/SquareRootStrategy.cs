namespace Service.Calculator.Strategy
{
    public class SquareRootStrategy : ICalculatorStrategy
    {
        public string Operator => "√";
        public string[] ParameterPrompts => new[] { "Tal" };

        public double GetResult(double[] parameters)
        {
            if (parameters.Length != 1)
                throw new ArgumentException("Roten ur kräver en parameter.");
            if (parameters[0] < 0)
                throw new ArgumentException("Kan inte beräkna roten ur av ett negativt tal.");
            return Math.Sqrt(parameters[0]);
        }
    }
}
