namespace Service.Calculator.Strategy
{
    public class DivisionStrategy : ICalculatorStrategy
    {
        public string Operator => "/";
        public string[] ParameterPrompts => new[] { "Tal 1", "Tal 2" };

        public double GetResult(double[] parameters)
        {
            if (parameters.Length != 2)
                throw new ArgumentException("Division kräver två parametrar.");

            if (parameters[1] == 0)
                throw new DivideByZeroException("Division med noll är inte tillåtet.");

            return parameters[0] / parameters[1];
        }
    }
}
